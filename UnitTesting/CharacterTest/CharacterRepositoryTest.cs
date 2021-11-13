using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Data;
using SimpsonApp.Data.Repository;
using SimpsonApp.Models;
using SimpsonApp.Data.Entities;
using SimpsonApp.Exceptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterRepositoryTest
    {
        [Fact]
        public void CreateCharacterRepository()
        {
            // Crear db context y simular la conexion a BD
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");

            var _dbContext = new LibraryDbContext(options.Options);
            //var dbcontextMock = new Mock<LibraryDbContext>(options.Options);

            //creating _dbContext as a Mock
            //dbcontextMock.Setup(dbc => dbc.Characters.AsNoTracking())
            //    .Returns(OkResult_GetCharacters(_dbContext.Characters))
            //    .Verifiable();

            // getting the results
            var repository = new LibraryRepository(_dbContext);
            Assert.IsType<LibraryRepository>(repository);
        }
        [Fact]
        public async void GetCharactersFromRepository()
        {
            // Crear db context y simular la conexion a BD
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");

            var _dbContext = new LibraryDbContext(options.Options);
            //var dbcontextMock = new Mock<LibraryDbContext>(options.Options);

            //creating _dbContext as a Mock
            //dbcontextMock.Setup(dbc => dbc.Characters.AsNoTracking())
            //    .Returns(OkResult_GetCharacters(_dbContext.Characters))
            //    .Verifiable();

            // getting the results
            var repository = new LibraryRepository(_dbContext);

            var result = await repository.GetCharactersAsync("id", true);
            Assert.IsType<List<CharacterEntity>>(result);
        }
    }
}
