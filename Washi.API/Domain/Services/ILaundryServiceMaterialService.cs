using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface ILaundryServiceMaterialService
    {
        Task<IEnumerable<LaundryServiceMaterial>> ListAsync();
        Task<LaundryServiceMaterialResponse> AddAsync(LaundryServiceMaterial laundryServiceMaterial);
        Task<LaundryServiceMaterialResponse> DeleteAsync(int id);
        Task<LaundryServiceMaterialResponse> UpdateAsync(int id, LaundryServiceMaterial laundryServiceMaterial);
        Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServicesMaterialsByLaundryIdAsync(int laundryId);
        Task<IEnumerable<UserProfile>> ListLaundriesByLaundryServiceMaterialIdAsync(int laundryServiceMaterialId);
        Task<IEnumerable<UserProfile>> ListLaundriesByServiceMaterialIdAsync(int serviceMaterialId);
        Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServiceMaterialsByServiceMaterialIdAsync(int serviceMaterialId);
        Task<LaundryServiceMaterialResponse> GetById(int id);
        Task<IEnumerable<UserProfile>> ListLaundriesByServiceMaterialIdAndDistrictIdAsync(int serviceMaterialId, int districtId);
        Task<LaundryServiceMaterialResponse> GetByLaundryIdAndServiceMaterialId(int laundryId, int serviceMaterialId);
    }
}