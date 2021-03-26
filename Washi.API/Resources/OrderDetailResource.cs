using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class OrderDetailResource
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LaundryServiceMaterialId { get; set; }
        public int Rating { get; set; }
    }
}
