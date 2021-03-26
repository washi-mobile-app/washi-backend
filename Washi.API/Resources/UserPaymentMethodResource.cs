using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class UserPaymentMethodResource
    {
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
