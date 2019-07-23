using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Interfaces
{
   public interface IError
    {
        DateTime dateTime { get; }
        string Message { get; }
        Level level { get; }
    }
}
