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
    public class CurrencyRepository : BaseRepository, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context) { }

        public async Task<Currency> FindById(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task<IEnumerable<Currency>> ListAsync()
        {
            return await _context.Currencies.ToListAsync();
        }
    }
}
