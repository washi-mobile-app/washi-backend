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
    public class OrderDetailRepository : BaseRepository, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
        }

        public async Task<OrderDetail> FindById(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task<IEnumerable<OrderDetail>> ListAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> ListByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Include(od => od.Order)
                .ToListAsync();
        }

        public void Remove(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
        }

        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
        }
    }
}
