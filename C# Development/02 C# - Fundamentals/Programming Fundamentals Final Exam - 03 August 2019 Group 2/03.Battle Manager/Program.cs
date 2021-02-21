using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> health = new Dictionary<string, int>();
            Dictionary<string, int> energy = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Results")
            {
                string[] tokens = input.Split(":");

                switch (tokens[0])
                {

                    case "Add":
                        string personName = tokens[1];
                        int personHealth = int.Parse(tokens[2]);
                        int personEnergy = int.Parse(tokens[3]);

                        if (!health.ContainsKey(personName))
                        {
                            health.Add(personName, 0);
                            energy.Add(personName, 0);

                        }
                        health[personName] += personHealth;
                        energy[personName] += personEnergy;
                        break;

                    case "Attack":
                        string attackerName = tokens[1];
                        string defenderName = tokens[2];
                        int damage = int.Parse(tokens[3]);

                        if (health.ContainsKey(attackerName) && health.ContainsKey(defenderName))
                        {
                            health[defenderName] -= damage;
                            if (health[defenderName] <= 0)
                            {
                                Console.WriteLine($"{defenderName} was disqualified!");
                                health.Remove(defenderName);
                                energy.Remove(defenderName);

                            }

                            energy[attackerName]--;

                            if (energy[attackerName] <= 0)
                            {
                                Console.WriteLine($"{attackerName} was disqualified!");
                                health.Remove(attackerName);
                                energy.Remove(attackerName);
                            }
                        }
                        break;

                    case "Delete":
                        string username = tokens[1];

                        if (username != "All")
                        {
                            if (health.ContainsKey(username))
                            {
                                health.Remove(username);
                                energy.Remove(username);
                            }

                        }
                        else if (username == "All")
                        {
                            health.Clear();
                            energy.Clear();
                        }
                        break;

                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"People count: {health.Count}");
            health = health.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);
            foreach (var person in health)
            {
                string username = person.Key;
                int curEnergy = energy[username];
                Console.WriteLine($"{person.Key} - {person.Value} - {curEnergy}");

            }

        }
    }
}
