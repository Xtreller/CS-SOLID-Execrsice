using System;

using System.Text;
using Logger.Exceptions;
using Logger.Models.Layouts;
using Logger.Models.Interfaces;
using Logger.Models.Enumerations;
using System.Collections.Generic;

namespace Logger.Factories
{
   public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }
        
        public IAppender GetAppender(string AppenderType,string layoutType, string levelStr)
        {
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelStr, out level);
            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }
            ILayout layout = this.layoutFactory.GetLayout(layoutType);
            IAppender appender;
            if (AppenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (AppenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout,level,file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }
            return appender;
        }
    }
}
