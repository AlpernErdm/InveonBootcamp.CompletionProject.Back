using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;
using InveonBootcamp.CompletionProject.Core.ExceptionHandler.ExceptionClasses;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class OrderService(IUnitOfWork unitOfWork, IMapper mapper) : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(createOrderDto.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var order = new Order
            {
                User = user,
                UserId = user.Id,
                OrderDate = DateTime.UtcNow,
                OrderCourses = new List<OrderCourse>()
            };

            foreach (var orderCourseDto in createOrderDto.OrderCourses)
            {
                var course = await _unitOfWork.Courses.GetByIdAsync(orderCourseDto.CourseId);
                if (course == null)
                {
                    throw new NotFoundException("Course not found");
                }
                var orderCourse = new OrderCourse
                {
                    Order = order,
                    Course = course,
                    OrderId = order.Id,
                    CourseId = course.Id
                };

                order.OrderCourses.Add(orderCourse);
            }
            await _unitOfWork.Orders.AddAsync(order);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                throw new CreationFailedException("Order creation failed.");
            }
            return _mapper.Map<OrderDto>(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }

            _unitOfWork.Orders.Remove(order);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0) 
            {
                throw new DeletionFailedException("Order deletion failed.");
            }
        }
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders
                .Find(o => o.Id == id)
                .Include(o => o.OrderCourses)
                .ThenInclude(oc => oc.Course)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }

            return _mapper.Map<OrderDto>(order);
        }
        public async Task<IEnumerable<OrderDto>> GetUserOrdersByEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Email == email);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            var orders = await _unitOfWork.Orders
                .Find(o => o.UserId == user.Id)
                .Include(o => o.OrderCourses)
                .ThenInclude(oc => oc.Course)
                .ToListAsync();
            if (orders == null || !orders.Any())
            {
                return new List<OrderDto>();
            }

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            var existingOrder = await _unitOfWork.Orders.GetByIdAsync(id);
            if (existingOrder == null)
            {
                throw new NotFoundException("Order not found");
            }

            existingOrder.OrderDate = updateOrderDto.OrderDate;
            existingOrder.OrderCourses = _mapper.Map<ICollection<OrderCourse>>(updateOrderDto.OrderCourses);

            _unitOfWork.Orders.Update(existingOrder);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                throw new UpdateFailedException("Order update failed.");
            }
            return _mapper.Map<OrderDto>(existingOrder);
        }
    }
}