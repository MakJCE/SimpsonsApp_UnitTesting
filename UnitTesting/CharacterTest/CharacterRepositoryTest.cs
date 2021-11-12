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

namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterRepositoryTest
    {
        /*
        [Fact]
        public void CreateCharacterRepository()
        {
            Mock<LibraryDbContext> dbContext = new Mock<LibraryDbContext>();

            var repository = new LibraryRepository(dbContext.Object);
            Assert.IsType<LibraryRepository>(repository);
        }*/
        /*
        [Fact]
        public void CharacterEntityTestAsync()
        {
            HashSet<string> allowedOrderByParameters = new HashSet<string>()
            {
                "id","name","age"
            };
            //var mockRepo = new Mock<LibraryDbContext>();
            DbContextOptions<LibraryDbContext> options;
            //LibraryDbContext context = new LibraryDbContext(options.ContextType);
            //LibraryRepository repository = new LibraryRepository(mockRepo.Object);
            //var res = await repository.GetCharactersAsync("id", false);
            ///Assert.IsType<CharacterEntity[]>(res);
            //Assert.IsType<Mock<LibraryDbContext>>(mockRepo);
        }
        */
    }
}
