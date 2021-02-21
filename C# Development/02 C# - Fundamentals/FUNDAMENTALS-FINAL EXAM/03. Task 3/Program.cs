using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split("->");
            var users = new Dictionary<string, List<string>>();
            while (command[0] != "Statistics")
            {
                if (command[0] == "Add") //ADD
                {
                    string username = command[1];
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }

                }
                else if (command[0] == "Send")  //SEND
                {
                    string username = command[1];
                    string email = command[2];

                    users[username].Add(email);
                }
                else if (command[0] == "Delete") //DELETE
                {
                    string username = command[1];
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }

                command = Console.ReadLine().Split("->");
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var item in users.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{item.Key}");

                
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        Console.WriteLine($"- {item.Value[i]}");
                    }

                
            }
        }
    }
}
