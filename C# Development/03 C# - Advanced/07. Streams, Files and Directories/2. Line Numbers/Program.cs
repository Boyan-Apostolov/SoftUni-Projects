using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("text.txt");
            using var writer = new StreamWriter("output.txt");
            int count = 1;

            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                var convertedLine = $"{count++} {line}";
                Console.WriteLine(convertedLine);
            }

        }
    }
}
