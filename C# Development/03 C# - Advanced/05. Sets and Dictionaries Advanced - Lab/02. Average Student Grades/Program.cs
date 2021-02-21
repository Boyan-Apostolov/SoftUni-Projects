using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new Dictionary<string, List<decimal>>();

            int countOfStudens = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfStudens; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string name = inputInfo[0];
                decimal grade = decimal.Parse(inputInfo[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>());
                }

                grades[name].Add(grade);
            }

            foreach (var (nameKey, gradeValues) in grades)
            {
                Console.Write($"{nameKey} -> ");

                foreach (var gradeValue in gradeValues)
                {
                    Console.Write($"{gradeValue:F2} ");
                }
                Console.WriteLine($"(avg: {gradeValues.Average():F2})");
            }
        }
    }
}
