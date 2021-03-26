using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;

namespace Washi.API.Persistence.Repositories
{
    public class UserSubscriptionRepository : BaseRepository, IUserSubscriptionRepository
    {
        public UserSubscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserSubscription userSubscription)
        {
            await _context.UserSubscriptions.AddAsync(userSubscription);
        }

        public async Task AssignUserSubscription(int userId, int subscriptionId)
        {
            UserSubscription userSubscription = await FindByUserIdAndSubscriptionId(userId, subscriptionId);
            if (userSubscription == null)
            {
                userSubscription = new UserSubscription { UserId = userId, SubscriptionId = subscriptionId };
                await AddAsync(userSubscription);
            }
        }

        public async Task<UserSubscription> FindByUserIdAndSubscriptionId(int userId, int subscriptionId)
        {
            return await _context.UserSubscriptions.FindAsync(userId, subscriptionId);
        }

        public async Task<IEnumerable<UserSubscription>> ListAsync()
        {
            return await _context.UserSubscriptions
                .Include(p => p.User)
                .Include(p => p.Subscription)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSubscription>> ListBySubscriptionIdAsync(int subscriptionId)
        {
            return await _context.UserSubscriptions
                .Where(p => p.SubscriptionId == subscriptionId)
                .Include(p => p.Subscription)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSubscription>> ListByUserIdAsync(int userId)
        {
            return await _context.UserSubscriptions
                .Where(p => p.UserId == userId)
                .Include(p => p.Subscription)
                .Include(p => p.User)
                .ToListAsync();
        }

        public void Remove(UserSubscription userSubscription)
        {
            _context.UserSubscriptions.Remove(userSubscription);
        }

        public async void UnassignUserSubscription(int userId, int subscriptionId)
        {
            UserSubscription userSubscription = await FindByUserIdAndSubscriptionId(userId, subscriptionId);
            if (userSubscription != null)
            {
                Remove(userSubscription);
            }
        }
    }
}
