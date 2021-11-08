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
    public class RegisterViewModelTest
    {
        [Fact]
        public void emailFieldTest()
        {
            var clase = new RegisterViewModel(){
                Email = "ejemplo@gmail.com"
            };
            var result = clase.Email;
            Assert.Equal("ejemplo@gmail.com", result);
        }
        [Fact]
        public void passwordFieldTest()
        {
            var clase = new RegisterViewModel()
            {
                Password = "password123"
            };
            var result = clase.Password;
            Assert.Equal("password123", result);
        }
        [Fact]
        public void confirmPasswordFieldTest()
        {
            var clase = new RegisterViewModel()
            {
                ConfirmPassword = "password123"
            };
            var result = clase.ConfirmPassword;
            Assert.Equal("password123", result);
        }
    }
}
