namespace InveonBootcamp.CompletionProject.Core.Dtos
{
    public record PaymentDto(int Id,decimal Amount, string PaymentStatus, DateTime PaymentDate, int OrderId);
}
