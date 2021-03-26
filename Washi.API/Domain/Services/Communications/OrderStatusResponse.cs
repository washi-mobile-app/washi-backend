using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class OrderStatusResponse:BaseResponse<OrderStatus>
    {
        public OrderStatusResponse(OrderStatus orderStatus) : base(orderStatus) { }
        public OrderStatusResponse(string message) : base(message) { }

    }
}
