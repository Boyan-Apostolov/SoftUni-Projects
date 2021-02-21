using System;
using System.Collections.Generic;
using System.Text;
using SOLID_LOGGER.Models.Enumerations;

namespace SOLID_LOGGER.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }
    }
}
