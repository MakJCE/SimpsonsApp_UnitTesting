using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace SimpsonApp.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class NotModelException : Exception
    {
        protected NotModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
        public NotModelException(string message)
            :base(message)
        {

        }
    }
}
