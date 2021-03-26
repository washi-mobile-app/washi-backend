using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class UserSubscription
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}