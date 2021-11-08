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
    public class UserManagerResponseTest
    {
        [Fact]
        public void messageFieldTest()
        {
            var clase = new UserManagerResponse()
            {
                Message="This is a message"
            };
            var result = clase.Message;

            Assert.IsType<string>(result);
            Assert.Equal("This is a message",result);
        }
        [Fact]
        public void isSuccessFieldTest()
        {
            var clase = new UserManagerResponse()
            {
                IsSuccess = true
            };
            var result = clase.IsSuccess;
            var resultFalse = !clase.IsSuccess;

            Assert.IsType<bool>(result);
            Assert.True(result);
            Assert.False(resultFalse);
        }
        [Fact]
        public void errorsFieldTest()
        {
            var lista = new List<string>();
            lista.Add("error 1");
            lista.Add("error 2");
            var clase = new UserManagerResponse()
            {
                Errors = lista,
            };

            List<string> result = (List<string>)clase.Errors;
            var resultLenght = result.Count;

            Assert.IsType<List<string>>(result);
            Assert.Equal(2,resultLenght);
            Assert.Equal("error 1", result[0]);
            Assert.Equal("error 2", result[1]);
        }
        [Fact]
        public void expireDateFieldTest()
        {
            var clase = new UserManagerResponse()
            {
                ExpireDate = new DateTime(1998,04,25),
            };

            var result = clase.ExpireDate;

            Assert.IsType<DateTime>(result);
            Assert.Equal(1998, result.Value.Year);
            Assert.Equal(4, result.Value.Month);
            Assert.Equal(25, result.Value.Day);
        }
    }
}
