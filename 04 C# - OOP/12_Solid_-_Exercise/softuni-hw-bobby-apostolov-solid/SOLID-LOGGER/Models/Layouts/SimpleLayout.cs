using System;
using System.Collections.Generic;
using System.Text;
using SOLID_LOGGER.Models.Contracts;

namespace SOLID_LOGGER.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
