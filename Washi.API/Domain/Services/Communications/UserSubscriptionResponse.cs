using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class UserSubscriptionResponse : BaseResponse<UserSubscription>
    {
        public UserSubscription UserSubscription { get; private set; }
        public UserSubscriptionResponse(UserSubscription userSubscription) : base(userSubscription) { }
        public UserSubscriptionResponse(string message) : base(message) { }
    }
}
