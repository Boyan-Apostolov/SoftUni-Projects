using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ExportProjectTaskDto[] Tasks { get; set; }
    }
    [XmlType("Task")]
    public class ExportProjectTaskDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string LabelType { get; set; }

    }
}
