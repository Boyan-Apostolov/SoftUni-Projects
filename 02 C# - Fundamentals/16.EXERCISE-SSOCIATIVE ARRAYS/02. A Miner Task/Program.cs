using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();

            Dictionary<string, int> ores = new Dictionary<string, int>();

            while (resource != "stop")
            {
                int quanity = int.Parse(Console.ReadLine());
                if (!ores.ContainsKey(resource))
                {
                    ores.Add(resource, quanity);
                }
                else
                {
                    ores[resource] += quanity;
                }

                resource = Console.ReadLine();
            }
            foreach (var item in ores)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
