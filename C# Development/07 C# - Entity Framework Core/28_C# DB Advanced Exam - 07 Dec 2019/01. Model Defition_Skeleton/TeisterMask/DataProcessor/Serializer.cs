using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .Select(x => new ExportProjectsDto()
                {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.Select(y => new ExportTasksDto
                        {
                            Name = y.Name,
                            Label = y.LabelType.ToString()
                        })
                        .OrderBy(m => m.Name)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xml = XmlConverter.Serialize(projects, "Projects");
            return xml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(z => z.Task.OpenDate >= date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Where(z => z.Task.OpenDate >= date)
                        .OrderByDescending(k => k.Task.DueDate)
                        .ThenBy(k => k.Task.Name)
                        .Select(y => new
                        {
                            TaskName = y.Task.Name,
                            OpenDate = y.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = y.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = y.Task.LabelType.ToString(),
                            ExecutionType = y.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(employees,Formatting.Indented);
            return json;

        }
    }
}