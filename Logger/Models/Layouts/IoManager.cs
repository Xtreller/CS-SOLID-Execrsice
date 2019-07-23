using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.Layouts
{
    class IoManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;
        private IoManager()
        {
            this.currentPath = this.GetCurrentPath();

        }
        public IoManager(string currentDirectory, string currentFile)
            : this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }
        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        public void EnsurePathAndFileExistance()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }
            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
