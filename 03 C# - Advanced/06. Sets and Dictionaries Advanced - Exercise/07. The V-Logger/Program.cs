using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vloggerWithHisFollowers = new Dictionary<string, HashSet<string>>();

            Dictionary<string, HashSet<string>> vloggerWithHisFollowings = new Dictionary<string, HashSet<string>>();

            string command;

            while ((command=Console.ReadLine()) != "Statistics")
            {
                ProcessInput(vloggerWithHisFollowers, vloggerWithHisFollowings, command);
            }

            vloggerWithHisFollowers = vloggerWithHisFollowers.OrderByDescending(kvp => kvp.Value.Count).ThenBy(kvp => vloggerWithHisFollowings[kvp.Key].Count).ToDictionary(a => a.Key, b => b.Value);
            int cnt = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggerWithHisFollowings.Count} vloggers in its logs.");

            KeyValuePair<string,HashSet<string>> mostFamousVlogger = vloggerWithHisFollowers.First(); //something's bad here

            string motFamousVloggerName = mostFamousVlogger.Key;

            HashSet<string> mostFamVlogFollowes = mostFamousVlogger.Value.OrderBy(n=>n).ToHashSet();

            Console.WriteLine($"{cnt++}. {motFamousVloggerName} : {mostFamVlogFollowes.Count} followers, {vloggerWithHisFollowings[motFamousVloggerName].Count} following");

            foreach (var follower in mostFamVlogFollowes)
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var bloggerFolloweresPair in vloggerWithHisFollowers.Skip(1))
            {
                string name = bloggerFolloweresPair.Key;
                HashSet<string> followes = bloggerFolloweresPair.Value;
                Console.WriteLine($"{cnt++}. {name} : {followes.Count} followers, {vloggerWithHisFollowers[name].Count} following");
            }

        }








        private static void ProcessInput(Dictionary<string, HashSet<string>> vloggerWithHisFollowers, Dictionary<string, HashSet<string>> vloggerWithHisFollowings, string command)
        {
            string[] commandArgs = command.Split(" ").ToArray();

            string cmdType = commandArgs[1];

            if (cmdType == "joined")
            {
                JoinVlogger(vloggerWithHisFollowers, vloggerWithHisFollowings, commandArgs);
            }
            else if (cmdType == "followed")
            {
                Follow(vloggerWithHisFollowers, vloggerWithHisFollowings, commandArgs);

            }
        }

        private static void Follow(Dictionary<string, HashSet<string>> vloggerWithHisFollowers, Dictionary<string, HashSet<string>> vloggerWithHisFollowings, string[] commandArgs)
        {
            string follower = commandArgs[0];
            string toBeFollowd = commandArgs[2];

            if (follower != toBeFollowd)
            {
                if (vloggerWithHisFollowers.ContainsKey(toBeFollowd) && vloggerWithHisFollowings.ContainsKey(follower))
                {
                    vloggerWithHisFollowers[toBeFollowd].Add(follower);
                    vloggerWithHisFollowings[follower].Add(toBeFollowd);
                }
            }
        }

        private static void JoinVlogger(Dictionary<string, HashSet<string>> vloggerWithHisFollowers, Dictionary<string, HashSet<string>> vloggerWithHisFollowings, string[] commandArgs)
        {
            string vloggerToJOin = commandArgs[0];

            if (vloggerWithHisFollowers.ContainsKey(vloggerToJOin))
            {
                vloggerWithHisFollowers[vloggerToJOin] = new HashSet<string>();
                vloggerWithHisFollowings[vloggerToJOin] = new HashSet<string>();

            }
        }
    }
}
