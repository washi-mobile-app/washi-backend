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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _userProfileRepository.ListAsync();
        }
        public async Task<IEnumerable<UserProfile>> ListLaundriesAsync()
        {
            var allProfiles = await _userProfileRepository.ListAsync();
            var laundries = new List<UserProfile>();
            foreach (var profile in allProfiles)
            {   
                if (profile.UserType==EUserType.Laundry)
                {
                    laundries.Add(profile);
                }
            }
            return laundries;
        }

        public async Task<IEnumerable<UserProfile>> ListLaundriesByDistrictIdAsync(int districtId)
        {
            var allProfiles = await _userProfileRepository.ListAsync();
            var laundries = new List<UserProfile>();
            foreach (var profile in allProfiles)
            {
                if (profile.UserType == EUserType.Laundry && profile.DistrictId == districtId)
                {
                    laundries.Add(profile);
                }
            }
            return laundries;
        }

        public async Task<UserProfileResponse> SaveAsync(UserProfile userProfile)
        {
            try
            {
                await _userProfileRepository.AddAsync(userProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(userProfile);
            }
            catch (Exception ex)
            {
                return new UserProfileResponse($"An error ocurred while saving the user profile: {ex.Message}");
            }
        }

        public async Task<UserProfileResponse> UpdateAsync(int id, UserProfile userProfile)
        {
            var existingUserProfile = await _userProfileRepository.FindById(id);

            if (existingUserProfile == null)
                return new UserProfileResponse("Profile not found");

            existingUserProfile.FirstName = userProfile.FirstName;
            existingUserProfile.UserId = userProfile.UserId;
            existingUserProfile.LastName = userProfile.LastName;
            existingUserProfile.DateOfBirth = userProfile.DateOfBirth;
            existingUserProfile.Sex = userProfile.Sex;
            existingUserProfile.DateOfRegistry = userProfile.DateOfRegistry;
            existingUserProfile.Address = userProfile.Address;
            existingUserProfile.PhoneNumber = userProfile.PhoneNumber;

            try
            {
                _userProfileRepository.Update(existingUserProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(existingUserProfile);
            }

            catch (Exception ex)
            {
                return new UserProfileResponse($"An error ocurred while updating user profile : {ex.Message}");
            }
        }

        public async Task<UserProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _userProfileRepository.FindById(id);

            if (existingProfile == null)
                return new UserProfileResponse("User profile not found");

            try
            {
                _userProfileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();
                return new UserProfileResponse(existingProfile);
            }

            catch (Exception ex)
            {
                return new UserProfileResponse($"An error ocurred while deleting user profile : {ex.Message}");
            }
        }

        public async Task<UserProfileResponse> FindById(int userProfileId)
        {
            var existingUserProfile = await _userProfileRepository.FindById(userProfileId);
            if (existingUserProfile == null)
                return new UserProfileResponse("User profile not found");
            return new UserProfileResponse(existingUserProfile);
        }
    }
}
