using System;
using System.Collections.Generic;
using System.Linq;
namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();

            var toss = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(names);

            int currentindex = 1;
            while (queue.Count > 1)
            {
                var currentName = queue.Dequeue();
                if (currentindex == toss)
                {
                    Console.WriteLine($"Removed {currentName}");
                    currentindex = 1;
                }
                else
                {
                    queue.Enqueue(currentName);
                }
                currentindex++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
