using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class UserSubscriptionResource
    {
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; }
    }
}
