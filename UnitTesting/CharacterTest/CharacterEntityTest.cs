using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Data.Entities;
namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterEntityTest
    {
        [Fact]
        public void CharacterEntityNameTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                Name = "Frank Scorpio"
            };

            Assert.Equal("Frank Scorpio", character.Name);
        }
        [Fact]
        public void CharacterEntityIdTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                ID = 1
            };

            Assert.Equal(1, character.ID);
        }
        [Fact]
        public void CharacterEntitySeasonTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                appearingSeason = 4
            };
            Assert.Equal(4, character.appearingSeason);
        }
        [Fact]
        public void CharacterEntityAgeTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                Age = 42
            };

            Assert.Equal(42, character.Age);
        }
        [Fact]
        public void CharacterEntityIsProtaTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                isProta = false

            };

            Assert.False(character.isProta);
        }
        [Fact]
        public void CharacterEntityOccupationTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                Occupation = "villano"
            };

            Assert.Equal("villano", character.Occupation);
        }
        [Fact]
        public void CharacterEntityPhrasesTest()
        {

            CharacterEntity character = new CharacterEntity()
            {
                Phrases = new PhraseEntity[10]
            };

            var typeCollection = typeof(PhraseEntity[]);
            Assert.IsType<PhraseEntity[]>(character.Phrases);
        }
    }
}
