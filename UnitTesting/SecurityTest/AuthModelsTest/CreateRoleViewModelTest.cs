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
    public class CreateRoleViewModelTest
    {
        [Fact]
        public void NameTest()
        {
            var clase = new CreateRoleViewModel()
            {
                Name = "Role for users",
            };

            var result = clase.Name;

            Assert.Equal("Role for users", result);
        }
        [Fact]
        public void NormalizedNameTest()
        {
            var clase = new CreateRoleViewModel()
            {
                NormalizedName = "Normalized Role for users",
            };

            var result = clase.NormalizedName;

            Assert.Equal("Normalized Role for users", result);
        }
    }
}
