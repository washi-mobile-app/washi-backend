using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class OrderResponse:BaseResponse<Order>
    {
        public OrderResponse(Order order) : base(order) { }
        public OrderResponse(string message) : base(message) { }
    }
}
