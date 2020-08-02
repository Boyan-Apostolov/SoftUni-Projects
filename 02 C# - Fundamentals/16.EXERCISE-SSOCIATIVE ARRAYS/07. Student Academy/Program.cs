using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> students = new Dictionary<string, double>();
            Dictionary<string, double> qualified = new Dictionary<string, double>();
            Dictionary<string, double> studentCount = new Dictionary<string, double>();
            double average = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, grade);
                    studentCount.Add(name, 0);
                    studentCount[name] += 1;
                }
                else
                {
                    studentCount[name] += 1;
                }
            }

            foreach (var student in students)
            {
                if (student.Value >= 4.50)
                {
                    qualified.Add(student.Key, student.Value);
                }
            }

            qualified.OrderByDescending(a => a.Value);

            foreach (var participant in qualified)
            {
                Console.WriteLine($"{participant.Key} –> {participant.Value}");
            }
        }
    }
}
