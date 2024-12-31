namespace InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos
{
    public record CreateOrderDto(Guid UserId, List<CreateOrderCourseDto> OrderCourses);
}
