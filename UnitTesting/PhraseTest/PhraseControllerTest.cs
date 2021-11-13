using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Services;
using SimpsonApp.Controllers;
using SimpsonApp.Models;
using SimpsonApp.Exceptions;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitTesting.UtilsMock;

namespace UnitTesting.PhraseTest
{
    [ExcludeFromCodeCoverage]
    public class PhraseControllerTest
    {
        private PhraseMock utils = new PhraseMock();
        [Fact]
        public async Task CreatePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            var model = new Phrase
            {
                ID = 1,
                Content = "A la grande le puse cuca",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                CharacterID = 1
            };
            mock.Setup(repo => repo.CreatePhraseAsync(1, model))
                .Returns(utils.getOkResultFromService())
                .Verifiable();
            var result = await controller.CreatePhraseAsync(1, model);

            Assert.IsType<ActionResult<Phrase>>(result);
        }
        [Fact]
        public async Task GetPhrasesFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            mock.Setup(repo => repo.getPhrases(1))
                .Returns(utils.getListOfPhrases())
                .Verifiable();
            var result = await controller.getPhrases(1);

            Assert.IsType<ActionResult<IEnumerable<Phrase>>>(result);
        }

        [Fact]
        public async Task GetPhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(repo => repo.GetphraseAsync(id, id))
                .Returns(utils.getOkResultFromService())
                .Verifiable();
            var result = await controller.GetPhraseAsync(id, id);

            Assert.IsType<ActionResult<Phrase>>(result);
        }

        [Fact]
        public async Task UpdatePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            var model = new Phrase
            {
                ID = 1,
                Content = "Modesto Rosado",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                CharacterID = 1
            };
            mock.Setup(repo => repo.UpdatePhraseAsync(id, id, model))
                .Returns(utils.getOkboolResultFromService())
                .Verifiable();
            var result = await controller.UpdatePhraseAsync(id, id, model);

            Assert.IsType<ActionResult<Phrase>>(result);

        }
        [Fact]
        public async Task DeletePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(repo => repo.DeletePhraseAsync(id, id))
                .Returns(utils.getDeleteModel())
                .Verifiable();
            var result = await controller.DeletePhraseAsync(id, id);

            Assert.IsType<ActionResult<bool>>(result);
        }
        [Fact]
        public async Task ExceptionCreatePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            var frase = new Phrase()
            {
                ID = 1,
                Content = "Marge hay otro hombre en esta casa?",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                CharacterID = 1
            };
            mock.Setup(service => service.CreatePhraseAsync(id, frase))
            .Returns(utils.getException<Phrase>(new Exception())).Verifiable();

            var result = await controller.CreatePhraseAsync(id, frase);
            Assert.IsType<ActionResult<Phrase>>(result);
        }

        [Fact]
        public async Task ExceptionGetPhrasesFromController()
        {

            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(repo => repo.getPhrases(id))
            .Returns(utils.getException<IEnumerable<Phrase>>(new Exception())).Verifiable();
            var result = await controller.getPhrases(id);
            Assert.IsType<ActionResult<IEnumerable<Phrase>>>(result);
        }
        [Fact]
        public async Task NotFoundOperationExceptionGetPhrasesFromController()
        {

            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(repo => repo.getPhrases(id))
            .Returns(utils.getException<IEnumerable<Phrase>>(new NotFoundOperationException("message"))).Verifiable();

            var result = await controller.getPhrases(id);
            Assert.IsType<ActionResult<IEnumerable<Phrase>>>(result);
        }
        [Fact]
        public async Task ExceptionGetPhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(service => service.GetphraseAsync(id, id))
            .Returns(utils.getException<Phrase>(new Exception())).Verifiable();

            var result = await controller.GetPhraseAsync(id, id);
            Assert.IsType<ActionResult<Phrase>>(result);
        }
        [Fact]
        public async Task NotFoundOperationExceptionGetPhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(service => service.GetphraseAsync(id, id))
            .Returns(utils.getException<Phrase>(new NotFoundOperationException("message"))).Verifiable();

            var result = await controller.GetPhraseAsync(id, id);
            Assert.IsType<ActionResult<Phrase>>(result);
        }
        [Fact]
        public async Task NotFoundExceptionDeletePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(service => service.DeletePhraseAsync(id, id))
            .Returns(utils.getException<bool>(new NotFoundOperationException("message"))).Verifiable();

            Assert.ThrowsAsync<NotFoundOperationException>(async () => { await controller.DeletePhraseAsync(id, id); });
        }
        [Fact]
        public async Task ExceptionDeletePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            mock.Setup(service => service.DeletePhraseAsync(id, id))
            .Returns(utils.getException<bool>(new Exception("message"))).Verifiable();

            Assert.ThrowsAsync<Exception>(async () => { await controller.DeletePhraseAsync(id, id); });
        }
        [Fact]
        public async Task ExceptionUpdatePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            Phrase frase = new Phrase() { Content = "asda" };
            mock.Setup(service => service.UpdatePhraseAsync(id, id, frase))
            .Returns(utils.getException<bool>(new Exception("message"))).Verifiable();
            Assert.ThrowsAsync<Exception>(async () => { await controller.UpdatePhraseAsync(id, id, frase); });
        }
        [Fact]
        public async Task NotFoundOperationExceptionUpdatePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            Phrase frase = new Phrase() { Content = "Soy homero el malo" };
            mock.Setup(service => service.UpdatePhraseAsync(id, id, frase))
            .Returns(utils.getException<bool>(new NotFoundOperationException("message"))).Verifiable();
            Assert.ThrowsAsync<NotFoundOperationException>(async () => { await controller.UpdatePhraseAsync(id, id, frase); });
        }
        [Fact]
        public async Task NotFoundOperationExceptionCreatePhraseFromController()
        {
            var mock = new Mock<IPhraseService>();
            var controller = new PhraseController(mock.Object);
            int id = 1;
            var frase = new Phrase()
            {
                ID = 1,
                Content = "Marge hay otro hombre en esta casa?",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                CharacterID = 1
            };
            mock.Setup(service => service.CreatePhraseAsync(id, frase))
            .Returns(utils.getException<Phrase>(new NotFoundOperationException("message"))).Verifiable();
            await Assert.ThrowsAsync<NotFoundOperationException>(async () => { await controller.CreatePhraseAsync(id, frase); });
        }
        [Fact]
        public async Task BadRequestCreatePhraseFromController()
        {
            var service = new Mock<IPhraseService>();
            var controller = new PhraseController(service.Object);
            controller.ModelState.AddModelError("key", "error message");
            var nuevaFrase = new Phrase()
            {
                ID = 1,
                Content = "Esto es el barrio chino",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                CharacterID = 1
            };
            service.Setup(repo => repo.CreatePhraseAsync(1, nuevaFrase))
                .Returns(utils.getOkResultFromService())
                .Verifiable();
            var result = await controller.CreatePhraseAsync(1, nuevaFrase);

            Assert.IsType<ActionResult<Phrase>>(result);
        }
        [Fact]
        public async Task BadRequestUpdatePhraseFromController()
        {
            var service = new Mock<IPhraseService>();
            var frase = new Phrase();
            var controller = new PhraseController(service.Object);
            controller.ModelState.AddModelError("error", "some error");
            var result = await controller.UpdatePhraseAsync(1, 1, frase);
            Assert.IsType<ActionResult<Phrase>>(result);
        }
        [Fact]
        public async Task PutLikeFromPhraseController()
        {
            var service = new Mock<IPhraseService>();
            var controller = new PhraseController(service.Object);
            var listoflikes = new List<int>();
            var result = await controller.LikePhraseAsync(1,listoflikes);
            Assert.IsType<ActionResult<Phrase>>(result);
        }
    }
}
