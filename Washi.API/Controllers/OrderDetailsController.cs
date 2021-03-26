using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
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
    public class OrderDetailsController:Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<OrderDetailResource>),200)]
        public async Task<IEnumerable<OrderDetailResource>>GetAllAsync()
        {
            var orderDetails = await _orderDetailService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailResource>>(orderDetails);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetAsync(int id)
        {
            var result = await _orderDetailService.FindById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderDetailResource = _mapper
                .Map<OrderDetail, OrderDetailResource>(result.Resource);
            return Ok(orderDetailResource);
        }
        [HttpGet("orders/{id}")]
        public async Task<IEnumerable<OrderDetailResource>> GetByOrderIdAsync(int id)
        {
            var orderDetails = await _orderDetailService.ListByOrderId(id);
            var resources = _mapper
                .Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailResource>>(orderDetails);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult>PostAsync([FromBody]SaveOrderDetailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var orderDetail = _mapper.Map<SaveOrderDetailResource, OrderDetail>(resource);
            var result = await _orderDetailService.SaveAsync(orderDetail);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderDetailResource = _mapper
                .Map<OrderDetail, OrderDetailResource>(result.Resource);
            return Ok(orderDetailResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderDetailResource resource)
        {
            var orderDetail = _mapper.Map<SaveOrderDetailResource, OrderDetail>(resource);
            var result = await _orderDetailService.UpdateAsync(id, orderDetail);

            if (!result.Success)
                return BadRequest(result.Message);
            var orderDetailResource = _mapper
                .Map<OrderDetail, OrderDetailResource>(result.Resource);
            return Ok(orderDetailResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAsync(int id)
        {
            var result = await _orderDetailService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderDetailResource = _mapper
                .Map<OrderDetail, OrderDetailResource>(result.Resource);
            return Ok(orderDetailResource);
        }
    }
}
