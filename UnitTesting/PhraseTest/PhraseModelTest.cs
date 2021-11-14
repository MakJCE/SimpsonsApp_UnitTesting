using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Models;

namespace UnitTesting.PhraseTest
{
    [ExcludeFromCodeCoverage]
    public class PhraseModelTest
    {
        [Fact]
        public void PhraseModelContentTest()
        {

            Phrase frase = new Phrase()
            {
                Content = "Uh la la señor frances"
            };

            Assert.Equal("Uh la la señor frances", frase.Content);
        }
        [Fact]
        public void PhraseModelIDTest()
        {

            Phrase frase = new Phrase()
            {
                ID = 1
            };

            Assert.Equal(1, frase.ID);
        }
        [Fact]
        public void PhraseModelLikesTest()
        {
            Phrase frase = new Phrase()
            {
                Likes = 100
            };
            Assert.Equal(100, frase.Likes);
        }
        [Fact]
        public void PhraseModelNullLikesTest()
        {
            Phrase frase = new Phrase()
            {
                Likes = null
            };
            Assert.Null(frase.Likes);
        }
        [Fact]
        public void PhraseModelSeasonTest()
        {
            Phrase frase = new Phrase()
            {
                Season = 10
            };
            Assert.Equal(10, frase.Season);
        }
        [Fact]
        public void PhraseModelPopulrityTest()
        {
            Phrase frase = new Phrase()
            {
                Popularity = "Baja"
            };
            Assert.Equal("Baja", frase.Popularity);
        }
        [Fact]
        public void PhraseEntityCharacterTest()
        {
            Phrase frase = new Phrase()
            {
                Content = "Que es un contrato, un documento legal que NO se puede romper",
                CharacterID = 1
            };
            Assert.Equal(1, frase.CharacterID);
        }
    }
}
