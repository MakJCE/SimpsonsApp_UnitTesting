using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using SimpsonApp.Models;
using SimpsonApp.Exceptions;
using SimpsonApp.Data.Entities;

namespace UnitTesting.UtilsMock
{
    [ExcludeFromCodeCoverage]
    class PhraseMock
    {
        public async Task<Phrase> getOkResultFromService()
        {
            return new Phrase
            {
                ID = 1,
                Content = "No vives de ensalada",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                CharacterID = 1
            };
        }
        public async Task<IEnumerable<Phrase>> getListOfPhrases()
        {
            IEnumerable<Phrase> frases = new List<Phrase>();
            return frases;
        }
        public async Task<bool> getOkboolResultFromService()
        {
            return true;
        }

        public async Task<bool> getDeleteModel()
        {
            return true;
        }

        public async Task<T> getException<T>(Exception exception)
        {
            throw exception;
        }

        public async Task<CharacterEntity> getOkResultFromlibraryRepo()
        {
            return new CharacterEntity() { ID = 1};
        }
        public async Task<PhraseEntity> getOkPhraseResultFromlibraryRepo()
        {
            return new PhraseEntity()
            {
                ID = 1,
                Content = "No vives de ensalada",
                Season = 1,
                Popularity = "Alta",
                Likes = 0,
                Character = new CharacterEntity() { ID = 1, Name = "Homero" }
            }; ;
        }
        public async Task<CharacterEntity> getNullResultFromlibraryRepo()
        {
            return null;
        }
        public async Task<PhraseEntity> getNullPhraseResultFromlibraryRepo()
        {
            return null;
        }

        public async Task<IEnumerable<PhraseEntity>> getPhrasesFromService()
        {
            return new List<PhraseEntity>();
        }
        public async Task<bool> validSaveElement()
        {
            return true;
        }
        public async Task<T> getObject<T>(T element)
        {
            return element;
        }
    } 
}
