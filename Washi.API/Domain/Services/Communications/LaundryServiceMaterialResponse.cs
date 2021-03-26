using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
        public class LaundryServiceMaterialResponse : BaseResponse<LaundryServiceMaterial>
        {
            public LaundryServiceMaterial LaundryServiceMaterial { get; private set; }

            public LaundryServiceMaterialResponse(string message) : base(message) { }

            public LaundryServiceMaterialResponse(LaundryServiceMaterial laundryServiceMaterial) : base(laundryServiceMaterial) { }
        }
}
