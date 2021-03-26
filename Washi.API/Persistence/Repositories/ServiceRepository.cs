using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;
using Washi.API.Persistence.Repositories;

namespace Washi.API.Repositories
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }

        public async Task<Service> FindByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            var services = await _context.Services.ToListAsync();
            return services;
        }

        public void Remove(Service service)
        {
            _context.Services.Remove(service);
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
        }
    }
}
