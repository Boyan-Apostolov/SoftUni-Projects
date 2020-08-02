using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char previousChar = text[0];
            Console.Write(previousChar);
            for (int i = 1; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (previousChar != currentChar)
                {
                    previousChar = currentChar;
                    Console.Write(previousChar);
                }
                
            }
        }
    }
}
