using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> ListByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<District>> ListAll();
        Task<District> FindById(int Id);
    }
}
