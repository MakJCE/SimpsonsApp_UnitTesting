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
using UnitTesting.UtilsMock;

namespace UnitTesting.PhraseTest
{
    [ExcludeFromCodeCoverage]
    public class PhraseServiceTest
    {
        private PhraseMock utils = new PhraseMock();
        [Fact]
        public void CreatePhraseService()
        {
            IMapper mapper = null;
            var mock = new Mock<ILibraryRepository>();
            var service = new PhraseService(mapper, mock.Object);
            Assert.IsType<PhraseService>(service);
        }
        [Fact]
        public void validateCharacterTest()
        {
            IMapper mapper = null;
            var mock = new Mock<ILibraryRepository>();
            mock.Setup(repo => repo.GetCharacterAsync(1,false))
                .Returns(utils.getOkResultFromlibraryRepo())
                .Verifiable();
            var service = new PhraseService(mapper, mock.Object);
            var result = service.validateCharacter(1);
            Assert.IsNotType<NotFoundOperationException>(result);
        }
        [Fact]
        public void validateNullCharacterTest()
        {
            IMapper mapper = null;
            var mock = new Mock<ILibraryRepository>();
            mock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(utils.getNullResultFromlibraryRepo())
                .Verifiable();
            var service = new PhraseService(mapper, mock.Object);
            Assert.ThrowsAsync<NotFoundOperationException>(async () => { await service.validateCharacter(1); });
        }
        [Fact]
        public void validatePhraseTest()
        {
            IMapper mapper = null;
            var mock = new Mock<ILibraryRepository>();
            mock.Setup(repo => repo.GetPhraseAsync(1))
                .Returns(utils.getOkPhraseResultFromlibraryRepo())
                .Verifiable();
            var service = new PhraseService(mapper, mock.Object);
            var result = service.validatePhrase(1);
            Assert.IsNotType<NotFoundOperationException>(result);
        }
        [Fact]
        public void validateNullPhraseTest()
        {
            IMapper mapper = null;
            var mock = new Mock<ILibraryRepository>();
            mock.Setup(repo => repo.GetPhraseAsync(1))
                .Returns(utils.getNullPhraseResultFromlibraryRepo())
                .Verifiable();
            var service = new PhraseService(mapper, mock.Object);
            Assert.ThrowsAsync<NotFoundOperationException>(async () => { await service.validatePhrase(1); });
        }
        [Fact]
        public async void GetPhraseFromService()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var characterEntity = new CharacterEntity() { ID = 1 };
            var phraseEntity = new PhraseEntity() { ID = 1, Character = characterEntity };
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(async () => {
                    return characterEntity;
                })
                .Verifiable();

            repoMock.Setup(repo => repo.GetPhraseAsync(1))
                .Returns(async () =>
                {
                    return phraseEntity;
                })
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Phrase>(phraseEntity))
                .Returns(new Phrase())
                .Verifiable();

