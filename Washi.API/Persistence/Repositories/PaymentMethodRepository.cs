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
    public class PaymentMethodRepository : BaseRepository, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddSync(PaymentMethod paymentMethod)
        {
            await _context.AddAsync(paymentMethod);
        }

        public async Task<PaymentMethod> FindById(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentMethod>> ListAsync()
        {
            var methods = await _context.PaymentMethods.ToListAsync();
            return methods;
        }

        public void Remove(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Remove(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Update(paymentMethod);
        }
    }
}
