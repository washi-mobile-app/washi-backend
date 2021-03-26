using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PromotionService(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork)
        {
            _promotionRepository = promotionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Promotion>> ListAsync()
        {
            return await _promotionRepository.ListAsync();
        }

        public async Task<PromotionResponse> GetByIdAsync(int id)
        {
            var existingPromotion = await _promotionRepository.FindById(id);

            if (existingPromotion == null)
                return new PromotionResponse("Promotion not found");
            return new PromotionResponse(existingPromotion);
        }

        public async Task<PromotionResponse> SaveAsync(Promotion promotion)
        {
            try
            {
                await _promotionRepository.AddAsync(promotion);
                await _unitOfWork.CompleteAsync();

                return new PromotionResponse(promotion);
            }
            catch (Exception ex)
            {
                return new PromotionResponse($"An error ocurred while saving the promotion: {ex.Message}");
            }
        }

        public async Task<PromotionResponse> UpdateAsync(int id, Promotion promotion)
        {
            var existingPromotion = await _promotionRepository.FindById(id);

            if (existingPromotion == null)
                return new PromotionResponse("Promotion not found");

            existingPromotion.DiscountPercentage = promotion.DiscountPercentage;
            existingPromotion.InitialDate = promotion.InitialDate;
            existingPromotion.EndingDate = promotion.EndingDate;

            try
            {
                _promotionRepository.Update(existingPromotion);
                await _unitOfWork.CompleteAsync();

                return new PromotionResponse(existingPromotion);
            }
            catch (Exception ex)
            {
                return new PromotionResponse($"An error ocurred while updating promotion: {ex.Message}");
            }
        }
        public async Task<PromotionResponse> DeleteAsync(int id)
        {
            var existingPromotion = await _promotionRepository.FindById(id);

            if (existingPromotion == null)
                return new PromotionResponse("Promotion not found");

            try
            {
                _promotionRepository.Remove(existingPromotion);
                await _unitOfWork.CompleteAsync();

                return new PromotionResponse(existingPromotion);
            }
            catch (Exception ex)
            {
                return new PromotionResponse($"An error ocurred while deleting promotion: {ex.Message}");
            }
        }
    }
}
