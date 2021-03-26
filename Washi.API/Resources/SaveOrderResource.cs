using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        public string DeliveryAddress { get; set; }
        public double OrderAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime DeliveryDate { get; set; }
    }
}
