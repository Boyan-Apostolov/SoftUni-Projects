using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string input = Console.ReadLine();
            while (input.Contains(word))
            {
                int IndexOfWord = input.IndexOf(word);
                input = input.Remove(IndexOfWord,word.Length);

            }

            Console.WriteLine(input);
        }
    }
}
