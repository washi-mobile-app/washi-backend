using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class UserPaymentMethodResponse : BaseResponse<UserPaymentMethod>
    {
        public UserPaymentMethodResponse(UserPaymentMethod userPaymentMethod) : base(userPaymentMethod) { }
        public UserPaymentMethodResponse(string message) : base(message) { }
    }
}
