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
    public class LoginUser
    {
        [Fact]
        public async Task ValidUserLogin()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new LoginViewModel()
            {
                Email = "ejemplo@gmail.com",
                Password = "contrasena123",
            };
            mockRepo.Setup(repo => repo.LoginUserAsync(model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.LoginAsync(model);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task InvalidUserRegister_MissingFields()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");
            var model = new LoginViewModel()
            {
                Email = "ejemplo@gmail.com",
            };
            var result = await controller.LoginAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidUserRegister_wrongPassword()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new LoginViewModel()
            {
                Email = "ejemplo@gmail.com",
                Password = "incorrecta",
            };
            mockRepo.Setup(repo => repo.LoginUserAsync(model))
                .Returns(getBadResultFromService())
                .Verifiable();
            var result = await controller.LoginAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task InvalidUserRegister_userNotRegistered()
        {
            var mockRepo = new Mock<IUserService>();
            var controller = new AuthController(mockRepo.Object);
            var model = new LoginViewModel()
            {
                Email = "noregistrado@gmail.com",
                Password = "contrasena123",
            };
            mockRepo.Setup(repo => repo.LoginUserAsync(model))
                .Returns(getBadResultFromService_notRegistered())
                .Verifiable();
            var result = await controller.LoginAsync(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        public async Task<UserManagerResponse> getOkResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "token",
                IsSuccess = true,
            };
        }
        public async Task<UserManagerResponse> getBadResultFromService()
        {
            return new UserManagerResponse
            {
                Message = "Invalid password",
                IsSuccess = false,
            };
        }
        public async Task<UserManagerResponse> getBadResultFromService_notRegistered()
        {
            return new UserManagerResponse
            {
                Message = "User can't log in",
                IsSuccess = false,
                Errors = new List<string> { "There is no user with that Email address" }
            };
        }
    }
}
