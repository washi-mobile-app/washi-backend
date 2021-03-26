using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethod>> ListAsync();
        Task<IEnumerable<PaymentMethod>> ListByUserIdAsync(int userId);
        Task<PaymentMethodResponse> GetByIdAsync(int id);
        Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod);
        Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentMethod);
        Task<PaymentMethodResponse> DeleteAsync(int id);
    }
}
