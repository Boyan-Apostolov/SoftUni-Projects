using System;
using System.Collections.Generic;
using System.Text;
using SOLID_LOGGER.Models.Contracts;

namespace SOLID_LOGGER.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
