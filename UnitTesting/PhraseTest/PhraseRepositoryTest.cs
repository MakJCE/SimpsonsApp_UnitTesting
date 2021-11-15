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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpsonApp.Data;
using System.Linq;

namespace UnitTesting.PhraseTest
{
    [ExcludeFromCodeCoverage]
    public class PhraseRepositoryTest
    {
        [Fact]
        public async void CreatePhraseSuccessfully()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            var phraseEntity = new PhraseEntity() { Content = "Diablos le moví el cerebro" };
            
            repository.CreatePhrase(phraseEntity);
            await repository.SaveChangesAsync();
            IQueryable<PhraseEntity> query = _dbContext.Phrases;

            var result = query.First<PhraseEntity>(p => p.Content == "Diablos le moví el cerebro");
            Assert.NotNull(result);

            var list = await _dbContext.Phrases.ToListAsync();
            var id = list.Find(c => c.Content == "Diablos le moví el cerebro").ID;
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async void GetPhrasesSuccessfully()
        {
            // Crear db context y simular la conexion a BD
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");

            var _dbContext = new LibraryDbContext(options.Options);
            // getting the results
            var repository = new LibraryRepository(_dbContext);

            var resultWithoutId = await repository.GetPhrasesAsync();
            Assert.IsType<PhraseEntity[]>(resultWithoutId);
            var resultWithId = await repository.GetPhrasesAsync(1);
            Assert.IsType<PhraseEntity[]>(resultWithId);
        }
        [Fact]
        public async void GetPhraseSuccessfully()
        {
            // Crear db context y simular la conexion a BD
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");

            var _dbContext = new LibraryDbContext(options.Options);
            // getting the results
            var repository = new LibraryRepository(_dbContext);

            var result = await repository.GetPhraseAsync(2);
            Assert.IsType<PhraseEntity>(result);
        }
        [Fact]
        public async void GetPhraseInexistant()
        {
            // Crear db context y simular la conexion a BD
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");

            var _dbContext = new LibraryDbContext(options.Options);
            // getting the results
            var repository = new LibraryRepository(_dbContext);

            var result = await repository.GetPhraseAsync(0);
            Assert.Null(result);
        }
        [Fact]
        public async Task UpdatePhraseSuccessfully()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);
            var id = await createATestPhraseAsync(repository, _dbContext);
            var phraseEntity = new PhraseEntity()
            {
                ID = id,
                Content = "Salta Walas, salta!. Relator: Willy no lo logró"
            };
            var result = await repository.UpdatePhraseAsync(phraseEntity);
            await repository.SaveChangesAsync();
            Assert.True(result);

            var result_updated = await repository.GetPhraseAsync(id);
            Assert.NotNull(result_updated);
            Assert.Equal("Salta Walas, salta!. Relator: Willy no lo logró", result_updated.Content);
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async void CreatePhraseSuccessfullyWithCharacter()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);

            var phraseEntity = new PhraseEntity() { Content = "Diablos le moví el cerebro", Character = await getExistingCharacter(repository) };

            repository.CreatePhrase(phraseEntity);
            await repository.SaveChangesAsync();
            IQueryable<PhraseEntity> query = _dbContext.Phrases;

            var result = query.First<PhraseEntity>(p => p.Content == "Diablos le moví el cerebro");
            Assert.NotNull(result);

            var list = await _dbContext.Phrases.ToListAsync();
            var id =list.Find(c => c.Content == "Diablos le moví el cerebro").ID;
            await deleteCaseAsync(repository, id);
        }
        [Fact]
        public async void AddLikesSuccessfully()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=SimpsonAPI;Trusted_Connection=True;");
            var _dbContext = new LibraryDbContext(options.Options);
            var repository = new LibraryRepository(_dbContext);

            var id = await createATestPhraseAsync(repository, _dbContext);
            var idsLists = new List<int>() { id };

            await repository.addLikesAsync(idsLists);
            var saveResult = await repository.SaveChangesAsync();
            Assert.True(saveResult);
            var result2 = await repository.GetPhraseAsync(id);
            Assert.NotNull(result2.Likes);
            Assert.Equal(1, result2.Likes);

            await deleteCaseAsync(repository, id);
        }
        public async Task<int> createATestPhraseAsync(LibraryRepository repository, LibraryDbContext _dbContext)
        {
            _dbContext.Phrases.Add(new PhraseEntity() { Content = "Salta Willy, salta!. Relator: Willy no lo logró", Likes=0});
            await repository.SaveChangesAsync();
            var list = await _dbContext.Phrases.ToListAsync();
            var id = list.Find(c => c.Content == "Salta Willy, salta!. Relator: Willy no lo logró").ID;
            return id;
        }
        public async Task<bool> deleteCaseAsync(LibraryRepository repository, int id)
        {
            repository.DeletePhrase(id);
            return await repository.SaveChangesAsync();
        }
        public async Task<CharacterEntity> getExistingCharacter(LibraryRepository repository)
        {
            var ret = await repository.GetCharacterAsync(1);
            return ret;
        }
    }
}
