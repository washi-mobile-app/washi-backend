using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;

namespace Washi.API.Persistence.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesByDistrictIdAsync(int districtId)
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task AddAsync(UserProfile UserProfile)
        {
            await _context.UserProfiles.AddAsync(UserProfile);
        }

        public async Task<UserProfile> FindById(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public void Update(UserProfile UserProfile)
        {
            _context.UserProfiles.Update(UserProfile);
        }

        public void Remove(UserProfile UserProfile)
        {
            _context.UserProfiles.Remove(UserProfile);
        }

    }
}
