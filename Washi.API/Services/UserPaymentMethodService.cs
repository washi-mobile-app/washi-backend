using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Services
{
    public class UserPaymentMethodService : IUserPaymentMethodService
    {
        private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserPaymentMethodService(IUserPaymentMethodRepository userPaymentMethodRepository, IUnitOfWork unitOfWork)
        {
            _userPaymentMethodRepository = userPaymentMethodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserPaymentMethodResponse> AssignUserPaymentMethodAsync(int userId, int paymentMethodId)
        {
            try
            {
                await _userPaymentMethodRepository.AssignUserPaymentMethod(userId, paymentMethodId);
                await _unitOfWork.CompleteAsync();
                UserPaymentMethod userPaymentMethod = await _userPaymentMethodRepository.FindByUserIdAndPaymentMethodId(userId, paymentMethodId);
                return new UserPaymentMethodResponse(userPaymentMethod);
            }
            catch (Exception ex)
            {
                return new UserPaymentMethodResponse($"An error ocurred while assigning Payment Method to User: {ex.Message}");
            }
        }

        public async Task<UserPaymentMethodResponse> UnassignUserPaymentMethodAsync(int userId, int paymentMethodId)
        {
            try
            {
                _userPaymentMethodRepository.UnassignUserPaymentMethod(userId, paymentMethodId);
                await _unitOfWork.CompleteAsync();
                return new UserPaymentMethodResponse(new UserPaymentMethod { UserId = userId, PaymentMethodId = paymentMethodId });
            }
            catch (Exception ex)
            {
                return new UserPaymentMethodResponse($"An error ocurred while unassigning Payment Method to User: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListAsync()
        {
            return await _userPaymentMethodRepository.ListAsync();
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(int userId)
        {
            return await _userPaymentMethodRepository.ListByUserIdAsync(userId);
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(int paymentMethodId)
        {
            return await _userPaymentMethodRepository.ListByPaymentMethodIdAsync(paymentMethodId);
        }
    }
}
