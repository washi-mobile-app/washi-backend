using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CountryCurrency> CountryCurrencies { get; set; }
        public IList<Department> Departments { get; set; } = new List<Department>();
        
    }
}
