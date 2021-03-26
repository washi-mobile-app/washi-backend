using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SavePromotionResource
    {
        [Required]
        public int Id { get; set; }
        public int LaundryServiceMaterialId { get; set; }
        public int DiscountPercentage { get; set; }
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime EndingDate { get; set; }
    }
}
