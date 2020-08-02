using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Sign up")
            {
                string[] tokens = input.Split(" ");
                string commamd = tokens[0];
                switch (commamd)
                {
                    case "Case":
                        string caseType = tokens[1];
                        if (caseType == "lower")
                        {
                            username = username.ToLower();
                        }
                        else if (caseType == "upper")
                        {
                            username = username.ToUpper();
                        }

                        Console.WriteLine(username);

                        break;
                    case "Reverse":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        if (startIndex < 0 || startIndex >= username.Length || endIndex < 0 || endIndex >= username.Length)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        int length = endIndex - startIndex + 1;
                        string subStr = username.Substring(startIndex, length);
                        char[] chars = subStr.Reverse().ToArray();
                        Console.WriteLine(string.Join("", chars));
                        break;

                    case "Cut":
                        string subStrCut = tokens[1];

                        if (username.Contains(subStrCut))
                        {
                            username = username.Replace(subStrCut, "");
                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {subStrCut}.");
                        }
                        break;

                    case "Replace":
                        char charReplace = char.Parse(tokens[1]);
                        username = username.Replace(charReplace, '*');
                        Console.WriteLine(username);
                        break;

                    case "Check":
                        char charCheck = char.Parse(tokens[1]);
                        if (username.Contains(charCheck))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {charCheck}.");
                        }
                        break;

                }

                input = Console.ReadLine();
            }
        }
    }
}
