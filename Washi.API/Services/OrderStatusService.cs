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
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        public readonly IUnitOfWork _unitOfWork;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository, IUnitOfWork unitOfWork)
        {
            _orderStatusRepository = orderStatusRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderStatus>> ListAsync()
        {
            return await _orderStatusRepository.ListAsync();
        }

        public async Task<OrderStatusResponse> GetByIdAsync(int id)
        {
            var existingOrder = await _orderStatusRepository.FindById(id);

            if (existingOrder == null)
                return new OrderStatusResponse("Order not found");
            return new OrderStatusResponse(existingOrder);
        }
    }
}
