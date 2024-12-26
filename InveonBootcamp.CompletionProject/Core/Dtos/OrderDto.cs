namespace InveonBootcamp.CompletionProject.Core.Dtos
{
    public record OrderDto(
      int Id,
      Guid UserId,
      DateTime OrderDate,
      ICollection<OrderCourseDto> OrderCourses,
      PaymentDto Payment
  );
}
