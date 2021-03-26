using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class CountryResponse:BaseResponse<Country>
    {
        public CountryResponse(Country country):base(country)
        { 
        }
        public CountryResponse(string message) : base(message) { }
    }
}
