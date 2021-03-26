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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialService(IMaterialRepository materialRepository, IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MaterialResponse> DeleteAsync(int id)
        {
            var existingMaterial = await _materialRepository.FindByIdAsync(id);
            if (existingMaterial == null)
                return new MaterialResponse("Material not found");
            try
            {
                _materialRepository.Remove(existingMaterial);
                await _unitOfWork.CompleteAsync();
                return new MaterialResponse(existingMaterial);
            }
            catch (Exception ex)
            {
                return new MaterialResponse($"An error ocurred whil deleting material: {ex.Message}");
            }
        }

        public async Task<MaterialResponse> GetByIdAsync(int id)
        {
            var existingMaterial = await _materialRepository.FindByIdAsync(id);
            if (existingMaterial == null)
                return new MaterialResponse("Material not found");
            return new MaterialResponse(existingMaterial);
        }

        public async Task<IEnumerable<Material>> ListAsync()
        {
            return await _materialRepository.ListAsync();
        }

        public async Task<MaterialResponse> SaveAsync(Material material)
        {
            try
            {
                await _materialRepository.AddAsync(material);
                await _unitOfWork.CompleteAsync();
                return new MaterialResponse(material);
            }
            catch (Exception ex)
            {
                return new MaterialResponse($"An error ocurred while saving material: {ex.Message}");
            }
        }

        public async Task<MaterialResponse> UpdateAsync(int id, Material material)
        {
            var existingMaterial = await _materialRepository.FindByIdAsync(id);
            if (existingMaterial == null)
                return new MaterialResponse("Material not found");
            existingMaterial.Name = material.Name;
            try
            {
                _materialRepository.Update(existingMaterial);
                await _unitOfWork.CompleteAsync();
                return new MaterialResponse(existingMaterial);
            }
            catch(Exception ex)
            {
                return new MaterialResponse($"An error ocurred whil updating material: {ex.Message}");
            }
        }
    }
}
