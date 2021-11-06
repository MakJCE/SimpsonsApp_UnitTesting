using System;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Controllers;
using SimpsonApp.Services;
using SimpsonApp.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTesting
{

    [ExcludeFromCodeCoverage]
    public class CharacterControlles_UnitTest
    {
        [Fact]
        public async Task Test1()
        {
            var mockRepo = new Mock<ICharacterService>();
            var controller = new CharacterController(mockRepo.Object);
            var result = await controller.getPhrases();

            Assert.IsType<ActionResult<IEnumerable<Phrase>>>(result);
        }
    }
}
