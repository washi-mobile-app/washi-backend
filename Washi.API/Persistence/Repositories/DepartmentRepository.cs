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
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context) { }
        public async Task<Department> FindByDepartmentIdAsync(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task<IEnumerable<Department>> ListAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<IEnumerable<Department>> ListByCountryIdAsync(int countryId) =>
            await _context.Departments
                .Where(p => p.CountryId == countryId)
                .Include(p => p.Country)
                .ToListAsync();
        
    }
}
