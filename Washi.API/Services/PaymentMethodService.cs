using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository, IUnitOfWork unitOfWork, IUserPaymentMethodRepository userPaymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _unitOfWork = unitOfWork;
            _userPaymentMethodRepository = userPaymentMethodRepository;
        }

        public async Task<PaymentMethodResponse> DeleteAsync(int id)
        {
            var existingPaymentMethod = await _paymentMethodRepository.FindById(id);
            if (existingPaymentMethod == null)
                return new PaymentMethodResponse("Payment Method not found");
            try
            {
                _paymentMethodRepository.Remove(existingPaymentMethod);
                await _unitOfWork.CompleteAsync();
                return new PaymentMethodResponse(existingPaymentMethod);
            }
            catch (Exception ex)
            {
                return new PaymentMethodResponse($"An error ocurred while deleting payment method: {ex.Message}");
            }
        }

        public async Task<PaymentMethodResponse> GetByIdAsync(int id)
        {
            var existingPaymentMethod = await _paymentMethodRepository.FindById(id);

            if (existingPaymentMethod == null)
                return new PaymentMethodResponse("Payment Method not found");
            return new PaymentMethodResponse(existingPaymentMethod);
        }

        public async Task<IEnumerable<PaymentMethod>> ListAsync()
        {
            return await _paymentMethodRepository.ListAsync();
        }

        public async Task<IEnumerable<PaymentMethod>> ListByUserIdAsync(int userId)
        {
            var userPaymentMethods = await _userPaymentMethodRepository.ListByUserIdAsync(userId);
            var paymentMethods = userPaymentMethods.Select(p => p.PaymentMethod).ToList();
            return paymentMethods;
        }

        public async Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod)
        {
            try
            {
                await _paymentMethodRepository.AddSync(paymentMethod);
                await _unitOfWork.CompleteAsync();
                return new PaymentMethodResponse(paymentMethod);
            }
            catch(Exception ex)
            {
                return new PaymentMethodResponse($"An error ocurred while saving payment method: {ex.Message}");
            }
        }

        public async Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = await _paymentMethodRepository.FindById(id);
            if (existingPaymentMethod == null)
                return new PaymentMethodResponse("Payment Method not found");
            existingPaymentMethod.Name = paymentMethod.Name;
            try
            {
                _paymentMethodRepository.Update(existingPaymentMethod);
                await _unitOfWork.CompleteAsync();
                return new PaymentMethodResponse(existingPaymentMethod);
            }
            catch(Exception ex)
            {
                return new PaymentMethodResponse($"An error ocurred while updating payment method: {ex.Message}");
            }
        }
    }
}
