using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (char symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 1);
                }
                else
                {
                    symbols[symbol]++;
                }
            }

            foreach (var item in symbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
