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
            List<string> ids = new List<string>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split().ToArray();

                if (cmdArgs.Length == 3)
                {//Citizen
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    ICitizen citizen = new Citizen(name,age,id);
                    ids.Add(id);
                }
                else if (cmdArgs.Length == 2)
                {//Robot
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    IRobot robot = new Robot(model,id);
                    ids.Add(id);
                }
            }

            string endingNums = Console.ReadLine();
            foreach (var id in ids.Where(i=>i.EndsWith(endingNums)))
            {
                Console.WriteLine(id);
            }
        }
    }
}
