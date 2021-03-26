using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    public class OrderStatusesController : Controller
    {
        private readonly IOrderStatusService _orderStatusService;
        private readonly IMapper _mapper;

        public OrderStatusesController(IOrderStatusService orderStatusService, IMapper mapper)
        {
            _orderStatusService = orderStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<OrderResource>), 200)]
        public async Task<IEnumerable<OrderStatusResource>> GetAllAsync()
        {
            var orderStatuses = await _orderStatusService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusResource>>(orderStatuses);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetAsync(int id)
        {
            var result = await _orderStatusService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderStatusResource = _mapper
                .Map<OrderStatus, OrderStatusResource>(result.Resource);
            return Ok(orderStatusResource);
        }
    }
}
