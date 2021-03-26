using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<OrderResource>),200)]
        public async Task<IEnumerable<OrderResource>>GetAllAsync()
        {
            var orders = await _orderService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetAsync(int id)
        {
            var result = await _orderService.FindByOrderId(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Order, OrderResource>(result.Resource);
            return Ok(orderResource);
        }
        [HttpGet("users/{id}")]
        public async Task<IEnumerable<OrderResource>>GetByUserIdAsync(int id)
        {
            var orders = await _orderService.ListByUserId(id);
            var resources = _mapper
                .Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }
        [HttpGet("users/{userId}/order-status/{orderStatusId}")]
        public async Task<IEnumerable<OrderResource>> GetByUserIdAndOrderStatusIdAsync(int userId, int orderStatusId)
        {
            var orders = await _orderService.ListByUserIdAndOrderStatusId(userId, orderStatusId);
            var resources = _mapper
                .Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }
        [HttpGet("laundries/{laundryId}")]
        public async Task<IEnumerable<OrderResource>> GetByLaundryId(int laundryId)
        {
            var orders = await _orderService.ListByLaundryId(laundryId);
            var resources = _mapper
                .Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult>PostAsync([FromBody]SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var order = _mapper.Map<SaveOrderResource, Order>(resource);
            var result = await _orderService.SaveAsync(order);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Order, OrderResource>(result.Resource);
            return Ok(orderResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
        {
            var order = _mapper.Map<SaveOrderResource, Order>(resource);
            var result = await _orderService.UpdateAsync(id, order);

            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Order, OrderResource>(result.Resource);
            return Ok(orderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _orderService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Order, OrderResource>(result.Resource);
            return Ok(orderResource);
        }
    }
}
