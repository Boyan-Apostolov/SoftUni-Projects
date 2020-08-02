using System;
using System.Collections.Generic;
using System.Text;

namespace P03.StudentSystem
{


    public class StudentData
    {
        private Dictionary<string, Student> repo;

        public StudentData()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students
        {
            get { return repo; }
            private set { repo = value; }
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();
            string[] comm = args;

            if (args[0] == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);
                if (!repo.ContainsKey(name))
                {
                    AddStudent(name, age, grade);
                }
            }
            else if (args[0] == "Show")
            {
                var name = args[1];

                Console.WriteLine(GetDetails(name));
            }
            else if (args[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }

        public void AddStudent(string name, int age, double grade)
        {
            var student = new Student(name, age, grade);
            Students[name] = student;
        }

        public string GetDetails(string name)
        {
            if (Students.ContainsKey(name))
            {
                var student = Students[name];
                var details = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    details += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    details += " Average student.";
                }
                else
                {
                    details += " Very nice person.";
                }

                return details;
            }
            throw new Exception();
        }
    }


}
