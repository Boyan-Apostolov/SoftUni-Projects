using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var validEntities = new List<Project>();

            StringBuilder sb = new StringBuilder();

            var projectsWithTasksDtos = XmlConverter.Deserializer<ImportProjectsWithTasksDto>(xmlString, "Projects");

            foreach (var projectDto in projectsWithTasksDtos)
            {
                var project = new Project();
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate; //done
                bool isprojecOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);
                if (!isprojecOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectDueDate = DateTime.MaxValue; //done

                if (projectDto.DueDate == "" || projectDto.DueDate == null)
                {
                    project.DueDate = null;
                }
                else
                {
                    bool isprojecDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDate);
                    project.DueDate = projectDueDate;
                }

                //withoutDueDate
                project.Name = projectDto.Name;
                project.OpenDate = projectOpenDate;
                //validate tasks
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate; //done
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate; //done
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);
                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate.HasValue)
                    {
                        if (taskDueDate > project.DueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                   

                    var task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    project.Tasks.Add(task);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));

                validEntities.Add(project);
            }

            context.Projects.AddRange(validEntities);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            var validEntities = new List<Employee>();
            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //check username
                var errorOccured = false;
                foreach (var ch in employeeDto.Username)
                {
                    if (char.IsLetterOrDigit(ch))
                    {

                    }
                    else
                    {
                        errorOccured = true;
                    }
                }
                if (errorOccured)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    EmployeesTasks = new List<EmployeeTask>()
                };


                foreach (var taskDtoId in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == taskDtoId);
                    
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeesTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    };

                    employee.EmployeesTasks.Add(employeesTask);
                }

                
                validEntities.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count));
                
            }

            context.Employees.AddRange(validEntities);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}