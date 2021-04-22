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
    [Route("/api")]
    public class DetergentController : Controller
    {
        private readonly IDetergentService _detergentService;
        private readonly IMapper _mapper;

        public DetergentController(IDetergentService detergentService, IMapper mapper)
        {
            _detergentService = detergentService;
            _mapper = mapper;
        }

        [HttpPost("detergent")]
        public async Task<IActionResult> PostAsync([FromBody] SaveDetergentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var detergent = _mapper.Map<SaveDetergentResource, Detergent>(resource);
            var result = await _detergentService.AddAsync(detergent);

            if (!result.Success)
                return BadRequest(result.Message);

            var detergentResource = _mapper
                .Map<Detergent, DetergentResource>(result.Resource);
            return Ok(detergentResource);
        }

        [HttpGet("detergent/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _detergentService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var detergentResource = _mapper
                .Map<Detergent, DetergentResource>(result.Resource);
            return Ok(detergentResource);
        }

        [HttpGet("detergents")]
        public async Task<IEnumerable<DetergentResource>> GetAllAsync()
        {
            var detergents = await _detergentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Detergent>, IEnumerable<DetergentResource>>(detergents);
            return resources;
        }

        [HttpGet("laundries/{laundryId}/detergents")]
        public async Task<IEnumerable<DetergentResource>> GetAllDetergentsByLaundryIdAsync(int laundryId)
        {
            var detergents = await _detergentService.ListByUserIdAsync(laundryId);
            var resources = _mapper
                .Map<IEnumerable<Detergent>, IEnumerable<DetergentResource>>(detergents);
            return resources;
        }

        [HttpPut("detergent/{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDetergentResource resource)
        {
            var detergent = _mapper.Map<SaveDetergentResource, Detergent>(resource);
            var result = await _detergentService.UpdateAsync(id, detergent);

            if (!result.Success)
                return BadRequest(result.Message);
            var detergentResource = _mapper
                .Map<Detergent, DetergentResource>(result.Resource);
            return Ok(detergentResource);
        }

        [HttpDelete("detergent/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _detergentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var detergentResource = _mapper
                .Map<Detergent, DetergentResource>(result.Resource);
            return Ok(detergentResource);
        }
    }
}