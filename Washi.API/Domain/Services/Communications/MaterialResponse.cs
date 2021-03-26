using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class MaterialResponse : BaseResponse<Material>
    {
        public MaterialResponse(Material resource) : base(resource)
        {
        }

        public MaterialResponse(string message) : base(message)
        {
        }
    }
}
