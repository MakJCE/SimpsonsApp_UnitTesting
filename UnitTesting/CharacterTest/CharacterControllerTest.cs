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




namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterControllerTest
    {
        [Fact]
        public async Task CreateACharacterFromController()
        {
            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            var model = new Character
            {
                ID = 1,
                Name = "Modesto Rosado"
            };
            mock.Setup(repo => repo.CreateCharacterAsync(model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.CreateCharacterAsync(model);

            Assert.IsType<ActionResult<Character>>(result);
        }
        [Fact]
        public async Task GetCharactersFromController()
        {
            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            string orderBy = "id";
            bool showPrase = false;

            mock.Setup(repo => repo.getCharacters(orderBy, showPrase))
                .Returns(getListOfCharacters())
                .Verifiable();
            var result = await controller.getCharacters(showPrase, orderBy);

            Assert.IsType<ActionResult<IEnumerable<Character>>>(result);
        }
        [Fact]
        public async Task GetCharacterFromController()
        {
            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            int id = 1;
            bool showPrase = false;
            mock.Setup(repo => repo.GetCharacterAsync(id, showPrase))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.GetCharacter(id, showPrase);

            Assert.IsType<ActionResult<Character>>(result);
        }
        [Fact]
        public async Task UpdateCharacterFromController()
        {
            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            int id = 1;
            var model = new Character
            {
                ID = 1,
                Name = "Modesto Rosado"
            };
            mock.Setup(repo => repo.UpdateCharacter(id, model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.UpdateCharacter(id, model);

            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async Task DeleteCharacterFromController()
        {
            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            int id = 1;
            mock.Setup(repo => repo.DeleteCharacterAsync(id))
                .Returns(getDeleteModel())
                .Verifiable();
            var result = await controller.DeleteCharacterAsync(id);

            Assert.IsType<ActionResult<DeleteModel>>(result);
        }

        [Fact]
        public async Task GetPhrasesFromController()
        {
            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            mock.Setup(repo => repo.getPhrases())
                .Returns(getListOfPhrases())
                .Verifiable();
            var result = await controller.getPhrases();

            Assert.IsType<ActionResult<IEnumerable<Phrase>>>(result);
        }


        [Fact]
        public async Task ExceptionGetCharactersFromController()
        {

            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            string orderBy = "id";
            bool showPrase = false;
            mock.Setup(repo => repo.getCharacters(orderBy, showPrase))
            .Returns(getException<IEnumerable<Character>>(new Exception())).Verifiable();
 
            var result = await controller.getCharacters(showPrase, orderBy);
            Assert.IsType<ActionResult<IEnumerable<Character>>>(result);
        }
        [Fact]
        public async Task NotFoundOperationExceptionGetCharactersFromController()
        {

            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            string orderBy = "id";
            bool showPrase = false;
            mock.Setup(repo => repo.getCharacters(orderBy, showPrase))
            .Returns(getException<IEnumerable<Character>>(new BadRequestOperationException("message"))).Verifiable();

            var result = await controller.getCharacters(showPrase, orderBy);
            Assert.IsType<ActionResult<IEnumerable<Character>>>(result);
        }
        /*
        [Fact]
        public async Task ExceptionGetCharacterFromController()
        {

            var mock = new Mock<ICharacterService>();
            var controller = new CharacterController(mock.Object);
            int id = 1;
            bool showPrase = false;
            mock.Setup(repo => repo.GetCharacterAsync(id,showPrase))
            .Returns(getException<Character>(new Exception())).Verifiable();
            var result = await controller.GetCharacter(id, showPrase);
            Assert.Throws<Exception>(new Exception());
        }
        */
        public async Task<Character> getOkResultFromService()
        {
            return new Character
            {
                ID = 1,
                Name = "Modesto Rosado"
            };
        }
        public async Task<IEnumerable<Character>> getListOfCharacters()
        {
            IEnumerable<Character> characters = new List<Character>();

            ///(new Character() { ID = 1, Name = "Homero Simpson" });
            ///(new Character() { ID = 2, Name = "Apu Nahasapeemapetilon"});
            return characters;
        }
        public async Task<IEnumerable<Phrase>> getListOfPhrases()
        {
            IEnumerable<Phrase> phrases = new List<Phrase>();
            return phrases;
        }
        public async Task<DeleteModel> getDeleteModel()
        {
            DeleteModel model = new DeleteModel() { IsSuccess = true, Message = "Fue eliminado" };
            return model;
        }
        public async Task<T> getException<T>(Exception exc)
        {
            throw exc;
        }
 
    }
}
