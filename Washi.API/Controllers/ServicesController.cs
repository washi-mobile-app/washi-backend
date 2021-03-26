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
    [Route("/api/[controller]")]
    public class ServicesController:Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all services",
            Description = "List of services",
            OperationId = "ListAllServices",
            Tags = new[] { "Services" })]
        [SwaggerResponse(200, "List of Services", typeof(IEnumerable<ServiceResource>))]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ServiceResource>), 200)]
        public async Task<IEnumerable<ServiceResource>> GetAllAsync()
        {
            var services = await _serviceService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _serviceService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var serviceResource = _mapper
                .Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.SaveAsync(service);

            if (!result.Success)
                return BadRequest(result.Message);

            var serviceResource = _mapper
                .Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveServiceResource resource)
        {
            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.UpdateAsync(id, service);

            if (!result.Success)
                return BadRequest(result.Message);
            var serviceResource = _mapper
                .Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _serviceService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var serviceResource = _mapper
                .Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }
    }
}
