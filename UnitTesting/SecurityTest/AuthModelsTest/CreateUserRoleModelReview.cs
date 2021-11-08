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
    public class CreateUserRoleModelReview
    {
        [Fact]
        public void UserIdFieldTest()
        {
            var clase = new CreateUserRoleViewModel()
            {
                UserId = "123"
            };

            var result = clase.UserId;
            Assert.Equal("123", result);
        }
        [Fact]
        public void RoleIdFieldTest()
        {
            var clase = new CreateUserRoleViewModel()
            {
                RoleId = "321"
            };

            var result = clase.RoleId;
            Assert.Equal("321", result);
        }
    }
}
