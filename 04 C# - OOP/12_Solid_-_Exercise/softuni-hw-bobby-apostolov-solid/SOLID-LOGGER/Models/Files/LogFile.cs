using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SOLID_LOGGER.Models.Contracts;
using SOLID_LOGGER.Models.Enumerations;
using SOLID_LOGGER.Models.IOManagement;

namespace SOLID_LOGGER.Models.Files
{
    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private const string currentDir = "\\logs\\";
        private const string currentFile = "log.txt";
        private string temp;

        private string currentPath;
        private IIOManager IIOManager;

        public LogFile()
        {
            this.IIOManager = new IOManager(currentDir, currentFile);
            this.currentPath = this.IIOManager.CurrentFilePath;
            this.IIOManager.EnsureDirectoryAndFileExists();
            this.temp = currentPath;
        }

        public string Path => this.temp; //TODO:MAY FAIL
        public ulong Size => GetFileSize();

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);
            ulong size = (ulong)text.ToCharArray().Where(c => Char.IsLetter(c)).Sum(c => (int) c);

            return size;
        }

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessege = string.Format(format, dateTime.ToString(dateFormat, CultureInfo.InvariantCulture),
                level.ToString(), message);
            return formattedMessege;
        }
    }
}
