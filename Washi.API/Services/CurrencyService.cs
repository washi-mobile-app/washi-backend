using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;

namespace Washi.API.Services
{
    public class CurrencyService:ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICountryCurrencyRepository _countryCurrencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(ICurrencyRepository currencyRepository, ICountryCurrencyRepository countryCurrencyRepository, IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _countryCurrencyRepository = countryCurrencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task <Currency> GetByIdAsync(int id)
        {
            return await _currencyRepository.FindById(id);
        }

        public async Task<IEnumerable<Currency>> ListAsync()
        {
            return await _currencyRepository.ListAsync();
        }

        public async Task<IEnumerable<Currency>> ListByCountryIdAsync(int countryId)
        {
            var countryCurrencies = await _countryCurrencyRepository.ListByCountryIdAsync(countryId);
            var currencies = countryCurrencies.Select(p => p.Currency).ToList();
            return currencies;
        }
    }
}
