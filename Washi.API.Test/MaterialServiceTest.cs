using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services.Communications;
using Washi.API.Services;

namespace Washi.API.Test
{
    class MaterialServiceTest
    {
        [Test]
        public async Task ListAsyncWhenNoMaterialsReturnsEmptyCollection()
        {
            //Arrange
            var mockMaterialRepository = GetDefaultIMaterialRepositoryInstance();
            mockMaterialRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Material>());
            
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new MaterialService(mockMaterialRepository.Object, mockUnitOfWork.Object);
            
            //Act
            List<Material> result = (List<Material>)await service.ListAsync();
            var materialCount = result.Count;

            //Assert
            materialCount.Should().Equals(0);
        }

        [Test]
        public async Task SavingWhenErrorReturnException()
        {
            //Arrange
            Material material = new Material { };
            var mockMaterialRepository = GetDefaultIMaterialRepositoryInstance();
            mockMaterialRepository.Setup(u => u.AddAsync(material))
                .Throws(new Exception());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new MaterialService(mockMaterialRepository.Object, mockUnitOfWork.Object);

            //Act
            MaterialResponse response = await service.SaveAsync(material);
            var message = response.Message;
            //Assert
            message.Should().Contain("An error ocurred while saving material");
        }

        [Test]
        public async Task DeleteAsyncWhenErrorReturnMessage()
        {
            //Arrange
            Material material = new Material {Id=1000, Name="aea" };
            var mockMaterialRepository = GetDefaultIMaterialRepositoryInstance();
            mockMaterialRepository.Setup(u => u.Remove(material))
                .Throws(new Exception());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new MaterialService(mockMaterialRepository.Object, mockUnitOfWork.Object);
            //Act
            MaterialResponse response = await service.DeleteAsync(1000);
            var message = response.Message;
            //Assert
            message.Should().Be("Material not found");
        }



        private Mock<IMaterialRepository> GetDefaultIMaterialRepositoryInstance()
        {
            return new Mock<IMaterialRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
