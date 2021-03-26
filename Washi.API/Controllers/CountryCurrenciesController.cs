using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    //[Route("/api/countries/{countryId}/currencies")]
    public class CountryCurrenciesController:Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CountryCurrenciesController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CurrencyResource>>GetAllByCountryIdAsync(int countryId)
        {
            var currencies = await _currencyService.ListByCountryIdAsync(countryId);
            var resources = _mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyResource>>(currencies);
            return resources;
        }
    }
}
