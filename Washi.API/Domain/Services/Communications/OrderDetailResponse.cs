using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class OrderDetailResponse:BaseResponse<OrderDetail>
    {
        public OrderDetailResponse(OrderDetail orderDetail) : base(orderDetail) { }
        public OrderDetailResponse(string message) : base(message) { }
    }
}
