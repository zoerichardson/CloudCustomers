using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests.Systems.Controllers
{
    public class UnitTest1
    {
        [Fact]
        public async Task Get_On_Success_ReturnsStatusCode200()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());
            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_On_Success_InvokesUserServiceExactlyOnce()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once());

        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            //arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());
            var sut = new UsersController(mockUserService.Object);

            //act
            var result = await sut.Get();

            //assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            //arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
            var sut = new UsersController(mockUserService.Object);

            //act
            var result = await sut.Get();

            //assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
          
        }
    }
}