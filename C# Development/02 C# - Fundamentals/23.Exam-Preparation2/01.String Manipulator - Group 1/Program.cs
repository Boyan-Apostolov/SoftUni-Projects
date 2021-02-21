using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(" ");
                string cmdType = cmdArgs[0];

                if (cmdType == "Translate")
                {
                    string ch = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    input = input.Replace(ch, replacement);

                    Console.WriteLine(input);
                }
                else if (cmdType == "Includes")
                {
                    string subStr = cmdArgs[1];

                    bool result = input.Contains(subStr);

                    Console.WriteLine(result);
                }
                else if (cmdType == "Start")
                {
                    string substring = cmdArgs[1];

                    bool result = input.StartsWith(substring);

                    Console.WriteLine(result);
                }
                else if (cmdType == "Lowercase")
                {
                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (cmdType == "FindIndex")
                {
                    string ch = cmdArgs[1];
                    int lastIndex = input.LastIndexOf(ch);
                    Console.WriteLine(lastIndex);
                }
                else if (cmdType == "Remove")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int count = int.Parse(cmdArgs[2]);

                    input = input.Remove(start, count);
                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }
        }
    }
}
