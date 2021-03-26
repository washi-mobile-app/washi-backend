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
    public class PromotionRepository: BaseRepository, IPromotionRepository
    {
        public PromotionRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Promotion promotion)
        {
            await _context.Promotions.AddAsync(promotion);
        }

        public async Task<Promotion> FindById(int id)
        {
            return await _context.Promotions.FindAsync(id);
        }

        public async Task<IEnumerable<Promotion>> ListAsync()
        {
            return await _context.Promotions.ToListAsync();
        }

        public void Remove(Promotion promotion)
        {
            _context.Promotions.Remove(promotion);
        }

        public void Update(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
        }
    }
}
