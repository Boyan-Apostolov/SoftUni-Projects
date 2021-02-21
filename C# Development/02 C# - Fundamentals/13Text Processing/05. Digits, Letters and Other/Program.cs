using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] characters = input.ToCharArray();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder chars = new StringBuilder();

            for (int i = 0; i < characters.Length; i++)
            {
                
                if (char.IsDigit(characters[i]))
                {
                    digits.Append(characters[i]);
                }
                else if (char.IsLetter(characters[i]))
                {
                    letters.Append(characters[i]);
                }
                else
                {
                    chars.Append(characters[i]);
                }

            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(chars);
        }
    }
}
