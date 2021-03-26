using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Services
{
    public class ServiceMaterialService : IServiceMaterialService
    {
        private readonly IServiceMaterialRepository _serviceMaterialRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceMaterialService(IMaterialRepository materialRepository, IServiceMaterialRepository serviceMaterialRepository, IUnitOfWork unitOfWork)
        {
            _serviceMaterialRepository = serviceMaterialRepository;
            _unitOfWork = unitOfWork;
            _materialRepository = materialRepository;
        }

        public async Task<ServiceMaterialResponse> GetByServiceIdAndMaterialId(int serviceId, int materialId)
        {
            var allServiceMaterials = await _serviceMaterialRepository.ListAsync();
            int serviceMaterialId = 0;
            foreach (var sm in allServiceMaterials)
            {
                if (sm.ServiceId == serviceId && sm.MaterialId == materialId)
                    serviceMaterialId = sm.Id;
            }
            var serviceMaterial = await _serviceMaterialRepository.FindById(serviceMaterialId);

            if (serviceMaterial == null)
                return new ServiceMaterialResponse("ServiceMaterial not found");
            return new ServiceMaterialResponse(serviceMaterial);
        }

        public async Task<IEnumerable<ServiceMaterial>> ListAsync()
        {
            return await _serviceMaterialRepository.ListAsync();
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByMaterialIdAsync(int materialId)
        {
            return await _serviceMaterialRepository.ListByMaterialIdAsync(materialId);
        }
        public async Task<IEnumerable<Material>> ListMaterialsByServiceIdAsync(int serviceId)
        {
            var allMaterials = await _materialRepository.ListAsync();
            var serviceMaterialsByServiceId = await _serviceMaterialRepository.ListByServiceIdAsync(serviceId);
            var materialsByServiceId = new List<Material>();
            foreach (var sm in serviceMaterialsByServiceId)
            {
                materialsByServiceId.Add(sm.Material);
            }
            return materialsByServiceId;
        }

        public async Task<IEnumerable<ServiceMaterial>> ListByServiceIdAsync(int serviceId)
        {
            return await _serviceMaterialRepository.ListByServiceIdAsync(serviceId);
        }

        public async Task<ServiceMaterialResponse> GetByServiceMaterialId(int serviceMaterialId)
        {
            var existingServiceMaterial = await _serviceMaterialRepository.FindById(serviceMaterialId);

            if (existingServiceMaterial == null)
                return new ServiceMaterialResponse("ServiceMaterial not found");
            return new ServiceMaterialResponse(existingServiceMaterial);
        }
    }
}
