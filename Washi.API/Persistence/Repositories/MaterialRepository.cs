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
    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Material material)
        {
            await _context.AddAsync(material);
        }

        public async Task<Material> FindByIdAsync(int id)
        {
            return await _context.Materials.FindAsync(id);
        }

        public async Task<IEnumerable<Material>> ListAsync()
        {
            var materials = await _context.Materials.ToListAsync();
            return materials;
        }

        public void Remove(Material material)
        {
            _context.Materials.Remove(material);
        }

        public void Update(Material material)
        {
            _context.Materials.Update(material);
        }
    }
}
