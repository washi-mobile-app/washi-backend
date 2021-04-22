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
    public class DetergentService : IDetergentService
    {

        private readonly IDetergentRepository _detergentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<DetergentResponse> DeleteAsync(int id)
        {
            var existingDetergent = await _detergentRepository.FindByIdAsync(id);
            if (existingDetergent == null)
                return new DetergentResponse("Detergent not found");
            try
            {
                _detergentRepository.Remove(existingDetergent);
                await _unitOfWork.CompleteAsync();
                return new DetergentResponse(existingDetergent);
            }
            catch(Exception ex)
            {
                return new DetergentResponse($"An error ocurred while deleting service: {ex.Message}");
            }
        }

        public async Task<DetergentResponse> GetByIdAsync(int id)
        {
            var existingDetergent = await _detergentRepository.FindByIdAsync(id);
            if (existingDetergent == null)
                return new DetergentResponse("Detergent not found");
            return new DetergentResponse(existingDetergent);
        }

        public async Task<IEnumerable<Detergent>> ListAsync()
        {
            return await _detergentRepository.ListAsync(); 
        }

        public async Task<IEnumerable<Detergent>> ListByUserIdAsync(int LaundryId)
        {
            return await _detergentRepository.ListByUserIdAsync(LaundryId);
        }

        public async Task<DetergentResponse> SaveAsync(Detergent detergent)
        {
            try
            {
                await _detergentRepository.AddAsync(detergent);
                await _unitOfWork.CompleteAsync();
                return new DetergentResponse(detergent);
            }
            catch (Exception ex)
            {
                return new DetergentResponse($"An error ocurred while saving the order detail: {ex.Message}");
            }
        }

        public async Task<DetergentResponse> UpdateAsync(int id, Detergent detergent)
        {
            var existingDetergent = await _detergentRepository.FindByIdAsync(id);
            if (existingDetergent == null)
                return new DetergentResponse("Order Detail not found");

            try
            {
                _detergentRepository.Update(existingDetergent);
                await _unitOfWork.CompleteAsync();

                return new DetergentResponse(existingDetergent);
            }
            catch (Exception ex)
            {
                return new DetergentResponse($"An error ocurred while updateing Order Detail: {ex.Message}");
            }
        }
    }
}
