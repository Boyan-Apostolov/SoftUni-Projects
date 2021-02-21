using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _10._Softuni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submission = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }
                string[] tokens = input.Split("-");

                string user = tokens[0];


                if (tokens.Length > 2)
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!students.ContainsKey(user))
                    {
                        students.Add(user, points);
                    }
                    else
                    {
                        if (students[user] < points)
                        {
                            students[user] = points;
                        }
                    }

                    if (!submission.ContainsKey(language))
                    {
                        submission.Add(language, 0);
                    }

                    submission[language]++;

                }
                else
                {
                    if (students.ContainsKey(user))
                    {
                        students.Remove(user);
                    }
                }
            }

            Console.WriteLine("Results:");

            foreach (var student in students.OrderByDescending(s=> s.Value).ThenBy(s=> s.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var s in submission.OrderByDescending(s=> s.Value).ThenBy(s=>s.Key))
            {
                Console.WriteLine($"{s.Key} - {s.Value}");
            }
        }
    }
}
