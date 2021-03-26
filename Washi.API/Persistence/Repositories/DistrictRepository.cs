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
    public class DistrictRepository : BaseRepository, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context) { }
        public async Task<District> FindByDistrictIdAsync(int districtId)
        {
            return await _context.Districts.FindAsync(districtId);
        }

        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _context.Districts.ToListAsync();
        }

        public async Task<IEnumerable<District>> ListByDepartmentIdAsync(int departmentId) =>
            await _context.Districts
                .Where(p => p.DepartmentId == departmentId)
                .Include(p => p.Department)
                .ToListAsync();
    }
}
