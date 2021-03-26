using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class PaymentMethodResponse : BaseResponse<PaymentMethod>
    {
        public PaymentMethodResponse(PaymentMethod resource) : base(resource)
        {
        }

        public PaymentMethodResponse(string message) : base(message)
        {
        }
    }
}
