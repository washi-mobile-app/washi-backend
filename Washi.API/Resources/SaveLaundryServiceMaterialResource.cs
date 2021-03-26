using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SaveLaundryServiceMaterialResource
    {
        [Required]
        public int Id { get; set; }
        public int LaundryId { get; set; }
        public int ServiceMaterialId { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        public int EstimatedDeliveryTimeInDays { get; set; }
        public int Rating { get; set; }
    }
}
