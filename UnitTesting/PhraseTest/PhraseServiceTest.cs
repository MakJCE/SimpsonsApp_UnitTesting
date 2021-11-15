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


    }
}
