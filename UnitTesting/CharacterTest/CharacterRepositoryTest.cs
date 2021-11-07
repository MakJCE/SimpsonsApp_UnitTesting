using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Data.Entities;
using SimpsonApp.Data.Repository;
using SimpsonApp.Data;
using Moq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterRepositoryTest
    {
        [Fact]
        public void CharacterEntityTestAsync()
        {
            HashSet<string> allowedOrderByParameters = new HashSet<string>()
            {
                "id","name","age"
            };
            //var mockRepo = new Mock<LibraryDbContext>();
            DbContextOptions<LibraryDbContext> options;
            LibraryDbContext context = new LibraryDbContext(options.ContextType);
            //LibraryRepository repository = new LibraryRepository(mockRepo.Object);
            //var res = await repository.GetCharactersAsync("id", false);
            ///Assert.IsType<CharacterEntity[]>(res);
            Assert.IsType<Mock<LibraryDbContext>>(mockRepo);
        }
    }
}
