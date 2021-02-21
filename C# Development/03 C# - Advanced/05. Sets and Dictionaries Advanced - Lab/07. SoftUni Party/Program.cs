using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> set = new HashSet<string>();
            HashSet<string> vipSet = new HashSet<string>();
            List<string> normal = new List<string>();
            List<string> vip = new List<string>();

            while (true)
            {

                if (input == "PARTY")
                {
                    break;
                }

                if (input != "PARTY")
                {


                    if (input.StartsWith('1'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('2'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('3'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('4'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('5'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('6'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('7'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('8'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('9'))
                    {
                        vipSet.Add(input);
                    }
                    else if (input.StartsWith('0'))
                    {
                        vipSet.Add(input);
                    }
                    else
                    {
                        set.Add(input);
                    }
                }
                input = Console.ReadLine();
            }

            string secondINput = Console.ReadLine();

            while (true)
            {
                if (secondINput == "END")
                {
                    break;
                }

                if (set.Contains(secondINput))
                {
                    normal.Add(secondINput);
                    set.Remove(secondINput);
                }

                if (vipSet.Contains(secondINput))
                {
                    vip.Add(secondINput);
                    vipSet.Remove(secondINput);
                }
                secondINput = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine(set.Count+vip.Count);

            if (vip.Any())
            {
                foreach (var guest in vip)
                {
                    Console.WriteLine(guest);
                }
            }
            else
            {
                foreach (var guest in set)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
