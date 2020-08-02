using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_LOGGER.Models.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
