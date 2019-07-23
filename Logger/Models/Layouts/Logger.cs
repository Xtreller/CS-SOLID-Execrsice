using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Layouts
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;


        public void Log(IError error)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (appender.level <= error.level)
                {
                    appender.Append(error);

                }
            }
        }
        public override string ToString()   
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (var appender in appenders)
            {
                sb.AppendLine(appender.ToString());

            }

            return sb.ToString().TrimEnd();
        }
    }
}
