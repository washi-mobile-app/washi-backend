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
    //[Microsoft.AspNetCore.Mvc.Route("/api/countries/{countryId}/departments")]
    public class CountryDepartmentsController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public CountryDepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentResource>>GetAllByCountryIdAsync(int countryId)
        {
            var departments = await _departmentService.ListByCountryIdAsync(countryId);
            var resources = _mapper
                .Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);
            return resources;
        }
    }
}
