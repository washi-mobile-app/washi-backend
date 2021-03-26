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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<OrderDetailResponse> DeleteAsync(int id)
        {
            var existingOrderDetail = await _orderDetailRepository.FindById(id);
            if (existingOrderDetail == null)
                return new OrderDetailResponse("Order Detail not found");
            try 
            {
                _orderDetailRepository.Remove(existingOrderDetail);
                await _unitOfWork.CompleteAsync();
                return new OrderDetailResponse(existingOrderDetail);
            }
            catch (Exception ex)
            {
                return new OrderDetailResponse($"An error ocurred while deleting order detail: {ex.Message}");
            }
        }

        public async Task<OrderDetailResponse> FindById(int id)
        {
            var existingOrderDetail = await _orderDetailRepository.FindById(id);
            if (existingOrderDetail == null)
                return new OrderDetailResponse("Order Detail not found");
            return new OrderDetailResponse(existingOrderDetail);
        }

        public async Task<IEnumerable<OrderDetail>> ListAsync()
        {
            return await _orderDetailRepository.ListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> ListByOrderId(int orderId)
        {
            return await _orderDetailRepository.ListByOrderIdAsync(orderId);
        }

        public async Task<OrderDetailResponse> SaveAsync(OrderDetail orderDetail)
        {
            try
            {
                await _orderDetailRepository.AddAsync(orderDetail);
                await _unitOfWork.CompleteAsync();
                return new OrderDetailResponse(orderDetail);
            }
            catch (Exception ex)
            {
                return new OrderDetailResponse($"An error ocurred while saving the order detail: {ex.Message}");
            }
        }

        public async Task<OrderDetailResponse> UpdateAsync(int id, OrderDetail orderDetail)
        {
            var existingOrderDetail = await _orderDetailRepository.FindById(id);
            if (existingOrderDetail == null)
                return new OrderDetailResponse("Order Detail not found");

            existingOrderDetail.Rating = orderDetail.Rating;

            try
            {
                _orderDetailRepository.Update(existingOrderDetail);
                await _unitOfWork.CompleteAsync();

                return new OrderDetailResponse(existingOrderDetail);
            }
            catch (Exception ex)
            {
                return new OrderDetailResponse($"An error ocurred while updateing Order Detail: {ex.Message}");
            }
        }
    }
}
