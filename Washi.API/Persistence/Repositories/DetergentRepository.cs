using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;
using Washi.API.Persistence.Repositories;

namespace Washi.API.Persistence.Repositories
{
    public class DetergentRepository : BaseRepository, IDetergentRepository
    {
        public DetergentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Detergent detergent)
        {
            await _context.Detergent.AddAsync(detergent);
        }

        public async Task<IEnumerable<Detergent>> ListAsync()
        {
            var detergent = await _context.Detergent.ToListAsync();
            return detergent;
        }

        public async Task<IEnumerable<Detergent>> ListByUserIdAsync(int userId)
        {
            return await _context.Detergent
                .Where(u => u.UserId == userId)
                .Include(u => u.User)
                .ToListAsync();
        }

        public void Remove(Detergent detergent)
        {
            _context.Detergent.Remove(detergent);
        }

        public void Update(Detergent detergent)
        {
            _context.Detergent.Update(detergent);
        }
    }
}
