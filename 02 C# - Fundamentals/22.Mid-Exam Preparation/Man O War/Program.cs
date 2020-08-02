using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int[] warShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int maxHealthSection = int.Parse(Console.ReadLine());
            string input = null;
            bool isBroken = false;

            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] commandArgs = input.Split(" ");
                string command = commandArgs[0];
                int index = -1;

                switch (command)
                {
                    case "Fire":
                        index = int.Parse(commandArgs[1]);
                        int damage = int.Parse(commandArgs[2]);
                        if (index >= 0 && index < warShip.Length)
                        {
                            warShip[index] -= damage;
                            if (warShip[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                isBroken = true;
                                //

                            }
                        }

                        break;

                    case "Defend":
                        index = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);
                        damage = int.Parse(commandArgs[3]);
                        if (index >= 0 && index < pirateShip.Length &&
                            endIndex >= 0 && endIndex < pirateShip.Length)
                        {
                            for (int i = index; i <= endIndex; i++)
                            {
                                pirateShip[index] -= damage;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    isBroken = true;
                                    break;
                                }
                            }
                        }

                        break;

                    case "Repair":
                        index = int.Parse(commandArgs[1]);
                        int health = int.Parse(commandArgs[2]);
                        if (index >= 0 && index < pirateShip.Length)
                        {
                            pirateShip[index] += health;

                            if (pirateShip[index] > maxHealthSection)
                            {
                                pirateShip[index] = maxHealthSection;
                            }
                        }
                        break;

                    case "Status":
                        int count = 0;
                        foreach (int section in pirateShip)
                        {
                            double temp = 0.2 * maxHealthSection;

                            if (section < temp)
                            {
                                count++;
                            }

                        }
                        
                        break;
                    default:
                        break;
                }

                if (isBroken)
                {
                    break;
                }
            }

            if (!isBroken)
            {
                int pirateShipSum = 0;
                int warShipSum = 0;

                foreach (int i in pirateShip)
                {
                    pirateShipSum += 1;
                }
                foreach (int i in warShip)
                {
                    warShipSum += 1;
                }
                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");

            }
        }
    }
}
