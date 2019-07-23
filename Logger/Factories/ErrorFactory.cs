using Logger.Exceptions;
using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
   public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {

            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);
            if (!hasParsed)
            {
                throw new InvalidLevelException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString,dateFormat,CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

                throw new InvalidDateFormatException();
            }
            return new Error(dateTime , message ,level);
        }
    }
}
