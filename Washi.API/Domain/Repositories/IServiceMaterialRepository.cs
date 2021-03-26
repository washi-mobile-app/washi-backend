using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IServiceMaterialRepository
    {
        Task<IEnumerable<ServiceMaterial>> ListAsync();
        Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId);
        Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId);
        Task<IEnumerable<Material>> ListMaterialsByServiceIdAsync(int serviceId);
        Task<ServiceMaterial> FindByServiceIdAndMaterialId(int serviceId, int materialId);
        Task<ServiceMaterial> FindById(int id);
    }
}
