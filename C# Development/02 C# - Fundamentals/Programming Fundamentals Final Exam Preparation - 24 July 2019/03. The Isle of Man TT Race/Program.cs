using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#$%&*])(\w+)(\1)=(\d+)!!(.*)";
            Regex regex = new Regex(pattern);

            bool found = false;
            string fina = "";
            int countOfCharacters = 0;
            string nameOfRacer = "";
            string geohashCode = "";
            while (true)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);


                if (match.Success)
                {
                    countOfCharacters = int.Parse(match.Groups[4].Value);
                    geohashCode = match.Groups[5].Value;
                    nameOfRacer = match.Groups[2].Value;
                    if (countOfCharacters == geohashCode.Length)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (char ch in geohashCode)
                        {
                            int temp = ch + countOfCharacters;

                            sb.Append((char)temp);
                        }
                        fina = sb.ToString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

            }

            Console.WriteLine($"Coordinates found! {nameOfRacer} -> {fina}");
        }
    }
}
