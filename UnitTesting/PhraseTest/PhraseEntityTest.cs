using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Data.Entities;

namespace UnitTesting.PhraseTest
{
    [ExcludeFromCodeCoverage]
    public class PhraseEntityTest
    {
        [Fact]
        public void PhraseEntityContentTest()
        {

            PhraseEntity frase = new PhraseEntity()
            {
                Content = "Uh la la señor frances"
            };

            Assert.Equal("Uh la la señor frances", frase.Content);
        }
        [Fact]
        public void PhraseEntityIDTest()
        {

            PhraseEntity frase = new PhraseEntity()
            {
                ID=1
            };

            Assert.Equal(1, frase.ID);
        }
        [Fact]
        public void PhraseEntitylikesTest()
        {
            PhraseEntity frase = new PhraseEntity()
            {
                Likes=100
            };
            Assert.Equal(100, frase.Likes);
        }
        [Fact]
        public void PhraseEntityNullLikesTest()
        {
            PhraseEntity frase = new PhraseEntity()
            {
                Likes = null
            };
            Assert.Null(frase.Likes);
        }
        [Fact]
        public void PhraseEntitySeasonTest()
        {
            PhraseEntity frase = new PhraseEntity()
            {
                Season = 10
            };
            Assert.Equal(10, frase.Season);
        }
        [Fact]
        public void PhraseEntitySeasonNullTest()
        {
            PhraseEntity frase = new PhraseEntity()
            {
                Season = null
            };
            Assert.Null(frase.Season);
        }
        [Fact]
        public void PhraseEntityPopulrityTest()
        {
            PhraseEntity frase = new PhraseEntity()
            {
                Popularity = "Baja"
            };
            Assert.Equal("Baja", frase.Popularity);
        }

        [Fact]
        public void PhraseEntityCharacterTest()
        {
            CharacterEntity character = new CharacterEntity()
            {
                Name = "Frank Scorpio"
            };

            PhraseEntity frase = new PhraseEntity()
            {
                Content = "Homero si quieres matar a alguien al salir, me harias un favor",
                Character = character
            };
            Assert.Equal(character, frase.Character);
        }
    }
}
