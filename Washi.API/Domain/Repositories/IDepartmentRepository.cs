using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> FindByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<Department>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<Department>> ListAsync();
    }
}
