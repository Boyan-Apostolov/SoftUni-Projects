using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Problem_1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("./text.txt");

            char[] charsToReplace = { '-', ',', '.', '!', '@' };
            int coutner = 0;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (coutner % 2 == 0)
                {
                    //{"-", ",", ".", "!", "?"} 
                    line = ReplaceAll(charsToReplace, '@', line);

                    line = String.Join(" ", line.Split(" ").Reverse());

                    Console.WriteLine(line);

                }

                coutner++;
            }
        }

        static string ReplaceAll(char[] replace, char replacement,string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char currentSymbol = str[i];

                if (replace.Contains(currentSymbol))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(currentSymbol);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
