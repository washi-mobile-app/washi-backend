using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class PromotionResponse : BaseResponse<Promotion>
    {
        public Promotion Promotion { get; private set; }

        public PromotionResponse(string message) : base(message) { }

        public PromotionResponse(Promotion promotion) : base(promotion) { }
    }
}
