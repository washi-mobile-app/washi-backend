using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<IEnumerable<UserProfile>> ListLaundriesAsync();
        Task<IEnumerable<UserProfile>> ListLaundriesByDistrictIdAsync(int districtId);
        Task<UserProfileResponse> FindById(int userProfileId);
        Task<UserProfileResponse> SaveAsync(UserProfile profile);
        Task<UserProfileResponse> UpdateAsync(int id, UserProfile profile);
        Task<UserProfileResponse> DeleteAsync(int id);
    }
}