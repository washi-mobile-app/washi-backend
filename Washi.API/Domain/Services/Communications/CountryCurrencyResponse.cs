using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class CountryCurrencyResponse:BaseResponse<CountryCurrency>
    {
        public CountryCurrencyResponse(CountryCurrency countryCurrency):base(countryCurrency)
        {
        }

        public CountryCurrencyResponse(string message) : base(message) { }
    }
}
