using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> book = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ").ToArray();
                string command = tokens[0];
                

                if (command == "register")
                {
                    string name = tokens[1];
                    string licensePlate = tokens[2];
                    if (book.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                    else
                    {
                        book.Add(name, licensePlate);
                        Console.WriteLine($"{name} registered {licensePlate} successfully");
                    }

                }
                else if (command == "unregister")
                {
                    string name = tokens[1];
                    
                    if (!book.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        book.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }

            }

            foreach (var user in book)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
