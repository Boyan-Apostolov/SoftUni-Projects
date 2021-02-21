using System;
using System.Collections.Generic;
using System.Text;
using SOLID_LOGGER.Models.Enumerations;

namespace SOLID_LOGGER.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }

        void Append(IError error);
    }
}
