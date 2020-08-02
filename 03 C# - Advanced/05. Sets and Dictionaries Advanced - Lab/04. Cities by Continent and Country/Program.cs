using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new Dictionary<string,Dictionary<string,List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!world.ContainsKey(continent))
                {
                    world[continent] = new Dictionary<string, List<string>>();
                }

                if (!world[continent].ContainsKey(country))
                {
                    world[continent][country] = new List<string>();
                }

                
                    world[continent][country].Add(city);
                
            }

            foreach (var country in world)
            {
                var name = country.Key;
                Console.WriteLine($"{name}:");

                foreach (var city in country.Value)
                {
                    var countryName = city.Key;
                    var cities = city.Value;

                    Console.Write($" {countryName} -> ");
                    Console.Write(string.Join(", ",cities));
                    Console.WriteLine();
                }
            }
        }
    }
}
