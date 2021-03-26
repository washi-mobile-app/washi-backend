using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;

namespace Washi.API.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryCurrencyRepository _countryCurrencyRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CountryService(ICountryRepository countryRepository, ICountryCurrencyRepository countryCurrencyRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _countryCurrencyRepository = countryCurrencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _countryRepository.ListAsync();
        }

        public async Task<IEnumerable<Country>> ListByCurrencyIdAsync(int currencyId)
        {
            var countryCurrencies = await _countryCurrencyRepository.ListByCurrencyIdAsync(currencyId);
            var countries = countryCurrencies.Select(p => p.Country).ToList();
            return countries;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _countryRepository.FindById(id);
        }
    }
}
