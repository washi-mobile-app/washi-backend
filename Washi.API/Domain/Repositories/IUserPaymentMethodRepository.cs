using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IUserPaymentMethodRepository
    {
        Task<IEnumerable<UserPaymentMethod>> ListAsync();
        Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(int paymentMethodId);
        Task<UserPaymentMethod> FindByUserIdAndPaymentMethodId(int userId, int paymentMethodId);
        Task AddAsync(UserPaymentMethod userPaymentMethod);
        void Remove(UserPaymentMethod userPaymentMethod);
        Task AssignUserPaymentMethod(int userId, int paymentMethodId);
        void UnassignUserPaymentMethod(int userId, int paymentMethodId);
    }
}
