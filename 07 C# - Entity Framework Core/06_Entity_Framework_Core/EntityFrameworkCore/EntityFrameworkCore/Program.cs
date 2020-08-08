using System;
using System.Linq;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder();
            //optionsBuilder.UseSqlServer("connectionString");
            //var db = new SoftUniContext(optionsBuilder.Options);

            var db = new SoftUniContext();
            //Console.WriteLine(db.Employees.Count());

            //db.Employees.Add(new Employees
            //{
            //    FirstName = "Petar",
            //    LastName = "Baychev",
            //});

            var townName = db.Employees.Select(e => e.Address.Town.Name).FirstOrDefault(e=>e.StartsWith("N"));

            var allTowns = String.Join("\n ", db.Employees.Select(e => e.Address.Town.Name).Distinct());

            var FirstTenTowns = String.Join("\n ", db.Employees.Select(e => e.Address.Town.Name).Distinct().Take(10));
            var SecondTenTowns = String.Join("\n ", db.Employees.Select(e => e.Address.Town.Name).Distinct().Skip(10).Take(10));

            //var firstPerson = db.Employees.First();
            //firstPerson.FirstName = "Modified First Name";

            //var employee = db.Employees.Find(employeeId);

            Console.WriteLine(townName);

            Console.WriteLine(allTowns);

            db.SaveChanges();
        }
    }
}

