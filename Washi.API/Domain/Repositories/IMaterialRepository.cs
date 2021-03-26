using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> ListAsync();
        Task AddAsync(Material material);
        Task<Material> FindByIdAsync(int id);
        void Update(Material material);
        void Remove(Material material);
    }
}
