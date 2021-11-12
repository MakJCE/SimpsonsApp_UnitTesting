using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Services;
using SimpsonApp.Data.Repository;
using SimpsonApp.Models;
using SimpsonApp.Data.Entities;
using SimpsonApp.Exceptions;
namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterServiceTest
    {
        [Fact]
        public void CreateACharacterService()
        {
            IMapper mapper = null;
            var mock = new Mock<ILibraryRepository>();
            var service = new CharacterService(mapper, mock.Object);


            Assert.IsType<CharacterService>(service);
        }
  

        [Fact]
        public async void GetCharactersFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();

            var charactersEntity = new List<CharacterEntity>();
            repoMock.Setup(repo => repo.GetCharactersAsync("id", false))
                .Returns(getOkResultFromService())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<Character>>(charactersEntity))
                .Returns(mapperSimulator<IEnumerable<Character>>(new List<Character>()))
                .Verifiable();

            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.getCharacters("id", false);
            Assert.IsType<List<Character>>(result);
        }
        [Fact]
        public async void GetPhrasesFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var phrasesEntity = new List<PhraseEntity>();
            repoMock.Setup(repo => repo.GetPhrasesAsync(1))
                .Returns(getIEnumerableAsync<PhraseEntity>())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<Phrase>>(phrasesEntity))
                .Returns(mapperSimulator<IEnumerable<Phrase>>(new List<Phrase>()))
                .Verifiable();

            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.getPhrases();
            Assert.IsType<List<Phrase>>(result);
        }

        [Fact]
        public async void GetCharacterFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var characterEntity = new CharacterEntity();
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(getObject<CharacterEntity>(characterEntity))
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Character>(characterEntity))
                .Returns(mapperSimulator<Character>(new Character()))
                .Verifiable();

            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.GetCharacterAsync(1, false);
            Assert.IsType<Character>(result);
        }
        /*
        [Fact]
        public async Task CreateCharacterFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character();
            var characterEntity = new CharacterEntity();

            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(validSaveElement())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<CharacterEntity>(character))
                .Returns(mapperSimulator<CharacterEntity>(characterEntity))
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Character>(characterEntity))
                .Returns(mapperSimulator<Character>(character))
                .Verifiable();


            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.CreateCharacterAsync(new Character() { ID = 1 });
            Assert.IsType<Character>(result);
        }
        */
        /*
        [Fact]
        public async Task UpdateCharacterFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character() { ID = 1 };
            var characterEntity = new CharacterEntity() { ID = 1};
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(getObject<CharacterEntity>(characterEntity))
                .Verifiable();


            repoMock.Setup(repo => repo.UpdateCharacter(characterEntity))
                .Returns(true)
                .Verifiable();

            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(validSaveElement())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<CharacterEntity>(character))
                .Returns(mapperSimulator<CharacterEntity>(characterEntity))
                .Verifiable();

            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.UpdateCharacter(1, character);
            Assert.IsType<Character>(result);
        }
        */
        [Fact]
        public async Task DeleteCharacterFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character() { ID =1};
            var characterEntity = new CharacterEntity() { ID = 1 };

            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(getObject<CharacterEntity>(characterEntity))
                .Verifiable();

            repoMock.Setup(repo => repo.DeleteCharacterAsync(1))
                 .Returns(validSaveElement())
                 .Verifiable();

            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(validSaveElement())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<CharacterEntity>(character))
                .Returns(mapperSimulator<CharacterEntity>(characterEntity))
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Character>(characterEntity))
                .Returns(mapperSimulator<Character>(character))
                .Verifiable();


            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.DeleteCharacterAsync(1);
            Assert.IsType<DeleteModel>(result);
        }
        [Fact]
        public async Task YetDeleteCharacterFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character() { ID = 1 };
            var characterEntity = new CharacterEntity() { ID = 1 };

            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(getObject<CharacterEntity>(characterEntity))
                .Verifiable();

            repoMock.Setup(repo => repo.DeleteCharacterAsync(1))
                 .Returns(validSaveElement())
                 .Verifiable();

            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(invalidSaveElement())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<CharacterEntity>(character))
                .Returns(mapperSimulator<CharacterEntity>(characterEntity))
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Character>(characterEntity))
                .Returns(mapperSimulator<Character>(character))
                .Verifiable();


            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.DeleteCharacterAsync(1);
            Assert.IsType<DeleteModel>(result);
        }
        [Fact]
        public void BadRequestCharactersTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);

            Assert.ThrowsAsync<BadRequestOperationException>(async () => { await servicio.getCharacters("incorrecto", false); });
        }
        [Fact]
        public void BadRequestCharacterTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);

            Assert.ThrowsAsync<NotFoundOperationException>(async () => { await servicio.GetCharacterAsync(-1, false); });
        }
        [Fact]
        public void DatabaseExceptionCreateCharacterTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character();
            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(invalidSaveElement())
                .Verifiable();
            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);

            Assert.ThrowsAsync<DatabaseException>(async () => { await servicio.CreateCharacterAsync(character); });
        }
        [Fact]
        public void DatabaseExceptionUpdateCharacterTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character();
            var characterEntity = new CharacterEntity() { ID = 1 };
            repoMock.Setup(repo => repo.UpdateCharacter(characterEntity))
                .Returns(true)
                .Verifiable();

            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(invalidSaveElement())
                .Verifiable();

            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(getObject<CharacterEntity>(characterEntity))
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<CharacterEntity>(character))
                .Returns(mapperSimulator<CharacterEntity>(characterEntity))
                .Verifiable();
            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);

            Assert.ThrowsAsync<DatabaseException>(async () => { await servicio.UpdateCharacter(1,character); });
        }
        [Fact]
        public void DatabaseExceptionCharacterFromServiceTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var character = new Character() { ID = 1 };
            var characterEntity = new CharacterEntity() { ID = 1 };

            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(getObject<CharacterEntity>(characterEntity))
                .Verifiable();

            repoMock.Setup(repo => repo.DeleteCharacterAsync(1))
                 .Returns(invalidSaveElement())
                 .Verifiable();

            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(validSaveElement())
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<CharacterEntity>(character))
                .Returns(mapperSimulator<CharacterEntity>(characterEntity))
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Character>(characterEntity))
                .Returns(mapperSimulator<Character>(character))
                .Verifiable();


            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);

            Assert.ThrowsAsync<DatabaseException>(async () => { await servicio.DeleteCharacterAsync(1); });

        }
        public async Task<IEnumerable<CharacterEntity>> getOkResultFromService()
        {
            return new List<CharacterEntity>();
        }
        public async Task<IEnumerable<T>> getIEnumerableAsync<T>()
        {
            return new List<T>();
        }
        public async Task<T> getObject<T>(T element)
        {
            return element;
        }
        public T mapperSimulator<T>(T element)
        {
            return element;
        }
        public void createCharacter(CharacterEntity character)
        {

        }
        public async Task<bool> validSaveElement()
        {
            return true;
        }
        public async Task<bool> invalidSaveElement()
        {
            return false;
        }
    }
}
