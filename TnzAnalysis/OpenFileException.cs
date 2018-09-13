using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TnzAnalysis
{
    public class OpenFileException : Exception
    {
        public OpenFileException()
        {
        }

        public OpenFileException(string message) : base(message)
        {
        }

        public OpenFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OpenFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
