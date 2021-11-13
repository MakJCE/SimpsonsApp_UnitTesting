using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using SimpsonApp.Models;
using SimpsonApp.Exceptions;

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
                Likes=0,
                CharacterID=1
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
    }
}
