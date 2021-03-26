using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class LaundryServiceMaterial
    {
        public int Id { get; set; }
        public int LaundryId { get; set; }
        public User Laundry { get; set; }
        public int ServiceMaterialId { get; set; }
        public ServiceMaterial ServiceMaterial { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public int EstimatedDeliveryTimeInDays { get; set; }
        public int Rating { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
