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
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<Order> FindById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> ListByUserIdAsync(int userId) =>
            await _context.Orders
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();

        public async Task<IEnumerable<Order>> ListByUserIdAndOrderStatusIdAsync(int userId, int orderStatusId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Where(o => o.OrderStatusId == orderStatusId)
                .Include(o => o.User)
                .Include(o => o.OrderStatus)
                .ToListAsync();
        }
            
        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
