using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace SimpsonApp.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class NotFoundOperationException : Exception
    {
        protected NotFoundOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
        public NotFoundOperationException(string message): base(message)
        {

        }

    }
}
