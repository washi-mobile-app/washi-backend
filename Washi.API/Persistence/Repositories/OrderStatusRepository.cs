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
    public class OrderStatusRepository : BaseRepository, IOrderStatusRepository
    {
        public OrderStatusRepository(AppDbContext context) : base(context) { }
        public async Task<OrderStatus> FindById(int id)
        {
            return await _context.OrderStatuses.FindAsync(id);
        }

        public async Task<IEnumerable<OrderStatus>> ListAsync()
        {
            return await _context.OrderStatuses.ToListAsync();
        }
    }
}
