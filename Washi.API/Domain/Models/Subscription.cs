using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }
    }
}