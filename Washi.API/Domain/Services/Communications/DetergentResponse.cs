using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class DetergentResponse: BaseResponse<Detergent>
    {
        public DetergentResponse(Detergent resource) : base(resource)
        {
        }

        public DetergentResponse(string message) : base(message)
        {
        }
    }
}
