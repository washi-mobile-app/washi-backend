﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Domain.Services
{
    interface IDetergentService
    {
        Task<DetergentResponse> GetByIdAsync(int id);
        Task<IEnumerable<Detergent>> ListAsync();
        Task<IEnumerable<Detergent>> ListByUserIdAsync(int laundryId);
        Task<DetergentResponse> SaveAsync(Detergent detergent);
        Task<DetergentResponse> UpdateAsync(int id, Detergent detergent);
        Task<DetergentResponse> DeleteAsync(int id);
        Task AddAsync(Detergent detergent);
    }
}
