using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initianSongs = Console.ReadLine().Split(", ").ToArray();

            var queueOfSongs = new Queue<string>(initianSongs);

            while (queueOfSongs.Any())
            {
                string command = Console.ReadLine();
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "Play")
                {
                    queueOfSongs.Dequeue();
                }
                else if (commandArgs[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ",queueOfSongs));
                }
                else if (commandArgs[0] == "Add")
                {
                    
                    StringBuilder sb = new StringBuilder();

                    foreach (var item in commandArgs)
                    {
                        if (item != "Add")
                        {
                            sb.Append(item+" ");
                        }
                    }
                    StringBuilder finalSB = new StringBuilder(sb.ToString().Trim());
                    if (queueOfSongs.Contains(finalSB.ToString()))
                    {
                        Console.WriteLine($"{finalSB} is already contained!");
                    }
                    else
                    {
                        queueOfSongs.Enqueue(finalSB.ToString());
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
