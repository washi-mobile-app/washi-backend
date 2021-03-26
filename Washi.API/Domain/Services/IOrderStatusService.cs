using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IOrderStatusService
    {
        Task<IEnumerable<OrderStatus>> ListAsync();
        Task<OrderStatusResponse> GetByIdAsync(int id);
    }
}
