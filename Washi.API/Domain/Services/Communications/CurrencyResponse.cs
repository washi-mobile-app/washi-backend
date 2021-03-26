using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class CurrencyResponse:BaseResponse<Currency>
    {
        public CurrencyResponse(Currency currency):base(currency)
        {
        }
        public CurrencyResponse(string message) : base(message) { }
    }
}
