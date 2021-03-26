using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("/api/users/{userId}/subscriptions")]
    public class UserSubscriptionsController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserSubscriptionService _userSubscriptionService;
        private readonly IMapper _mapper;

        public UserSubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper, IUserSubscriptionService userSubscriptionService)
        {
            _mapper = mapper;
            _subscriptionService = subscriptionService;
            _userSubscriptionService = userSubscriptionService;
        }
        /*
        [HttpGet]
        public async Task<IEnumerable<SubscriptionResource>> GetAllByUserIdAsync(int userId)
        {
            var subscriptions = await _subscriptionService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }
        */
        [HttpGet]
        public async Task<IEnumerable<UserSubscriptionResource>> GetAllByUserIdAsync(int userId)
        {
            var userSubscriptions = await _userSubscriptionService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<UserSubscription>, IEnumerable<UserSubscriptionResource>>(userSubscriptions);
            return resources;
        }
        /*
        [HttpPost("{subscriptionId}")]
        public async Task<IActionResult> AssignUserSubscription(int userId, int subscriptionId)
        {
            var result = await _userSubscriptionService.AssignUserSubscriptionAsync(userId, subscriptionId);
            if (!result.Success) return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource.Subscription);
            return Ok(subscriptionResource);
        }
        */
        [HttpPost("{subscriptionId}")]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var userSubscription = _mapper.Map<SaveUserSubscriptionResource, UserSubscription>(resource);
            var result = await _userSubscriptionService.SaveAsync(userSubscription);

            if (!result.Success)
                return BadRequest(result.Message);

            var userSubscriptionResource = _mapper.Map<UserSubscription, UserSubscriptionResource>(result.UserSubscription);
            return Ok(userSubscriptionResource);
        }
        [HttpDelete("{subscriptionId}")]
        public async Task<IActionResult> UnassignUserSubscription(int userId, int subscriptionId)
        {
            var result = await _userSubscriptionService.UnassignUserSubscriptionAsync(userId, subscriptionId);
            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource.Subscription);
            return Ok(subscriptionResource);
        }
    }
}
