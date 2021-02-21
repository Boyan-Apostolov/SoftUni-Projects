using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var currentBannedWord in bannedWords)
            {
                text = text.Replace(currentBannedWord, new string('*',currentBannedWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}
