using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string[] command = Console.ReadLine().Split(" ");
            while (command[0] != "Complete")
            {


                if (command[0] == "Make")
                {
                    if (command[1] == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (command[1] == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }
                }
                else if (command[0] == "GetDomain")
                {
                    int count = int.Parse(command[1]);
                    string result = email.Substring(email.Length - count);
                    Console.WriteLine(result);
                }
                else if (command[0] == "GetUsername")
                {
                    if (!email.Contains("@"))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        string[] temp = email.Split("@");
                        string username = temp[0];
                        Console.WriteLine(username);
                    }
                }
                else if (command[0] == "Replace")
                {
                    char replacement = char.Parse(command[1]);
                    email = email.Replace(replacement, '-');
                    Console.WriteLine(email);
                }
                else if (command[0] == "Encrypt")
                {
                    for (int i = 0; i < email.Length; i++)
                    {
                        int current = (int)email[i];
                        Console.Write(current + " ");
                    }
                    Console.WriteLine(); ;
                }

                command = Console.ReadLine().Split(" ");
            }
        }
    }
}
