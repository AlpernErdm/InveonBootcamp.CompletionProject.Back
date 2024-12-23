namespace InveonBootcamp.CompletionProject.Core.Dtos
{
    public record OrderDto(int Id, int UserId, DateTime OrderDate, List<OrderCourseDto> OrderCourses);
}
