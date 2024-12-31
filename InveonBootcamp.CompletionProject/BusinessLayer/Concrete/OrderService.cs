using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var user = await _unitOfWork.Users.GetByIdAsync(createOrderDto.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
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
                    throw new Exception("Course not found");
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
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OrderDto>(order);
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
            var order = await _unitOfWork.Orders
                .Find(o => o.Id == id)
                .Include(o => o.OrderCourses)
                .ThenInclude(oc => oc.Course)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                throw new Exception("Order not found!");
            }

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetUserOrdersByEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("User not found!");
            }

            var orders = await _unitOfWork.Orders
                .Find(o => o.UserId == user.Id)
                .Include(o => o.OrderCourses)
                .ThenInclude(oc => oc.Course)
                .ToListAsync();

            // Eğer sipariş yoksa hata fırlatmayın, boş list geri dönderin
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