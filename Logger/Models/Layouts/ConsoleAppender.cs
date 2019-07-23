using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Layouts
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private int messagesAppended;

        public ILayout Layout { get; private set; }

        public Level level { get; private set; }
        public ConsoleAppender()
        {
            this.messagesAppended = 0;
        }
        public ConsoleAppender(ILayout layout,Level level)
            :this()
        {
            this.Layout = layout;
            this.level = level;
        }
        public void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTime = error.dateTime;
            string message = error.Message;
            Level level = error.level;

            string formattedMessage = string.Format(format, dateTime.ToString(dateFormat, CultureInfo.InvariantCulture), level.ToString(), message);
            Console.WriteLine(formattedMessage);
            messagesAppended++;


        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report Level: {this.level.ToString()}, " +
                $"Messages appended: {this.messagesAppended}";
        }
    }
}
