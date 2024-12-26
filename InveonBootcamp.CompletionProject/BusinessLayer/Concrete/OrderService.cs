using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto)
        {
            // Kullanıcıyı doğrula
            var user = await _unitOfWork.Users.GetByIdAsync(createOrderDto.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Model oluştur
            var order = _mapper.Map<Order>(createOrderDto);
            order.User = user;
            order.OrderDate = DateTime.UtcNow;  // Eğer DTO'dan almayacaksak

            // Veritabanına ekle
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CompleteAsync();

            // DTO'ya map'le
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order != null)
            {
                _unitOfWork.Orders.Remove(order);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            var existingOrder = await _unitOfWork.Orders.GetByIdAsync(id);
            if (existingOrder == null)
            {
                throw new Exception("Order not found");
            }

            existingOrder.OrderDate = updateOrderDto.OrderDate;
            existingOrder.OrderCourses = _mapper.Map<ICollection<OrderCourse>>(updateOrderDto.OrderCourses);

            _unitOfWork.Orders.Update(existingOrder);
            await _unitOfWork.CompleteAsync();

            var orderDto = _mapper.Map<OrderDto>(existingOrder);
            return orderDto;
        }
    }
}
