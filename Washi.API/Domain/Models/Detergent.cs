using System.Collections.Generic;

namespace Washi.API.Domain.Models
{
    public class Detergent
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public float Price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}