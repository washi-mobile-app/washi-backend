using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IDistrictRepository
    {
        Task<District> FindByDistrictIdAsync(int districtId);
        Task<IEnumerable<District>> ListByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<District>> ListAsync();
    }
}
