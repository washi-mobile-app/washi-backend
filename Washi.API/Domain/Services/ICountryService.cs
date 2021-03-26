using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<Country> GetByIdAsync(int id);
        Task<IEnumerable<Country>> ListByCurrencyIdAsync(int currencyId);
    }
}
