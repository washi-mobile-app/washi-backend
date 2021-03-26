using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;

namespace Washi.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Department> FindByIdAsync(int id)
        {
            return await _departmentRepository.FindByDepartmentIdAsync(id);
        }

        public async Task<IEnumerable<Department>> ListAsync()
        {
            return await _departmentRepository.ListAsync();
        }

        public async Task<IEnumerable<Department>> ListByCountryIdAsync(int countryId)
        {
            return await _departmentRepository.ListByCountryIdAsync(countryId);
        }
    }
}
