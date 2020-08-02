using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int counter = 0;
            List<string> guests = new List<string>();

            string line = null;

            while (counter < lines)
            {
                line = Console.ReadLine();
                string[] tokens = line.Split(' ');

                if (tokens[2] == "going!")
                {
                    if (guests.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(tokens[0]);
                    }


                }
                else if (tokens[2] == "not")
                {
                    if (!guests.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} is not in the list!");
                    }
                    else
                    {
                        guests.Remove(tokens[0]);
                    }
                }

                counter++;

            }
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }

        }
    }
}
