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

namespace UnitTesting.SecurityTest
{
    [ExcludeFromCodeCoverage]
    public class RegisterUser
    {
        [Fact]
        public async Task ValidUserRegister()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new RegisterViewModel()
            {
                Email = "ejemplo@gmail.com",
                Password = "contrasena123",
                ConfirmPassword = "contrasena123"
            };
            mockRepo.Setup(repo => repo.RegisterUserAsync(model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.RegisterAsync(model);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task InvalidUserRegister_MissingFields()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");
            var model = new RegisterViewModel()
            {
                Email = "ejemplo@gmail.com",
            };
            var result = await controller.RegisterAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidUserRegister_NotEqualPassword()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new RegisterViewModel()
            {
                Email = "ejemplo@gmail.com",
                Password = "contrasena123",
                ConfirmPassword = "contrasena1"
            };
            mockRepo.Setup(repo => repo.RegisterUserAsync(model))
                .Returns(getBadResultFromService())
                .Verifiable();
            var result = await controller.RegisterAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        public async Task<UserManagerResponse> getOkResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "User created successfully!",
                IsSuccess = true,
            };
        }
        public async Task<UserManagerResponse> getBadResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "Confirm password doesn't match the password",
                IsSuccess = false,
            };
        }
    }
}
