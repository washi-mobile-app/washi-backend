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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork, IUserSubscriptionRepository userSubscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
            _userSubscriptionRepository = userSubscriptionRepository;
        }

        public async Task<SubscriptionResponse> DeleteAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);
            if (existingSubscription == null)
                return new SubscriptionResponse("Payment Method not found");
            try
            {
                _subscriptionRepository.Remove(existingSubscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while deleting payment method: {ex.Message}");
            }
        }

        public async Task<SubscriptionResponse> GetByIdAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Payment Method not found");
            return new SubscriptionResponse(existingSubscription);
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId)
        {
            var userSubscriptions = await _userSubscriptionRepository.ListByUserIdAsync(userId);
            var subscriptions = userSubscriptions.Select(p => p.Subscription).ToList();
            return subscriptions;
        }

        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            try
            {
                await _subscriptionRepository.AddSync(subscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(subscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while saving payment method: {ex.Message}");
            }
        }

        public async Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);
            if (existingSubscription == null)
                return new SubscriptionResponse("Payment Method not found");
            existingSubscription.Name = subscription.Name;
            try
            {
                _subscriptionRepository.Update(existingSubscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while updating payment method: {ex.Message}");
            }
        }
    }
}
