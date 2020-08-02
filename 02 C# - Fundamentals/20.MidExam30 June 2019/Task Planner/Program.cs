using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Task_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tasks = new List<int>();
            List<int> incompletedTasks = new List<int>();
            string[] tokens = Console.ReadLine().Split(' ');
            int completed = 0;
            int dropped = 0;


            for (int i = 0; i < tokens.Length; i++)
            {
                int temp = int.Parse(tokens[i]);
                tasks.Add(temp);
            }

            string[] commandArgs = Console.ReadLine().Split(' ');
            while (commandArgs[0] != "End")
            {

                switch (commandArgs[0])
                {
                    case "Complete":
                        int indexofCompletion = int.Parse(commandArgs[1]);
                        if ((0 <= indexofCompletion && indexofCompletion < tasks.Count))
                        {
                            tasks[indexofCompletion] = 0;
                            
                        }

                        break;
                    case "Change":
                        int indexofChange = int.Parse(commandArgs[1]);
                        int timeofChange = int.Parse(commandArgs[2]);
                        if ((0 <= indexofChange && indexofChange < tasks.Count))
                        {
                            tasks[indexofChange] = timeofChange;
                        }

                        break;
                    case "Drop":
                        int indextoDropAT = int.Parse(commandArgs[1]);
                        if ((0 <= indextoDropAT && indextoDropAT < tasks.Count))
                        {
                            tasks[indextoDropAT] = -1;
                           
                        }

                        break;
                    case "Count":
                        if (commandArgs[1] == "Completed")
                        {
                            foreach (int task in tasks)
                            {
                                if (task == 0)
                                {
                                    completed++;
                                }
                            }
                            Console.WriteLine(completed);
                        }
                        else if (commandArgs[1] == "Incomplete")
                        {
                            Console.WriteLine(tasks.Count);
                        }
                        else if (commandArgs[1] == "Dropped")
                        {
                            foreach (int task in tasks)
                            {
                                if (task < 0)
                                {
                                    dropped++;
                                }
                            }
                            Console.WriteLine(dropped);
                        }
                        break;

                }
                commandArgs = Console.ReadLine().Split(' ');

            }

            foreach (int task in tasks)
            {
                if (task > 0)
                {
                    incompletedTasks.Add(task);
                }
              

            }
            Console.WriteLine(string.Join(" ", incompletedTasks));
        }
    }
}
