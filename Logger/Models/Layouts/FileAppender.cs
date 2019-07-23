using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Layouts
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;

        private FileAppender()
        {
            this.messagesAppended = 0;
        }
        public FileAppender(ILayout layout,Level level,IFile file)
        {
            this.Layout = layout;
            this.level = level;
            this.file = file;

        }

        public FileAppender(ILayout layout, Level level)
        {
            Layout = layout;
            this.level = level;
        }

        public ILayout Layout { get; private set; }

        public Level level { get; private set; }

        public IFile file { get; private set; }

        public void Append(IError error)
        {
            string formatedMessage = this.file.Write(this.Layout, error) + Environment.NewLine;
            System.IO.File.AppendAllText(this.file.Path, formatedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report Level: {this.level.ToString()}, " +
                $"Messages appended: {this.messagesAppended}, File size: {this.file.Size}";
        }
    }
}
