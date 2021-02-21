using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([*@])(\w+)(\1):\s\[([A-z])\]\|\[([a-z])\]\|\[([A-z])\]\|$";
            Regex regex = new Regex(pattern);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string message = Console.ReadLine();
                Match match = regex.Match(message);

                if (!match.Success)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }

                
                string tag = match.Groups[2].Value;
                char firstNum = char.Parse(match.Groups[4].Value);
                char secondNum = char.Parse(match.Groups[5].Value);
                char thirdNum = char.Parse(match.Groups[6].Value);

                int first = (int)(firstNum);
                int second = (int)(secondNum);
                int third = (int)(thirdNum);
                

                Console.WriteLine($"{tag}: {first} {second} {third}");


            }
        }
    }
}
