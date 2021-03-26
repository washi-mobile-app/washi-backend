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
    public class LaundryServiceMaterialService : ILaundryServiceMaterialService
    {
        private readonly ILaundryServiceMaterialRepository _laundryServiceMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserRepository _userRepository;

        public LaundryServiceMaterialService(ILaundryServiceMaterialRepository laundryServiceMaterialRepository, IUserProfileRepository userProfileRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _laundryServiceMaterialRepository = laundryServiceMaterialRepository;
            _unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
        }
        public async Task<LaundryServiceMaterialResponse> AddAsync(LaundryServiceMaterial laundryServiceMaterial)
        {
            try
            {
                await _laundryServiceMaterialRepository.AddAsync(laundryServiceMaterial);
                await _unitOfWork.CompleteAsync();
                return new LaundryServiceMaterialResponse(laundryServiceMaterial);
            }
            catch (Exception ex)
            {
                return new LaundryServiceMaterialResponse($"An error ocurred while saving laundryservicematerial: {ex.Message}");
            }
        }

        public async Task<IEnumerable<LaundryServiceMaterial>> ListAsync()
        {
            return await _laundryServiceMaterialRepository.ListAsync();
        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesByLaundryServiceMaterialIdAsync(int laundryServiceMaterialId)
        {
            var allProfiles = await _userProfileRepository.ListAsync();
            var laundries = new List<UserProfile>();
            foreach (var profile in allProfiles)
            {
                foreach (var LSM in await ListLaundryServicesMaterialsByLaundryIdAsync(profile.UserId))
                    if (LSM.Id == laundryServiceMaterialId)
                    {
                        laundries.Add(profile);
                    }
            }
            return laundries;
        }

        public async Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServiceMaterialsByServiceMaterialIdAsync(int serviceMaterialId)
        {
            var allLSMs = await _laundryServiceMaterialRepository.ListAsync();
            var laundryServiceMaterials = new List<LaundryServiceMaterial>();
            foreach (var lsm in allLSMs)
            {
                if (lsm.ServiceMaterialId == serviceMaterialId)
                {
                    laundryServiceMaterials.Add(lsm);
                }
            }
            return laundryServiceMaterials;

        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesByServiceMaterialIdAsync(int serviceMaterialId)
        {
            var allProfiles = await _userProfileRepository.ListAsync();
            var laundries = new List<UserProfile>();
            foreach (var profile in allProfiles)
            {
                foreach (var LSM in await ListLaundryServicesMaterialsByLaundryIdAsync(profile.UserId))
                    if (LSM.ServiceMaterialId == serviceMaterialId)
                    {
                        laundries.Add(profile);
                    }
            }
            return laundries;
        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesByServiceMaterialIdAndDistrictIdAsync(int serviceMaterialId, int districtId)
        {
            var allProfiles = await _userProfileRepository.ListAsync();
            var laundries = new List<UserProfile>();
            foreach (var profile in allProfiles)
            {
                if (profile.DistrictId == districtId)
                {
                    foreach (var LSM in await ListLaundryServicesMaterialsByLaundryIdAsync(profile.UserId))
                        if (LSM.ServiceMaterialId == serviceMaterialId)
                        {
                            laundries.Add(profile);
                        }
                }
            }
            return laundries;
        }

        public async Task<IEnumerable<LaundryServiceMaterial>> ListLaundryServicesMaterialsByLaundryIdAsync(int laundryId)
        {
            var allLSMs = await _laundryServiceMaterialRepository.ListAsync();
            var laundryServiceMaterials = new List<LaundryServiceMaterial>();
            foreach (var lsm in allLSMs)
            {
                    if (lsm.LaundryId == laundryId)
                    {
                        laundryServiceMaterials.Add(lsm);
                    }
            }
            return laundryServiceMaterials;

        }

        public async Task<LaundryServiceMaterialResponse> DeleteAsync(int id)
        {
            var existingLaundryServiceMaterial = await _laundryServiceMaterialRepository.FindByIdAsync(id);
            if (existingLaundryServiceMaterial == null)
                return new LaundryServiceMaterialResponse("LaundryServiceMaterial not found");
            try
            {
                _laundryServiceMaterialRepository.Remove(existingLaundryServiceMaterial);
                await _unitOfWork.CompleteAsync();
                return new LaundryServiceMaterialResponse(existingLaundryServiceMaterial);
            }
            catch (Exception ex)
            {
                return new LaundryServiceMaterialResponse($"An error ocurred while deleting LaundryServiceMaterial: {ex.Message}");
            }
        }

        public async Task<LaundryServiceMaterialResponse> UpdateAsync(int id, LaundryServiceMaterial laundryServiceMaterial)
        {
            var existingLaundryServiceMaterial = await _laundryServiceMaterialRepository.FindByIdAsync(id);
            if (existingLaundryServiceMaterial == null)
                return new LaundryServiceMaterialResponse("LaundryServiceMaterial not found");
            existingLaundryServiceMaterial.Price = laundryServiceMaterial.Price;
            existingLaundryServiceMaterial.Rating = laundryServiceMaterial.Rating;
            existingLaundryServiceMaterial.Description = laundryServiceMaterial.Description;
            existingLaundryServiceMaterial.EstimatedDeliveryTimeInDays = laundryServiceMaterial.EstimatedDeliveryTimeInDays;
            try
            {
                _laundryServiceMaterialRepository.Update(existingLaundryServiceMaterial);
                await _unitOfWork.CompleteAsync();
                return new LaundryServiceMaterialResponse(existingLaundryServiceMaterial);
            }
            catch (Exception ex)
            {
                return new LaundryServiceMaterialResponse($"An error ocurred while updating LaundryServiceMaterial: {ex.Message}");
            }
        }
        public async Task<LaundryServiceMaterialResponse> GetById(int id)
        {
            var existingLaundryServiceMaterial = await _laundryServiceMaterialRepository.FindByIdAsync(id);

            if (existingLaundryServiceMaterial == null)
                return new LaundryServiceMaterialResponse("LaundryServiceMaterial not found");
            return new LaundryServiceMaterialResponse(existingLaundryServiceMaterial);
        }
        public async Task<LaundryServiceMaterialResponse> GetByLaundryIdAndServiceMaterialId(int laundryId, int serviceMaterialId)
        {
            var allLaundryServiceMaterials = await _laundryServiceMaterialRepository.ListAsync();
            int laundryServiceMaterialId = 0;
            foreach (var lsm in allLaundryServiceMaterials)
            {
                if (lsm.LaundryId == laundryId && lsm.ServiceMaterialId == serviceMaterialId)
                    laundryServiceMaterialId = lsm.Id;
            }
            var laundryServiceMaterial = await _laundryServiceMaterialRepository.FindByIdAsync(laundryServiceMaterialId);

            if (laundryServiceMaterial == null)
                return new LaundryServiceMaterialResponse("LaundryServiceMaterial not found");
            return new LaundryServiceMaterialResponse(laundryServiceMaterial);
        }
    }
}
