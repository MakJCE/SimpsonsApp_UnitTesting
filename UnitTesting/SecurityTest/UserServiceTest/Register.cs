using System;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Models.Security;
using SimpsonApp.Services.Security;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace UnitTesting.SecurityTest.UserServiceTest
{ 
    [ExcludeFromCodeCoverage]
    public class Register
    {
        public async Task ValidCredentialRegister()
        {
            var mockUser = new Mock<UserManager<IdentityUser>>();
            var mockRole = new Mock<RoleManager<IdentityRole>>();
            var mockConfig = new Mock<IConfiguration>();
            var service = new UserService(mockUser.Object, mockRole.Object, mockConfig.Object);

            var result = await service.RegisterUserAsync(new RegisterViewModel() { Email = "ejemplo", Password = "contrasena123", ConfirmPassword = "contrasena123" });
            Assert.IsType<UserManagerResponse>(result);
            Assert.Equal("User created successfully!",result.Message);
        }
    }
}
