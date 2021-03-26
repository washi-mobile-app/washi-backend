using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task AddSync(Subscription subscription);
        Task<Subscription> FindById(int id);
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
    }
}