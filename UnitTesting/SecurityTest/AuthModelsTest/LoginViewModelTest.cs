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

namespace UnitTesting.SecurityTest.AuthModelsTest
{ 
    [ExcludeFromCodeCoverage]
    public class LoginViewModelTest
    {
        [Fact]
        public void emailFieldTest()
        {
            var clase = new LoginViewModel() 
            { 
                Email = "ejemplo@gmail.com",
            };
            var result = clase.Email;
            Assert.Equal("ejemplo@gmail.com", result);
        }
        [Fact]
        public void passwordFieldTest()
        {
            var clase = new LoginViewModel()
            {
                Password = "password123",
            };
            var result = clase.Password;
            Assert.Equal("password123", result);
        }
    }
}
