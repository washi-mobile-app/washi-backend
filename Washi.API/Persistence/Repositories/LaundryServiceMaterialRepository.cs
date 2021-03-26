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
    public class LaundryServiceMaterialRepository: BaseRepository, ILaundryServiceMaterialRepository
    {
        public LaundryServiceMaterialRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<LaundryServiceMaterial>> ListAsync()
        {
            return await _context.LaundryServiceMaterials.ToListAsync();
        }

        public async Task AddAsync(LaundryServiceMaterial laundryServiceMaterial)
        {
            await _context.AddAsync(laundryServiceMaterial);
        }

        public void Remove(LaundryServiceMaterial laundryServiceMaterial)
        {
            _context.LaundryServiceMaterials.Remove(laundryServiceMaterial);
        }

        public void Update(LaundryServiceMaterial laundryServiceMaterial)
        {
            _context.LaundryServiceMaterials.Update(laundryServiceMaterial);
        }

        public async Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServicesMaterialsByLaundryIdAsync(int laundryId)
        {
            return await _context.LaundryServiceMaterials
                .Where(p => p.LaundryId == laundryId)
                .Include(p => p.Laundry)
                .Include(p => p.ServiceMaterial)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesByLaundryServiceMaterialIdAsync(int laundryServiceMaterialId)
        {
            return await _context.UserProfiles.ToListAsync();
        }
        public async Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServiceMaterialsByServiceMaterialIdAsync(int serviceMaterialId)
        {
            return await _context.LaundryServiceMaterials.ToListAsync();
        }
        public async Task<LaundryServiceMaterial> FindByIdAsync(int id)
        {
            return await _context.LaundryServiceMaterials.FindAsync(id);
        }

    }
}
