using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace Washi.API.Controllers
{
    [Route("/api/[controller]")]
    public class PromotionsController : Controller
    {
        private readonly IPromotionService _promotionService;
        private readonly IMapper _mapper;

        public PromotionsController(IPromotionService promotionService, IMapper mapper)
        {
            _promotionService = promotionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all promotions",
            Description = "List of promotions",
            OperationId = "ListAllPromotions",
            Tags = new[] { "Promotions" })]
        [SwaggerResponse(200, "List of Promotions", typeof(IEnumerable<PromotionResource>))]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PromotionResource>), 200)]
        public async Task<IEnumerable<PromotionResource>> GetAllAsync()
        {
            var promotions = await _promotionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Promotion>, IEnumerable<PromotionResource>>(promotions);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _promotionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var promotionResource = _mapper
                .Map<Promotion, PromotionResource>(result.Resource);
            return Ok(promotionResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePromotionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var promotion = _mapper.Map<SavePromotionResource, Promotion>(resource);
            var result = await _promotionService.SaveAsync(promotion);

            if (!result.Success)
                return BadRequest(result.Message);

            var promotionResource = _mapper
                .Map<Promotion, PromotionResource>(result.Resource);
            return Ok(promotionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePromotionResource resource)
        {
            var promotion = _mapper.Map<SavePromotionResource, Promotion>(resource);
            var result = await _promotionService.UpdateAsync(id, promotion);

            if (!result.Success)
                return BadRequest(result.Message);
            var promotionResource = _mapper
                .Map<Promotion, PromotionResource>(result.Resource);
            return Ok(promotionResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _promotionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var promotionResource = _mapper
                .Map<Promotion, PromotionResource>(result.Resource);
            return Ok(promotionResource);
        }
    }
}
