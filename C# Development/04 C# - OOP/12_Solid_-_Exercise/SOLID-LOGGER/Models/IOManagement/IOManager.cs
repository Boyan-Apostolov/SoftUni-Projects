using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SOLID_LOGGER.Models.Contracts;

namespace SOLID_LOGGER.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDir;
        private string currentFile;

        public IOManager(string currentDir,string currentFile) : this()
        {
            this.currentDir = currentDir;
            this.currentFile = currentFile;
        }

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        public string CurrentDirectoryPath => this.currentPath + this.currentDir;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        public void EnsureDirectoryAndFileExists()
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
