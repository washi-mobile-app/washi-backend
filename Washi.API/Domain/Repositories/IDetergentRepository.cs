using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IDetergentRepository
    {
        Task<IEnumerable<Detergent>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Detergent>> ListAsync();
        Task AddAsync(Detergent detergent);
        void Update(Detergent detergent);
        void Remove(Detergent detergent);
    }
}
