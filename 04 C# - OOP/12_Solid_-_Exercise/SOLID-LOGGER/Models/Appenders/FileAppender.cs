using System;
using System.Collections.Generic;
using System.Text;
using SOLID_LOGGER.Models.Contracts;
using SOLID_LOGGER.Models.Enumerations;

namespace SOLID_LOGGER.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private int messagesAppended=0;

        public FileAppender(ILayout layout,Level level,IFile file)
        {
            this.Level = level;
            this.Layout = layout;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error)+Environment.NewLine;
            System.IO.File.AppendAllText(this.File.Path, formattedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Level.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File size: {this.File.Size}";
        }
    }
}
