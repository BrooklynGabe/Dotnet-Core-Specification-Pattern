namespace BkG.SpecificationPattern
{
    using System;
    using System.Runtime.Serialization;

    public class RequiredArgumentNullException : ArgumentNullException
    {
        public RequiredArgumentNullException()
        {
        }

        public RequiredArgumentNullException(string paramName) : base(paramName)
        {
        }

        public RequiredArgumentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RequiredArgumentNullException(string paramName, string message) : base(paramName, message)
        {
        }

        protected RequiredArgumentNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}