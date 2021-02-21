using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = "[A-Za-z]+";
            Regex nameREgex = new Regex(namePattern);
            Regex digitRegex = new Regex("\\d");
            Dictionary<string, int> participantsDict = new Dictionary<string, int>();
            List<string> participants = Regex.Split(Console.ReadLine(), ",\\s+").ToList();

            string input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection charsCollection = nameREgex.Matches(input);
                string name = string.Join("", charsCollection);
                //foreach (Match match in charsCollection)
                //{
                //    name += match.Value;
                //}

                if (participants.Contains(name))
                {
                    MatchCollection digitCollection = digitRegex.Matches(input);
                    int distance = 0;
                    foreach (Match match in digitCollection)
                    {
                        int digit = int.Parse(match.Value);
                        distance += digit;
                    }
                    if (!participantsDict.ContainsKey(name))
                    {
                        participantsDict.Add(name, 0);
                    }

                    participantsDict[name] += distance;
                }
                input = Console.ReadLine();
            }
            participantsDict = participantsDict.OrderByDescending(p => p.Value).ToDictionary(x => x.Key, y => y.Value);
            int counter = 1;
            foreach (KeyValuePair<string, int> kvp in participantsDict)
            {

                string text = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
                Console.WriteLine($"{counter++}{text} place: {kvp.Key}");
                if (counter == 4)
                {
                    break;
                }
            }
        }
    }
}
