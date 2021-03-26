using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services;
using Washi.API.Extensions;
using Washi.API.Resources;

namespace Washi.API.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    [Route("/api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly AutoMapper.IMapper _mapper;

        public UserProfilesController(IUserProfileService profileService, AutoMapper.IMapper mapper)
        {
            _userProfileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
        {
            var userProfiles = await _userProfileService.ListAsync();
            var resource = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(userProfiles);
            return resource;
        }
        [HttpGet("laundries")]
        public async Task<IEnumerable<UserProfileResource>> GetLaundriesAsync()
        {
            var userProfiles = await _userProfileService.ListLaundriesAsync();
            var resource = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(userProfiles);
            return resource;
        }
        [HttpGet("districts/{districtId}/laundries")]
        public async Task<IEnumerable<UserProfileResource>> GetLaundriesByDistrictIdAsync(int districtId)
        {
            var userProfiles = await _userProfileService.ListLaundriesByDistrictIdAsync(districtId);
            var resource = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(userProfiles);
            return resource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _userProfileService.FindById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var userProfileResource = _mapper
                .Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var userProfile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);
            var result = await _userProfileService.SaveAsync(userProfile);

            if (!result.Success)
                return BadRequest(result.Message);

            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.UserProfile);
            return Ok(userProfileResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserProfileResource resource)
        {
            var userProfile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);
            var result = await _userProfileService.UpdateAsync(id, userProfile);

            if (!result.Success)
                return BadRequest(result.Message);

            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.UserProfile);
            return Ok(userProfileResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userProfileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.UserProfile);
            return Ok(userProfileResource);
        }
    }
}
