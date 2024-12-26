namespace InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos
{
    public record CreateOrderDto(
        Guid UserId,
        DateTime OrderDate,
        ICollection<OrderCourseDto> OrderCourses
    );
}
