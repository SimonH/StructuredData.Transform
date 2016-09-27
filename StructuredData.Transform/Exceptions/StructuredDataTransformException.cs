using System;
using System.Runtime.Serialization;
using StructuredData.Common.Exceptions;

namespace StructuredData.Transform.Exceptions
{
    [Serializable]
    public class StructuredDataTransformException : StructuredDataException
    {
        public StructuredDataTransformException()
        {
        }

        public StructuredDataTransformException(string message) : base(message)
        {
        }

        public StructuredDataTransformException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StructuredDataTransformException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}