

using System;

namespace Logger.Exceptions
{
   public class InvalidLevelException :Exception
    {
        private const string message = "Invalid Level Type!";
        public InvalidLevelException()
            :base(message) 
        {

        }
    }
}
