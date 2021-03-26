using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;

namespace Washi.API.Services
{
    public class DistrictService: IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<District>> ListByDepartmentIdAsync(int departmentId)
        {
            return await _districtRepository.ListByDepartmentIdAsync(departmentId);
        }

        public async Task<IEnumerable<District>> ListAll()
        {
            return await _districtRepository.ListAsync();
        }

        public async Task<District> FindById(int id)
        {
            return await _districtRepository.FindByDistrictIdAsync(id);
        }
    }
}
