using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Diagnostics.CodeAnalysis;
using SimpsonApp.Models;
namespace UnitTesting.CharacterTest
{
    [ExcludeFromCodeCoverage]
    public class CharacterModelTest
    {
        [Fact]
        public void CharacterNameTest()
        {

            Character character = new Character()
            {
                Name = "Frank Scorpio"
            };

            Assert.Equal("Frank Scorpio", character.Name);
        }
        [Fact]
        public void CharacterIdTest()
        {

            Character character = new Character()
            {
                ID = 1
            };

            Assert.Equal(1, character.ID);
        }
        [Fact]
        public void CharacterSeasonTest()
        {

            Character character = new Character()
            {
                appearingSeason = 4
            };
            Assert.Equal(4, character.appearingSeason);
        }
        [Fact]
        public void CharacterAgeTest()
        {

            Character character = new Character()
            {
                Age = 42
            };

            Assert.Equal(42, character.Age);
        }
        [Fact]
        public void CharacterIsProtaTest()
        {

            Character character = new Character()
            {
                isProta = false

            };

            Assert.False(character.isProta);
        }
        [Fact]
        public void CharacterOccupationTest()
        {

            Character character = new Character()
            {
                Occupation = "villano"
            };

            Assert.Equal("villano", character.Occupation);
        }
        [Fact]
        public void CharacterPhrasesTest()
        {

            Character character = new Character()
            {
                Phrases = new Phrase[10]
            };

            var typeCollection = typeof(Phrase[]);
            Assert.IsType<Phrase[]>(character.Phrases);
        }
    }
}
