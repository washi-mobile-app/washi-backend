using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> ListAsync();
        Task<IEnumerable<OrderDetail>> ListByOrderId(int orderId);
        Task<OrderDetailResponse> FindById(int id);
        Task<OrderDetailResponse> UpdateAsync(int id, OrderDetail orderDetail);
        Task<OrderDetailResponse> DeleteAsync(int id);
        Task<OrderDetailResponse> SaveAsync(OrderDetail orderDetail);
    }
}
