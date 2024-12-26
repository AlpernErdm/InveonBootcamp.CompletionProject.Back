namespace InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos
{
    public record UpdateOrderDto(Guid UserId, DateTime OrderDate, List<OrderCourseDto> OrderCourses);
}
