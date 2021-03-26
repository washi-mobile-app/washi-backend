using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IUserSubscriptionRepository
    {
        Task<IEnumerable<UserSubscription>> ListAsync();
        Task<IEnumerable<UserSubscription>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSubscription>> ListBySubscriptionIdAsync(int subscriptionId);
        Task<UserSubscription> FindByUserIdAndSubscriptionId(int userId, int subscriptionId);
        Task AddAsync(UserSubscription userSubscription);
        void Remove(UserSubscription userSubscription);
        Task AssignUserSubscription(int userId, int subscriptionId);
        void UnassignUserSubscription(int userId, int subscriptionId);
    }
}
