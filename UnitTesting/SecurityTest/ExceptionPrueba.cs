using System;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Controllers;
using SimpsonApp.Data.Repository;
using SimpsonApp.Data;
using SimpsonApp.Services;
using SimpsonApp.Exceptions;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using SimpsonApp.Data.Entities;
using SimpsonApp.Models;

namespace UnitTesting.SecurityTest
{
    [ExcludeFromCodeCoverage]
    public class ExceptionPrueba
    {
        [Fact]
        public void BadRequestTest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);

            Assert.ThrowsAsync<BadRequestOperationException>(async () => { await servicio.getCharacters("incorrecto", false); });
        }
        [Fact]
        public async void happyPath()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            repoMock.Setup(repo => repo.GetCharactersAsync("id", false))
                .Returns(getOkResultFromService())
                .Verifiable();
            var servicio = new CharacterService(mapperMock.Object, repoMock.Object);
            var result = await servicio.getCharacters("id", false);
            Assert.IsType<Character[]>(result);
            //var listResult = new List<Character>(result);
            //Assert.Single(listResult);
            //Assert.Equal("Alvaro", listResult[0].Name);
        }
        public async Task<IEnumerable<CharacterEntity>> getOkResultFromService()
        {
            return new List<CharacterEntity>() { new CharacterEntity() { Name = "Alvaro"} };
        }
    }
}
