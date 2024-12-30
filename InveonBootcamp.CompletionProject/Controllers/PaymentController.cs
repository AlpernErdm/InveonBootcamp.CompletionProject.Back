using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.CompletionProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> PostPayment(CreatePaymentDto createPaymentDto)
        {
            var paymentDto = await _paymentService.AddPaymentAsync(createPaymentDto);
            return CreatedAtAction(nameof(GetPayment), new { id = paymentDto.Id }, paymentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, UpdatePaymentDto updatePaymentDto)
        {
            var paymentDto = await _paymentService.UpdatePaymentAsync(id, updatePaymentDto);
            return Ok(paymentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
