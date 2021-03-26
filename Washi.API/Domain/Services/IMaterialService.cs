using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> ListAsync();
        Task<MaterialResponse> GetByIdAsync(int id);
        Task<MaterialResponse> SaveAsync(Material material);
        Task<MaterialResponse> UpdateAsync(int id, Material material);
        Task<MaterialResponse> DeleteAsync(int id);
    }
}
