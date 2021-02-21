using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<string> years = new List<string>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split().ToArray();

                if (cmdArgs.Length == 5)
                {//Citizen
                    string name = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];
                    ICitizen citizen = new Citizen(name, age, id, birthdate);
                    years.Add(birthdate);
                }
                else if (cmdArgs.Length == 3)
                {//Robot
                    if (cmdArgs[0] == "Pet")
                    {
                        string name = cmdArgs[1];
                        string birthdate = cmdArgs[2];
                        IPet pet = new Pet(name, birthdate);
                        years.Add(birthdate);
                    }
                    else
                    {
                        string model = cmdArgs[1];
                        string id = cmdArgs[2];
                        IRobot robot = new Robot(model, id);
                    }

                }
            }

            string endingNums = Console.ReadLine();
            foreach (var id in years.Where(i => i.EndsWith(endingNums)))
            {
                Console.WriteLine(id);
            }
        }
    }
}
