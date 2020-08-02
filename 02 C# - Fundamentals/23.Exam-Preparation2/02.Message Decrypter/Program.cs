using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([$%])([A-Z][a-z]{2,})([$%])\:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string openingTag = match.Groups[1].Value;
                    string closingTag = match.Groups[3].Value;

                    if (openingTag == closingTag)
                    {
                        string tagName = match.Groups[2].Value;
                        string message = string.Empty;

                        for (int j = 4; j < match.Groups.Count; j++)
                        {
                            int value = int.Parse(match.Groups[j].Value);
                            message += (char)value;
                        }
                        Console.WriteLine($"{tagName}: {message}");
                    }
                    else
                    {
                        Console.WriteLine("Valid message not found!");
                    }

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
