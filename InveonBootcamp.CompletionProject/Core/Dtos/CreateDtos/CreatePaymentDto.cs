namespace InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos
{
    public record CreatePaymentDto(decimal Amount, string PaymentStatus, DateTime PaymentDate, int OrderId);
}
