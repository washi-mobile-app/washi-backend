using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services
{
    interface ICountryCurrencyService
    {
        Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId);
        Task<IEnumerable<CountryCurrency>> ListByCountryIdAndCurrencyIdAsync(int countryId, int currencyId);
        Task<CountryCurrency> FindByCountryCurrencyId(int countryCurrencyId);
        Task<IEnumerable<CountryCurrency>> ListAsync();
    }
}
