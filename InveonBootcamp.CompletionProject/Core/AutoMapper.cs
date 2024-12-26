using AutoMapper;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;

namespace InveonBootcamp.CompletionProject.Core
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateOrderDto, Order>()
                        .ForMember(dest => dest.OrderCourses, opt => opt.MapFrom(src => src.OrderCourses));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderCourses, opt => opt.MapFrom(src => src.OrderCourses));

            CreateMap<OrderCourseDto, OrderCourse>().ReverseMap();

            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();

            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();

            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();
        }
    }
}
