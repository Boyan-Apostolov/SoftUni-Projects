using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SOLID_LOGGER.Models.Contracts;
using SOLID_LOGGER.Models.Layouts;

namespace SOLID_LOGGER.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException("Invalid layout type!");
            }

            return layout;
        }
    }
}
