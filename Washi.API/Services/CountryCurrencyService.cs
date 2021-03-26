using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;

namespace Washi.API.Services
{
    public class CountryCurrencyService : ICountryCurrencyService
    {
        private readonly ICountryCurrencyRepository _countryCurrencyRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public CountryCurrencyService(ICountryCurrencyRepository countryCurrencyRepository, IUnitOfWork unitOfWork)
        {
            _countryCurrencyRepository = countryCurrencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryCurrency> FindByCountryCurrencyId(int countryCurrencyId)
        {
            return await _countryCurrencyRepository.FindByCountryCurrencyId(countryCurrencyId);
        }

        public async Task<IEnumerable<CountryCurrency>> ListAsync()
        {
            return await _countryCurrencyRepository.ListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCountryIdAndCurrencyIdAsync(int countryId, int currencyId)
        {
            return await _countryCurrencyRepository.FindByCountryIdAndCurrencyId(countryId, currencyId);
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId)
        {
            return await _countryCurrencyRepository.ListByCountryIdAsync(countryId);
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId)
        {
            return await _countryCurrencyRepository.ListByCurrencyIdAsync(currencyId);
        }
    }
}
