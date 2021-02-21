using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SOLID_LOGGER.Models.Contracts;
using SOLID_LOGGER.Models.Enumerations;
using SOLID_LOGGER.Models.Errors;

namespace SOLID_LOGGER.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;
            bool hasPArsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasPArsed)
            {
                throw new InvalidOperationException("Invalid level type!");
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Invalid DateTime format!",e);
            }

            return new Error(dateTime, message, level);
        }
    }
}
