using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<Department>> ListAsync();
        Task<Department> FindByIdAsync(int id);
    }
}
