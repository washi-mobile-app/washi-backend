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
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all subscriptions",
            Description = "List of subscriptions",
            OperationId = "ListAllSubscriptions",
            Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "List of Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var subscriptions = await _subscriptionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _subscriptionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper
                .Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(subscription);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper
                .Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubscriptionResource resource)
        {
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(id, subscription);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper
                .Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper
                .Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }
    }
}
