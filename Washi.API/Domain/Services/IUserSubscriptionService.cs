using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IUserSubscriptionService
    {
        Task<IEnumerable<UserSubscription>> ListAsync();
        Task<IEnumerable<UserSubscription>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSubscription>> ListBySubscriptionIdAsync(int subscriptionId);
        Task<UserSubscriptionResponse> SaveAsync(UserSubscription userSubscription);
        Task<UserSubscriptionResponse> AssignUserSubscriptionAsync(int userId, int subscriptionId);
        Task<UserSubscriptionResponse> UnassignUserSubscriptionAsync(int userId, int subscriptionId);
    }
}
