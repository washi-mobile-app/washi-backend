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
    [Route("/api")]
    public class ServiceMaterialsController: Controller
    {
        private readonly IServiceMaterialService _serviceMaterialService;
        private readonly IMapper _mapper;

        public ServiceMaterialsController(IServiceMaterialService serviceMaterialService, IMapper mapper)
        {
            _serviceMaterialService = serviceMaterialService;
            _mapper = mapper;
        }
        [HttpGet("servicematerials")]
        public async Task<IEnumerable<ServiceMaterialResource>> GetAllAsync()
        {
            var serviceMaterials = await _serviceMaterialService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<ServiceMaterial>, IEnumerable<ServiceMaterialResource>>(serviceMaterials);
            return resources;
        }

        [HttpGet("servicematerials/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _serviceMaterialService.GetByServiceMaterialId(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var serviceMaterialResource = _mapper
                .Map<ServiceMaterial, ServiceMaterialResource>(result.Resource);
            return Ok(serviceMaterialResource);
        }

        [HttpGet("services/{serviceId}/materials")]
        public async Task<IEnumerable<MaterialResource>> GetAllMaterialsByServiceIdAsync(int serviceId)
        {
            var materials = await _serviceMaterialService.ListMaterialsByServiceIdAsync(serviceId);
            var resources = _mapper
                .Map<IEnumerable<Material>, IEnumerable<MaterialResource>>(materials);
            return resources;
        }
        [HttpGet("services/{serviceId}/materials/{materialId}")]
        public async Task<IActionResult> GetServiceMaterialByServiceIdAndMaterialIdAsync(int serviceId, int materialId)
        {
            var result = await _serviceMaterialService.GetByServiceIdAndMaterialId(serviceId, materialId);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper
                .Map<ServiceMaterial, ServiceMaterialResource>(result.Resource);
            return Ok(resource);
        }
    }
}
