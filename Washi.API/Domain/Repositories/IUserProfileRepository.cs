using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<IEnumerable<UserProfile>> ListLaundriesAsync();
        Task<IEnumerable<UserProfile>> ListLaundriesByDistrictIdAsync(int districtId);
        Task AddAsync(UserProfile profile);
        Task<UserProfile> FindById(int id);
        void Update(UserProfile profile);
        void Remove(UserProfile profile);
    }
}