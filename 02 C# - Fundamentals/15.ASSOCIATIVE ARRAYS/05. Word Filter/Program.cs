using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArray = Console.ReadLine().Split().ToArray();
            var evenWords = wordsArray.Where(w => (w.Length % 2) == 0); //if w.length is even, add it ot evenWords

            foreach (var word in evenWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
