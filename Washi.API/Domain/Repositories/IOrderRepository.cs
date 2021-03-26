using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> ListAsync();
        Task AddAsync(Order order);
        Task<Order> FindById(int id);
        Task<IEnumerable<Order>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Order>> ListByUserIdAndOrderStatusIdAsync(int userId, int orderStatusId);
        void Update(Order order);
        void Remove(Order order);
    }
}
