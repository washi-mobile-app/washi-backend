using AutoMapper;
using Microsoft.AspNetCore.Components;
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
    //[Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    public class CurrenciesController:Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CurrenciesController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CurrencyResource>> GetAllAsync()
        {
            var currencies = await _currencyService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Currency>, IEnumerable<CurrencyResource>>(currencies);
            return resources;
        }
    }
}
