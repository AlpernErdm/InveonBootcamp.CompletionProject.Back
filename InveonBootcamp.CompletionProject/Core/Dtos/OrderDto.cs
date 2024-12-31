namespace InveonBootcamp.CompletionProject.Core.Dtos
{
    public record OrderDto(int Id, Guid UserId, UserDto User, DateTime OrderDate, List<OrderCourseDto> OrderCourses);
}
