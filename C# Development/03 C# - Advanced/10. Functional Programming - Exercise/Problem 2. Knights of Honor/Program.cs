using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> honor = (name) =>
                {
                    Console.WriteLine("Sir "+name);
                };

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(honor);
        }
    }
}
