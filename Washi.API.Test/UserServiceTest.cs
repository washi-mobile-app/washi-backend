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
    class UserServiceTest
    {
        [Test]
        public async Task ListAsyncWhenNoUsersReturnsEmptyCollection()
        {
            //Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            mockUserRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<User>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new UserService(
                mockUserRepository.Object,
                mockUnitOfWork.Object);
            //Act
            List<User> result = (List<User>) await service.ListAsync();
            var usersCount = result.Count;

            //Assert
            usersCount.Should().Equals(0);

        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsUserNotFoundResponse()
        {
            //Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var UserId = 1;
            mockUserRepository.Setup(u => u.FindById(UserId))
                .Returns(Task.FromResult<User>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object);

            //Act
            UserResponse result = await service.GetByIdAsync(UserId);
            var message = result.Message;

            //Assert
            message.Should().Be("User not found");
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }


    }
}
