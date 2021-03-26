using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> ListAsync();
        Task AddAsync(Service service);
        Task<Service> FindByIdAsync(int id);
        void Update(Service service);
        void Remove(Service service);
    }
}
