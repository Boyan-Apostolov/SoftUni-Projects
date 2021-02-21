using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentsORM.Models;

namespace StudentsORM
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new StudentsDbContext();
            dbContext.Database.EnsureCreated();

            //dbContext.Courses.Add(new Course {Name = "Entity Framework Core"});
            //dbContext.Courses.Add(new Course {Name = "SQL Server"});

            var course = dbContext.Courses.FirstOrDefault(x => x.Id == 1);
            course.Name = "Bobby changed the name!!!";

            dbContext.Courses.Remove(course);
           
            dbContext.Students.Add(new Student{ FirstName = "Boyan", LastName = "Apostolov"});

            bool exists = dbContext.Students.Any(s => s.FirstName.StartsWith("B"));

            //Create
            dbContext.Grades.Add(new Grade
            {
                Student = new Student { FirstName = "Stoyan", LastName = "Shopov"},
                Course =  new Course {Name = "OOP"},
                Value = 6.00M
            });

            //Update
            var grade = dbContext.Grades.FirstOrDefault(x => x.Student.FirstName == "Stoyan");
            grade.Value = 2.00M;

            //Delete
            dbContext.Grades.Remove(grade);

            dbContext.SaveChanges();

            //dbContext.Database.ExecuteSqlRaw("DELETE FROM Courses");
        }
    }
}
