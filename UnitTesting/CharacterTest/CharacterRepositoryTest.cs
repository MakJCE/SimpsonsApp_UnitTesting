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

            var resultId = await repository.GetCharactersAsync("id", true);
            Assert.IsType<List<CharacterEntity>>(resultId);
            var resultName = await repository.GetCharactersAsync("name", true);
            Assert.IsType<List<CharacterEntity>>(resultName);
            var resultAge = await repository.GetCharactersAsync("age", true);
            Assert.IsType<List<CharacterEntity>>(resultAge);
        }
        [Fact]
        public async Task GetCharacterFromRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            var id = await createATestCharacterAsync(repository, _dbContext);
            var result = await repository.GetCharacterAsync(id, false);
            Assert.IsType<CharacterEntity>(result);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async Task GetCharacterWithPhrasesFromRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            var id = await createATestCharacterAsync(repository, _dbContext);
            var result = await repository.GetCharacterAsync(id, true);
            Assert.IsType<CharacterEntity>(result);
            Assert.IsType<HashSet<PhraseEntity>>(result.Phrases);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public void CreateCharacterWithPhrasesFromRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            CharacterEntity characterEntity = new CharacterEntity() { Name = "Homero Simpson" };
            repository.CreateCharacter(characterEntity);
            var expected = "Homero Simpson";
            Assert.Equal(characterEntity.Name, expected);
        }
        [Fact]
        public async Task DeleteCharacterWithPhrasesFromRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            var id = await createATestCharacterAsync(repository, _dbContext);
            var result = await repository.DeleteCharacterAsync(id);
            Assert.True(result);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async Task UpdateCharacterWithPhrasesFromRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            CharacterEntity characterEntity = new CharacterEntity()
            {
                ID = 100,
                Name = "Matt Groening",
                Age = 36,
                appearingSeason = 15,
                isProta = false,
                Occupation = "dibujante",
                Phrases = new List<PhraseEntity>()
            };
            var id = await createATestCharacterAsync(repository, _dbContext);
            characterEntity.ID = id;
            var result = repository.UpdateCharacter(characterEntity);
            Assert.True(result);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async Task UpdateCharacterWithoutChangesFromRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            CharacterEntity characterEntity = new CharacterEntity()
            {
                ID = 100
            };
            var id = await createATestCharacterAsync(repository, _dbContext);
            characterEntity.ID = id;
            var result = repository.UpdateCharacter(characterEntity);
            Assert.True(result);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async Task SaveAsyncRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            var id = await createATestCharacterAsync(repository, _dbContext);
            Assert.True(id>0);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public void SaveAsyncExceptionRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            CharacterEntity character = new CharacterEntity() { ID = -1};
            _dbContext.Characters.Add(character);
            Assert.ThrowsAsync<Exception>(async () => { await repository.SaveChangesAsync(); });
        }
        public async Task<int> createATestCharacterAsync(LibraryRepository repository, LibraryDbContext _dbContext)
        {
            _dbContext.Characters.Add(new CharacterEntity() { Name = "NombrePrueba", Age = 0, appearingSeason = 1, isProta = true, Occupation = "...", Phrases = null });
            await repository.SaveChangesAsync();
            var list = await _dbContext.Characters.ToListAsync();
            var id = list.Find(c => c.Name == "NombrePrueba").ID;
            return id;
        }
        public async Task<bool> deleteCaseAsync(LibraryRepository repository, int id)
        {
            await repository.DeleteCharacterAsync(id);
            return await repository.SaveChangesAsync();
        }
    }
}
