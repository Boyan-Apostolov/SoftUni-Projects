using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private readonly List<Department> departments;
        private readonly List<Doctor> doctors;
        public Engine()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }
        public void Run()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var doctorFirstName = tokens[1];
                var doctorLastName = tokens[2];
                var patientName = tokens[3];
                var fullName = doctorFirstName + doctorLastName;

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int rooms = 1; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool isFree = departments[departament].SelectMany(d => d).Count() < 60;
                if (isFree)
                {
                    int room = 0;
                    doctors[fullName].Add(patientName);
                    for (int st = 0; st < departments[departament].Count; st++)
                    {
                        if (departments[departament][st].Count < 3)
                        {
                            room = st;
                            break;
                        }
                    }
                    departments[departament][room].Add(patientName);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
