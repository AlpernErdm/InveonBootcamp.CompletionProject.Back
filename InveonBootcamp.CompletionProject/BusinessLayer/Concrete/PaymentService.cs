﻿using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> AddPaymentAsync(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.CompleteAsync();

            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return paymentDto;
        }

        public async Task<PaymentDto> UpdatePaymentAsync(int id, UpdatePaymentDto updatePaymentDto)
        {
            var existingPayment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (existingPayment == null)
            {
                throw new Exception("Payment not found");
            }
            _mapper.Map(updatePaymentDto, existingPayment);

            _unitOfWork.Payments.Update(existingPayment);
            await _unitOfWork.CompleteAsync();

            var paymentDto = _mapper.Map<PaymentDto>(existingPayment);
            return paymentDto;
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment != null)
            {
                _unitOfWork.Payments.Remove(payment);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
