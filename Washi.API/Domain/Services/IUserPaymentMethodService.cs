using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IUserPaymentMethodService
    {
        Task<IEnumerable<UserPaymentMethod>> ListAsync();
        Task<IEnumerable<UserPaymentMethod>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserPaymentMethod>> ListByPaymentMethodIdAsync(int paymentMethodId);
        Task<UserPaymentMethodResponse> AssignUserPaymentMethodAsync(int userId, int paymentMethodId);
        Task<UserPaymentMethodResponse> UnassignUserPaymentMethodAsync(int userId, int paymentMethodId);
    }
}
