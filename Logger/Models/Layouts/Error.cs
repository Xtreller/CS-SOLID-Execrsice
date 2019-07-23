using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Layouts
{
    public class Error : IError
    {
        public Error(DateTime dateTime,string message , Level level = Level.INFO)
        {
            this.dateTime = dateTime;
            this.Message = message;
            this.level = level;
        }
        public DateTime dateTime { get; }

        public string Message { get; }

        public Level level { get; }
    }
}
