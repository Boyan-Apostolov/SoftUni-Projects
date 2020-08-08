using System;
using System.Security.Cryptography.X509Certificates;

namespace ORMFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();
            var employees = dbContext.Employees.ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName+' '+employee.LastName);
            }
        }
    }
}
