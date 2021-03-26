using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    [Route("/api/users/{userId}/paymentmethods")]
    public class UserPaymentMethodsController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IUserPaymentMethodService _userPaymentMethodService;
        private readonly IMapper _mapper;

        public UserPaymentMethodsController(IPaymentMethodService paymentMethodService, IMapper mapper, IUserPaymentMethodService userPaymentMethodService)
        {
            _mapper = mapper;
            _paymentMethodService = paymentMethodService;
            _userPaymentMethodService = userPaymentMethodService;
        }
        [HttpGet]
        public async Task<IEnumerable<PaymentMethodResource>> GetAllByUserIdAsync(int userId)
        {
            var paymentMethods = await _paymentMethodService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(paymentMethods);
            return resources;
        }
        [HttpPost("{paymentMethodId}")]
        public async Task<IActionResult> AssignUserPaymentMethod(int userId, int paymentMethodId)
        {
            var result = await _userPaymentMethodService.AssignUserPaymentMethodAsync(userId, paymentMethodId);
            if (!result.Success) return BadRequest(result.Message);
            var paymentMethodResource = _mapper.Map<PaymentMethod, PaymentMethodResource>(result.Resource.PaymentMethod);
            return Ok(paymentMethodResource);
        }
        [HttpDelete("{paymentMethodId}")]
        public async Task<IActionResult> UnassignUserPaymentMethod(int userId, int paymentMethodId)
        {
            var result = await _userPaymentMethodService.UnassignUserPaymentMethodAsync(userId, paymentMethodId);
            if (!result.Success)
                return BadRequest(result.Message);
            var paymentMethodResource = _mapper.Map<PaymentMethod, PaymentMethodResource>(result.Resource.PaymentMethod);
            return Ok(paymentMethodResource);
        }
    }
}
