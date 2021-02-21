using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SOLID_LOGGER.Models.Contracts;
using SOLID_LOGGER.Models.Enumerations;

namespace SOLID_LOGGER.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";


        private int messagesAppended =0;
        
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Level = level;
            this.Layout = layout;
        }
        public ILayout Layout { get; private set; }
        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = string.Format(format, dateTime.ToString(dateFormat, CultureInfo.InvariantCulture),
                level.ToString(), message);

            Console.WriteLine(formattedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Level.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
