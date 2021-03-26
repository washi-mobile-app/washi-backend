using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<IEnumerable<Order>> ListByUserId(int userId);
        Task<IEnumerable<Order>> ListByUserIdAndOrderStatusId(int userId, int orderStatusId);
        Task<IEnumerable<Order>> ListByLaundryId(int laundryId);
        Task<OrderResponse> FindByOrderId(int orderId);
        Task<OrderResponse> UpdateAsync(int id, Order order);
        Task<OrderResponse> DeleteAsync(int id);
        Task<OrderResponse> SaveAsync(Order order);
    }
}
