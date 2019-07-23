using Logger.Models.Enumerations;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Models.Layouts
{
    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        public const string currentDirectory = "\\logs\\";
        public const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager iOManager;

        public LogFile()
        {
            this.iOManager = new IoManager(currentDirectory, currentFile);
            this.currentPath = this.iOManager.GetCurrentPath();
            this.iOManager.EnsurePathAndFileExistance();
            this.Path = currentPath + currentDirectory + currentFile;
        }
        public string Path { get; private set; }

        public ulong Size => GetFileSize();


        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.dateTime;
            string message = error.Message;
            Level level = error.level;

            string FormatMessage = string.Format(format,dateTime.ToString(dateFormat,CultureInfo.InvariantCulture),level.ToString(),message);
            return FormatMessage;

        }
        private ulong GetFileSize(  )
        {
            string text = File.ReadAllText(this.Path);
            ulong size = (ulong)text.ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => (int)c);
            return size;
        }
    }
}
