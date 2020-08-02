using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            int totalTime = 0;

            List<string> input = new List<string>();

            var bandTime = new Dictionary<string, int>(); // where the time per band will go to
            var bandMembers = new Dictionary<string, List<string>>(); // where the band and its members will go to

            while ((command = Console.ReadLine()) != "start of concert")
            {
                input = command.Split("; ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string action = input[0];
                string band = input[1];

                if (action == "Add")
                {
                    List<string> members = input[2].Split(", ").ToList(); // list of the people

                    if (!bandMembers.ContainsKey(band))  // the dictionary does not contain the band
                    {
                        bandMembers.Add(band, new List<string>()); // we add the band
                    }

                    for (int i = 0; i < members.Count; i++)
                    {
                        if (!bandMembers[band].Contains(members[i])) // if the person is not yet there, we add the name to the list
                        {
                            bandMembers[band].Add(members[i]);
                        }
                    }
                }

                else if (action == "Play")
                {
                    int time = int.Parse(input[2]);
                    totalTime += time;

                    if (!bandTime.ContainsKey(band)) // band is not on the list yet
                    {
                        bandTime.Add(band, time); // we add it for the first time
                    }

                    else // bandName is not in the dictionary
                    {
                        bandTime[band] += time; // we add only the time, as the band is already there
                    }
                }
            }

            string finalLine = Console.ReadLine(); // you get the final group there

            Console.WriteLine($"Total time: {totalTime} "); // total time of all bands
            foreach (var item in bandTime.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            foreach (var kvp in bandMembers)
            {
                if (kvp.Key == finalLine)
                {
                    Console.WriteLine($"{kvp.Key}");

                    foreach (var item in kvp.Value)
                    {
                        Console.WriteLine($"=> {item}");
                    }
                }
            }



        }
    }
}
