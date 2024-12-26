using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Abstract
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
        Task<PaymentDto> GetPaymentByIdAsync(int id);
        Task<PaymentDto> AddPaymentAsync(CreatePaymentDto paymentDto);
        Task<PaymentDto> UpdatePaymentAsync(int id, UpdatePaymentDto updatePaymentDto);
        Task DeletePaymentAsync(int id);
    }
}
