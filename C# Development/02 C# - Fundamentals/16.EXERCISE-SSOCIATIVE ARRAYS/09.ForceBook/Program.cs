using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();
            Dictionary<string, string> users = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }
                string[] tokens = input.Split(new string[] { " ->  ", " | " },
                    StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("|"))
                {
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, side);
                    }

                    if (!sides.ContainsKey(side))
                    {
                        sides[side] = new List<string>();
                    }
                    sides[side].Add(user);
                    //  Console.WriteLine($"{user} joins the {side} side!");

                }
                else
                {
                    //todo
                    string side = tokens[1];
                    string user = tokens[0];

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, side);
                        Console.WriteLine($"{user} joins the {side} side!");
                        if (!sides.ContainsKey(side))
                        {
                            sides[side] = new List<string>();
                        }
                        sides[side].Add(user);
                    }
                    else
                    {
                        var previousSide = users[user];
                        sides[previousSide].Remove(user);

                        if (sides.ContainsKey(side))
                        {
                            sides.Add(side, new List<string>());

                        }
                        sides[side].Add(user);
                        users[user] = side;

                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            foreach (var side in sides.Where(s => s.Value.Count > 0).OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value.OrderByDescending(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
