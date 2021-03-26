using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> ListAsync();
        Task AddAsync(Promotion promotion);
        Task<Promotion> FindById(int id);
        void Update(Promotion promotion);
        void Remove(Promotion promotion);
    }
}
