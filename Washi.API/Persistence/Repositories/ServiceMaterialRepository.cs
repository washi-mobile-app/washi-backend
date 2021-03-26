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
    public class ServiceMaterialRepository: BaseRepository, IServiceMaterialRepository
    {
        public ServiceMaterialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ServiceMaterial> FindByServiceIdAndMaterialId(int serviceId, int materialId)
        {
            return await _context.ServiceMaterials.FindAsync(serviceId, materialId);
        }

        public async Task<IEnumerable<ServiceMaterial>> ListAsync()
        {
            return await _context.ServiceMaterials
                .Include(sm => sm.Service)
                .Include(sm => sm.Material)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId)
        {
            return await _context.ServiceMaterials
                .Where(m => m.MaterialId == materialId)
                .Include(m => m.Material)
                .Include(m => m.Service)
                .ToListAsync();
        }
        public async Task<IEnumerable<Material>> ListMaterialsByServiceIdAsync(int serviceId)
        {
            return await _context.Materials.ToListAsync();
        }
        public async Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId)
        {
            return await _context.ServiceMaterials
                .Where(s => s.ServiceId == serviceId)
                .Include(s => s.Service)
                .Include(s => s.Material)
                .ToListAsync();
        }
        public async Task<ServiceMaterial> FindById(int id)
        {
            return await _context.ServiceMaterials.FindAsync(id);
        }

    }
}
