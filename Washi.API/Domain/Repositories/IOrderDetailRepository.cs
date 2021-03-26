using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> ListAsync();
        Task AddAsync(OrderDetail orderDetail);
        Task<OrderDetail> FindById(int id);
        Task<IEnumerable<OrderDetail>> ListByOrderIdAsync(int orderId);
        void Update(OrderDetail orderDetail);
        void Remove(OrderDetail orderDetail);
    }
}
