using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> ListAsync();
        Task<PromotionResponse> GetByIdAsync(int id);
        Task<PromotionResponse> SaveAsync(Promotion promotion);
        Task<PromotionResponse> UpdateAsync(int id, Promotion promotion);
        Task<PromotionResponse> DeleteAsync(int id);
    }
}
