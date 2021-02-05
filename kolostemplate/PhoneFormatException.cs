using System;
using System.Runtime.Serialization;

namespace kolostemplate
{
    [Serializable]
    internal class PhoneFormatException : Exception
    {
        public PhoneFormatException()
        {
        }

        public PhoneFormatException(string message) : base(message)
        {
        }

        public PhoneFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PhoneFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}