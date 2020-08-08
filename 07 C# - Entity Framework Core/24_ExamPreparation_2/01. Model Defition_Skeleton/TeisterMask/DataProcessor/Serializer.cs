using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using Data;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]),new XmlRootAttribute("Projects"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty,string.Empty);

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                var projects =
                    context.Projects
                        .ToArray()
                        .Where(t => t.Tasks.Count > 0)
                        .Select(x => new ExportProjectDto()
                        {
                            Name = x.Name,
                            TasksCount = x.Tasks.Count,
                            HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                            Tasks = x.Tasks
                                .Select(t => new ExportProjectTaskDto()
                                {
                                    Name = t.Name,
                                    LabelType = t.LabelType.ToString()
                                })
                                .OrderBy(t => t.Name)
                                .ToArray()
                        })
                        .OrderByDescending(p => p.TasksCount)
                        .ThenBy(x => x.Name)
                        .ToArray();

                xmlSerializer.Serialize(stringWriter,projects,namespaces);

            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .ToArray()
                .Where(e => e.EmployeesTasks
                    .Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et=>et.Task.OpenDate>= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e=>e.Username)
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return json;
        }
    }
}