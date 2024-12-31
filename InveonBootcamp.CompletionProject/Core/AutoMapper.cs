using AutoMapper;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;

namespace InveonBootcamp.CompletionProject.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Kullanıcı Mappings
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();

            // Order Mappings
            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.OrderCourses, opt => opt.MapFrom(src => src.OrderCourses));
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderCourses, opt => opt.MapFrom(src => src.OrderCourses));
            CreateMap<UpdateOrderDto, Order>().ReverseMap();

            // OrderCourse Mappings
            CreateMap<CreateOrderCourseDto, OrderCourse>();
            CreateMap<OrderCourseDto, OrderCourse>().ReverseMap();

            // Payment Mappings
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<Payment, PaymentDto>().ReverseMap();

            // Course Mappings
            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();
        }
    }
}
