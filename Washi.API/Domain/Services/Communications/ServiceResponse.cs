using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class ServiceResponse : BaseResponse<Service>
    {
        public ServiceResponse(Service resource) : base(resource)
        {
        }

        public ServiceResponse(string message) : base(message)
        {
        }
    }
}
