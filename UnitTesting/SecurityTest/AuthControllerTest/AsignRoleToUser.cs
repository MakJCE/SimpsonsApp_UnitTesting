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
    public class AsignRoleToUser
    {
        [Fact]
        public async Task ValidRoleAsignation()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new CreateUserRoleViewModel()
            {
                UserId="13",
                RoleId="31"
            };
            mockRepo.Setup(repo => repo.CreateUserRoleAsync(model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.CreateUserRolenAsync(model);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task InvalidRoleAsignation_MissingFields()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");
            var model = new CreateUserRoleViewModel()
            {
                RoleId = "31"
            };
            var result = await controller.CreateUserRolenAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidRoleAsignation_UserIdNotExists()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new CreateUserRoleViewModel()
            {
                UserId = "not exist",
                RoleId = "31"
            };
            mockRepo.Setup(repo => repo.CreateUserRoleAsync(model))
                .Returns(getBadResultFromService("user does not exist"))
                .Verifiable();
            var result = await controller.CreateUserRolenAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidRoleAsignation_RoleIdNotExists()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new CreateUserRoleViewModel()
            {
                UserId = "31",
                RoleId = "not exist"
            };
            mockRepo.Setup(repo => repo.CreateUserRoleAsync(model))
                .Returns(getBadResultFromService("role does not exist"))
                .Verifiable();
            var result = await controller.CreateUserRolenAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidRoleAsignation_UsarHasAlreadyARole()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new CreateUserRoleViewModel()
            {
                UserId = "31",
                RoleId = "13"
            };
            mockRepo.Setup(repo => repo.CreateUserRoleAsync(model))
                .Returns(getBadResultFromService("user has role already"))
                .Verifiable();
            var result = await controller.CreateUserRolenAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        public async Task<UserManagerResponse> getOkResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "Role assigned",
                IsSuccess = true,
            };
        }
        public async Task<UserManagerResponse> getBadResultFromService(string message)
        {
            return new UserManagerResponse
            {
                Message = message,
                IsSuccess = false,
            };
        }
    }
}
