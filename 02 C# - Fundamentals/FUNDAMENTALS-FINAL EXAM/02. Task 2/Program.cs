using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(U\S)([A-Z]{1}[a-z]{2,})\1(P@\S)([A-Za-z]{5,}[0-9]{1,})\3$";
            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            int successfulRegistrationsCount = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {

                    string username = match.Groups[2].Value;
                    string password = match.Groups[4].Value;
                   


                    Console.WriteLine("Registration was successful");
                    successfulRegistrationsCount++;
                    Console.WriteLine($"Username: {username}, Password: {password}");


                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
