using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddSync(User user);
        Task<User> FindById(int id);
        void Update(User user);
        void Remove(User user);
        //Authentication
        Task<User> Authenticate(string email, string password);
    }
}