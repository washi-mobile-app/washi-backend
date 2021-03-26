using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int LaundryServiceMaterialId { get; set; }
        public LaundryServiceMaterial LaundryServiceMaterial { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