            var servicio = new PhraseService(mapperMock.Object, repoMock.Object);
            var result = await servicio.GetphraseAsync(1, 1);
            Assert.IsType<Phrase>(result);
        }
        [Fact]
        public void GetPhraseFailTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var characterEntity = new CharacterEntity() { ID = 2 };
            var phraseEntity = new PhraseEntity() { ID = 1, Character = characterEntity };
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(async () => {
                    return characterEntity;
                })
                .Verifiable();

            repoMock.Setup(repo => repo.GetPhraseAsync(1))
                .Returns(async () =>
                {
                    return phraseEntity;
                })
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<Phrase>(phraseEntity))
                .Returns(new Phrase())
                .Verifiable();

            var servicio = new PhraseService(mapperMock.Object, repoMock.Object);
            Assert.ThrowsAsync<NotFoundOperationException>(async () => { await servicio.GetphraseAsync(1, 1); });
        }
        [Fact]
        public void getPhrasesTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>(); 
            var characterEntity = new CharacterEntity() { ID = 1 };
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
               .Returns(async () => {
                   return characterEntity;
               })
               .Verifiable();
            repoMock.Setup(repo => repo.GetPhrasesAsync(1))
               .Returns(utils.getPhrasesFromService())
               .Verifiable();
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<Phrase>>(utils.getPhrasesFromService()))
                .Returns(new List<Phrase>())
                .Verifiable();
            var servicio = new PhraseService(mapperMock.Object, repoMock.Object);
            var result = servicio.getPhrases(1);
            Assert.IsType<Task<IEnumerable<Phrase>>>(result);
        }

        [Fact]
        public async Task updateFailPhraseTest()
        {
            var perso = new CharacterEntity() { ID = 1 };
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            repoMock.Setup(repo => repo.GetCharacterAsync(1,false))
              .Returns(async () => {
                  return perso;
              })
              .Verifiable();
            repoMock.Setup(repo => repo.GetPhraseAsync(1))
              .Returns(async () => {
                  return new PhraseEntity() { ID = 1, Character=perso};
              })
              .Verifiable();
            var servicio = new PhraseService(mapperMock.Object, repoMock.Object);
            Assert.ThrowsAsync<DatabaseException>(async () => { await servicio.UpdatePhraseAsync(1, 1, new Phrase() { Content = "Con la pollera colora" }); });
        }
        [Fact]
        public async Task updatePhraseTest()
        {
            var perso = new CharacterEntity() { ID = 1 };
            var repoMock = new Mock<ILibraryRepository>();
            var mappermock = new Mock<IMapper>();
            mappermock.Setup(mapper => mapper.Map<PhraseEntity>(new Phrase() { ID = 1, Content = "con la pollera colora" }))
                .Returns(new PhraseEntity() { ID= 1, Content = "con la pollera colora" })
                .Verifiable();
            mappermock.Setup(mapper => mapper.Map<Phrase>(new PhraseEntity() { ID = 1, Content = "con la pollera colora" }))
               .Returns((new Phrase() { ID = 1, Content = "con la pollera colora" }))
               .Verifiable();
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
              .Returns(async () => {
                  return perso;
              })
              .Verifiable();
            repoMock.Setup(repo => repo.GetPhraseAsync(1))
              .Returns(async () => {
                  return new PhraseEntity() { ID = 1, Character = perso };
              })
              .Verifiable();
            repoMock.Setup(repo => repo.UpdatePhraseAsync(new PhraseEntity() { ID = 1, Content = "Con la pollera colora" }))
             .Returns(new Task<bool>(() => true))
             .Verifiable();
            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(utils.validSaveElement()).Verifiable();
            var servicio = new PhraseService(mappermock.Object, repoMock.Object);
            var result = await servicio.UpdatePhraseAsync(1, 1, new Phrase() { Content = "Con la pollera colora" });
            Assert.True(result);
        }
        [Fact]
        public async Task DeletePhraseFromServiceTest()
        {
            var perso = new CharacterEntity() { ID = 1 };
            var frase = new PhraseEntity() { ID = 1 , Character = perso};
            var repoMock = new Mock<ILibraryRepository>();
            var mappermock = new Mock<IMapper>();
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(utils.getObject<CharacterEntity>(perso))
                .Verifiable();
            repoMock.Setup(repo => repo.GetPhraseAsync(1))
                .Returns(utils.getObject<PhraseEntity>(frase))
                .Verifiable();
            repoMock.Setup(repo => repo.SaveChangesAsync())
                .Returns(utils.validSaveElement()).Verifiable();
            var servicio = new PhraseService(mappermock.Object, repoMock.Object);
            var result = await servicio.DeletePhraseAsync(1, 1);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteFailPhraseFromServiceTest()
        {
            var perso = new CharacterEntity() { ID = 1 };
            var frase = new PhraseEntity() { ID = 1, Character = perso };
            var repoMock = new Mock<ILibraryRepository>();
            var mappermock = new Mock<IMapper>();
            repoMock.Setup(repo => repo.GetCharacterAsync(1, false))
                .Returns(utils.getObject<CharacterEntity>(perso))
                .Verifiable();
            repoMock.Setup(repo => repo.GetPhraseAsync(1))
                .Returns(utils.getObject<PhraseEntity>(frase))
                .Verifiable();
            var servicio = new PhraseService(mappermock.Object, repoMock.Object);
            Assert.ThrowsAsync<DatabaseException>(async () => { await servicio.DeletePhraseAsync(1, 1); });
        }
        [Fact]
        public async Task CreateFailPhraseFromServiceTest()
        {
            var perso = new CharacterEntity() { ID = 1 };
            var frase = new PhraseEntity() { ID = 1, Character = perso };
            var repoMock = new Mock<ILibraryRepository>();
            var mappermock = new Mock<IMapper>();
            var servicio = new PhraseService(mappermock.Object, repoMock.Object);
            Assert.ThrowsAsync<DatabaseException>(async () => { await servicio.CreatePhraseAsync(1, new Phrase() { ID = 1 }); });
        }
    }
}
