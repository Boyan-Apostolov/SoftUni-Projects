using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
