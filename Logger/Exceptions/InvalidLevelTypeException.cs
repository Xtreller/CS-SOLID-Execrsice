using System;
using System.Runtime.Serialization;

namespace Logger.Factories
{
    [Serializable]
    internal class InvalidLevelTypeException : Exception
    {
        public InvalidLevelTypeException()
        {
        }

        public InvalidLevelTypeException(string message) : base(message)
        {
        }

        public InvalidLevelTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLevelTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}