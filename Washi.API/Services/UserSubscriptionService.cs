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
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserSubscriptionService(IUserSubscriptionRepository userSubscriptionRepository, IUnitOfWork unitOfWork)
        {
            _userSubscriptionRepository = userSubscriptionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserSubscriptionResponse> SaveAsync(UserSubscription userSubscription)
        {
            try
            {
                await _userSubscriptionRepository.AddAsync(userSubscription);
                return new UserSubscriptionResponse(userSubscription);
            }
            catch (Exception ex)
            {
                return new UserSubscriptionResponse($"An error ocurred while adding User paymentMethod: {ex.Message}");
            }
        }
        public async Task<UserSubscriptionResponse> AssignUserSubscriptionAsync(int userId, int subscriptionId)
        {
            try
            {
                await _userSubscriptionRepository.AssignUserSubscription(userId, subscriptionId);
                await _unitOfWork.CompleteAsync();
                UserSubscription userSubscription = await _userSubscriptionRepository.FindByUserIdAndSubscriptionId(userId, subscriptionId);
                return new UserSubscriptionResponse(userSubscription);
            }
            catch (Exception ex)
            {
                return new UserSubscriptionResponse($"An error ocurred while assigning Payment Method to User: {ex.Message}");
            }
        }

        public async Task<UserSubscriptionResponse> UnassignUserSubscriptionAsync(int userId, int subscriptionId)
        {
            try
            {
                _userSubscriptionRepository.UnassignUserSubscription(userId, subscriptionId);
                await _unitOfWork.CompleteAsync();
                return new UserSubscriptionResponse(new UserSubscription { UserId = userId, SubscriptionId = subscriptionId });
            }
            catch (Exception ex)
            {
                return new UserSubscriptionResponse($"An error ocurred while unassigning Payment Method to User: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserSubscription>> ListAsync()
        {
            return await _userSubscriptionRepository.ListAsync();
        }

        public async Task<IEnumerable<UserSubscription>> ListByUserIdAsync(int userId)
        {
            return await _userSubscriptionRepository.ListByUserIdAsync(userId);
        }

        public async Task<IEnumerable<UserSubscription>> ListBySubscriptionIdAsync(int subscriptionId)
        {
            return await _userSubscriptionRepository.ListBySubscriptionIdAsync(subscriptionId);
        }
    }
}
