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
    public class UserPaymentMethodRepository : BaseRepository, IUserPaymentMethodRepository
    {
        public UserPaymentMethodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserPaymentMethod userPaymentMethod)
        {
            await _context.UserPaymentMethods.AddAsync(userPaymentMethod);
        }

        public async Task AssignUserPaymentMethod(int userId, int paymentMethodId)
        {
            UserPaymentMethod userPaymentMethod = await FindByUserIdAndPaymentMethodId(userId, paymentMethodId);
            if(userPaymentMethod == null)
            {
                userPaymentMethod = new UserPaymentMethod { UserId = userId, PaymentMethodId = paymentMethodId };
                await AddAsync(userPaymentMethod);
            }
        }

        public async Task<UserPaymentMethod> FindByUserIdAndPaymentMethodId(int userId, int paymentMethodId)
        {
            return await _context.UserPaymentMethods.FindAsync(userId, paymentMethodId);
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListAsync()
        {
            return await _context.UserPaymentMethods
                .Include(p => p.User)
                .Include(p => p.PaymentMethod)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(int paymentMethodId)
        {
            return await _context.UserPaymentMethods
                .Where(p => p.PaymentMethodId == paymentMethodId)
                .Include(p => p.PaymentMethod)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(int userId)
        {
            return await _context.UserPaymentMethods
                .Where(p=>p.UserId == userId)
                .Include(p => p.PaymentMethod)
                .Include(p => p.User)
                .ToListAsync();
        }

        public void Remove(UserPaymentMethod userPaymentMethod)
        {
            _context.UserPaymentMethods.Remove(userPaymentMethod);
        }

        public async void UnassignUserPaymentMethod(int userId, int paymentMethodId)
        {
            UserPaymentMethod userPaymentMethod = await FindByUserIdAndPaymentMethodId(userId, paymentMethodId);
            if(userPaymentMethod != null)
            {
                Remove(userPaymentMethod);
            }
        }
    }
}
