namespace InveonBootcamp.CompletionProject.Core.Dtos
{
    public record PaymentDto(int Id, string PaymentStatus, DateTime PaymentDate, int OrderId);
}
