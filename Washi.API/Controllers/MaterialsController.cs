using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class MaterialsController:Controller
    {
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;

        public MaterialsController(IMaterialService materialService, IMapper mapper)
        {
            _materialService = materialService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all materials",
            Description = "List of materials",
            OperationId = "ListAllMaterials",
            Tags = new[] { "Materials" })]
        [SwaggerResponse(200, "List of Materials", typeof(IEnumerable<MaterialResource>))]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<MaterialResource>), 200)]
        public async Task<IEnumerable<MaterialResource>> GetAllAsync()
        {
            var materials = await _materialService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Material>, IEnumerable<MaterialResource>>(materials);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _materialService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var materialResource = _mapper
                .Map<Material, MaterialResource>(result.Resource);
            return Ok(materialResource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMaterialResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var material = _mapper.Map<SaveMaterialResource, Material>(resource);
            var result = await _materialService.SaveAsync(material);

            if (!result.Success)
                return BadRequest(result.Message);

            var materialResource = _mapper
                .Map<Material, MaterialResource>(result.Resource);
            return Ok(materialResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMaterialResource resource)
        {
            var material = _mapper.Map<SaveMaterialResource, Material>(resource);
            var result = await _materialService.UpdateAsync(id, material);

            if (!result.Success)
                return BadRequest(result.Message);
            var materialResource = _mapper
                .Map<Material, MaterialResource>(result.Resource);
            return Ok(materialResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _materialService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var materialResource = _mapper
                .Map<Material, MaterialResource>(result.Resource);
            return Ok(materialResource);
        }
    }
}
