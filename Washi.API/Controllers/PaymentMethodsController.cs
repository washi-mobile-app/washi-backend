using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    [Route("/api/[controller]")]
    public class PaymentMethodsController:Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IMapper _mapper;

        public PaymentMethodsController(IPaymentMethodService paymentMethodService, IMapper mapper)
        {
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all payment methods",
            Description = "List of payment methods",
            OperationId = "ListAllPaymentMethods",
            Tags = new[] { "PaymentMethods" })]
        [SwaggerResponse(200, "List of Payment Methods", typeof(IEnumerable<PaymentMethodResource>))]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PaymentMethodResource>), 200)]
        public async Task<IEnumerable<PaymentMethodResource>> GetAllAsync()
        {
            var paymentMethods = await _paymentMethodService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(paymentMethods);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _paymentMethodService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var paymentMethodResource = _mapper
                .Map<PaymentMethod, PaymentMethodResource>(result.Resource);
            return Ok(paymentMethodResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentMethodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var paymentMethod = _mapper.Map<SavePaymentMethodResource, PaymentMethod>(resource);
            var result = await _paymentMethodService.SaveAsync(paymentMethod);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentMethodResource = _mapper
                .Map<PaymentMethod, PaymentMethodResource>(result.Resource);
            return Ok(paymentMethodResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentMethodResource resource)
        {
            var paymentMethod = _mapper.Map<SavePaymentMethodResource, PaymentMethod>(resource);
            var result = await _paymentMethodService.UpdateAsync(id, paymentMethod);

            if (!result.Success)
                return BadRequest(result.Message);
            var paymentMethodResource = _mapper
                .Map<PaymentMethod, PaymentMethodResource>(result.Resource);
            return Ok(paymentMethodResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentMethodService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var paymentMethodResource = _mapper
                .Map<PaymentMethod, PaymentMethodResource>(result.Resource);
            return Ok(paymentMethodResource);
        }
    }
}
