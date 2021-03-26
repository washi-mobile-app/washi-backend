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
    public class CountryCurrencyRepository : BaseRepository, ICountryCurrencyRepository
    {
        public CountryCurrencyRepository(AppDbContext context) : base(context) { }
        public async Task<CountryCurrency> FindByCountryCurrencyId(int countryCurrencyId)
        {
            return await _context.CountryCurrencies.FindAsync(countryCurrencyId);
        }

        public async Task<IEnumerable<CountryCurrency>> FindByCountryIdAndCurrencyId(int countryId, int currencyId)
        {
            return await _context.CountryCurrencies
                 .Where(cc => cc.CountryId == countryId)
                 .Where(cc => cc.CurrencyId == currencyId)
                 .Include(cc=>cc.Country)
                 .Include(cc=>cc.Currency)
                 .ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListAsync()
        {
            return await _context.CountryCurrencies.ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId)
        {
            return await _context.CountryCurrencies
                .Where(cc => cc.CountryId == countryId)
                .Include(cc => cc.Country)
                .Include(cc => cc.Currency)
                .ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId)
        {
            return await _context.CountryCurrencies
                .Where(cc => cc.CurrencyId == currencyId)
                .Include(cc => cc.Country)
                .Include(cc => cc.Currency)
                .ToListAsync();
        }
    }
}
