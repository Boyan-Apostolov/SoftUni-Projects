using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurences = new Dictionary<char, int>();
            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!occurences.ContainsKey(letter))
                    {
                        occurences.Add(letter, 0);
                    }
                    occurences[letter]++;
                }

            }
            foreach (var character in occurences)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
