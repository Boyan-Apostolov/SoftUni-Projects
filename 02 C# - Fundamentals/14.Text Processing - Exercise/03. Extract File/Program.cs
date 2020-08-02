using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] firstSplitSLASH = input.Split("\\");
            string[] nextSplitDOT = firstSplitSLASH[firstSplitSLASH.Length-1].Split(".");
            Console.WriteLine($"File name: {nextSplitDOT[0]}");
            Console.WriteLine($"File extension: {nextSplitDOT[1]}");
        }
    }
}
