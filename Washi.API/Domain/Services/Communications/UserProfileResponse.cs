using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class UserProfileResponse : BaseResponse<UserProfile>
    {
        public UserProfile UserProfile { get; private set; }

        public UserProfileResponse(string message) : base(message) { }

        public UserProfileResponse(UserProfile profile) : base(profile) { }
    }
}
