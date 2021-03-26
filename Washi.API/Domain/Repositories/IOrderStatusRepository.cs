using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IOrderStatusRepository
    {
        Task<OrderStatus> FindById(int id);
        Task<IEnumerable<OrderStatus>> ListAsync();
    }
}
