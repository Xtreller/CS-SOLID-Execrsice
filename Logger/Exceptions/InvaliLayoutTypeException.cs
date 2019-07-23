using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Exceptions
{
    public class InvaliLayoutTypeException :Exception
    {
        private const string Message = "Invalid Layout Type!";
        public InvaliLayoutTypeException()
            : base(Message)
        {

        }
        public InvaliLayoutTypeException(string message)
            : base(message)
        {

        }
    }
}
