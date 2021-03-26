using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class CountryCurrencyResource
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CurrencyId { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
    }
}
