using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(current))
                {
                    dictionary[current] = 0;
                }

                dictionary[current]++;
            }

            foreach (var kvp in dictionary)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    break;
                }
            }
        }
    }
}
