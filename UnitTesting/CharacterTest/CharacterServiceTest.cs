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
           
            /*mock.Setup(repo => repo.CreateCharacterAsync(model))
                .Returns(getOkResultFromService())
                .Verifiable();
            var result = await controller.CreateCharacterAsync(model);*/

            Assert.IsType<CharacterService>(service);
        }
        /*
        [Fact]
        public async Task GetPhrasesFromService()
        {
            IMapper mapper = new Mapper(null);
            var mock = new Mock<ILibraryRepository>();
            var service = new CharacterService(mapper, mock.Object);
            var id = 1;
            mock.Setup(repo => repo.GetPhrasesAsync(id))
                .Returns(getIEnumerableAsync<PhraseEntity>())
                .Verifiable();
            var result = await service.getPhrases();

            Assert.IsType<List<Phrase>>(result);
        }
        */
        public async Task<IEnumerable<T>> getIEnumerableAsync<T>()
        {
            return new List<T>();
        }
        /*
        [Fact]
        public void CharacterNameTest()
        {

           
        }
        */

    }
}
