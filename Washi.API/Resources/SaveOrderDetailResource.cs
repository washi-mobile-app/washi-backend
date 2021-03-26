using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SaveOrderDetailResource
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int LaundryServiceMaterialId { get; set; }
        public int Rating { get; set; }
    }
}
