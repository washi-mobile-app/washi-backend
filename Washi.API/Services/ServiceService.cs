using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var existingService = await _serviceRepository.FindByIdAsync(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            try
            {
                _serviceRepository.Remove(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch(Exception ex)
            {
                return new ServiceResponse($"An error ocurred while deleting service: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var existingService = await _serviceRepository.FindByIdAsync(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            return new ServiceResponse(existingService);
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _serviceRepository.ListAsync();
        }

        public async Task<ServiceResponse> SaveAsync(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(service);
            }
            catch(Exception ex)
            {
                return new ServiceResponse($"An error ocurred while saving service: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int id, Service service)
        {
            var existingService = await _serviceRepository.FindByIdAsync(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            existingService.Name = service.Name;
            try
            {
                _serviceRepository.Update(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while updating service: {ex.Message}");
            }
        }
    }
}
