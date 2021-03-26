using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface ILaundryServiceMaterialRepository
    {
        Task<IEnumerable<LaundryServiceMaterial>> ListAsync();
        Task AddAsync(LaundryServiceMaterial laundryServiceMaterial);
        void Remove(LaundryServiceMaterial laundryServiceMaterial);
        void Update(LaundryServiceMaterial laundryServiceMaterial);
        Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServicesMaterialsByLaundryIdAsync(int laundryId);
        Task<IEnumerable<UserProfile>> ListLaundriesByLaundryServiceMaterialIdAsync(int laundryServiceMaterialId);
        Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServiceMaterialsByServiceMaterialIdAsync(int serviceMaterialId);
        Task<LaundryServiceMaterial> FindByIdAsync(int id);
    }
}
