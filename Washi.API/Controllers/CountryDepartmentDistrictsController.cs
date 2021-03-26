using AutoMapper;
using Microsoft.AspNetCore.Components;
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
    //[Microsoft.AspNetCore.Mvc.Route("api/departments/{departmentId}/")]
    public class CountryDepartmentDistrictsController
    {
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public CountryDepartmentDistrictsController(IDistrictService districtService, IMapper mapper)
        {
            _districtService = districtService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DistrictResource>> GetAllByDepartmentIdAsync(int departmentId)
        {
            var districts = await _districtService.ListByDepartmentIdAsync(departmentId);
            var resources = _mapper
                .Map<IEnumerable<District>, IEnumerable<DistrictResource>>(districts);
            return resources;
        }
    }
}
