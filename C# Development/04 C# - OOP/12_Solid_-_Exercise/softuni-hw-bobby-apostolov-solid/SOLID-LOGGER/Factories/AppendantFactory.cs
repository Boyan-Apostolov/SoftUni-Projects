using System;
using System.Collections.Generic;
using System.Text;
using SOLID_LOGGER.Models.Appenders;
using SOLID_LOGGER.Models.Contracts;
using SOLID_LOGGER.Models.Enumerations;
using SOLID_LOGGER.Models.Files;

namespace SOLID_LOGGER.Factories
{
    public class AppendantFactory
    {
        private LayoutFactory layoutFactory;

        public AppendantFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType,string layoutType, string levelStr)
        {
            Level level;
            bool hasPArsed = Enum.TryParse<Level>(levelStr, out level);

            if (!hasPArsed)
            {
                throw new InvalidOperationException("Invalid level!");
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);
            IAppender appender;
            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout,level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException("Invalid appender type!");
            }

            return appender;
        }
    }
}
