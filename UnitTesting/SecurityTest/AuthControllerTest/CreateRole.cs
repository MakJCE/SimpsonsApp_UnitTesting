using System;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Controllers;
using SimpsonApp.Models.Security;
using SimpsonApp.Services.Security;
using SimpsonApp.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace UnitTesting.SecurityTest.AuthControllerTest
{
    [ExcludeFromCodeCoverage]
    public class CreateRole
    {
        [Fact]
        public async Task ValidRoleCreation()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new CreateRoleViewModel()
            {
                Name="Admin",
                NormalizedName = "Admin"
            };
            mockRepo.Setup(repo => repo.CreateRoleAsync(model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.CreateRolenAsync(model);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task InvalidRoleCreation_MissingFields()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");
            var model = new CreateRoleViewModel()
            {
                NormalizedName = "Admin"
            };
            var result = await controller.CreateRolenAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidRoleCreation_DBError()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new CreateRoleViewModel()
            {
                Name = "Admin",
                NormalizedName = "Admin"
            };
            mockRepo.Setup(repo => repo.CreateRoleAsync(model))
                .Returns(getBadResultFromService())
                .Verifiable();
            var result = await controller.CreateRolenAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        public async Task<UserManagerResponse> getOkResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "Role created successfully!",
                IsSuccess = true,
            };
        }
        public async Task<UserManagerResponse> getBadResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "Role did not create",
                IsSuccess = false,
            };
        }
    }
}
