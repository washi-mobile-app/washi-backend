using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    public interface ICurrencyService
    {
        Task<Currency> GetByIdAsync(int id);
        Task<IEnumerable<Currency>> ListAsync();
        Task<IEnumerable<Currency>> ListByCountryIdAsync(int countryId);
    }
}
