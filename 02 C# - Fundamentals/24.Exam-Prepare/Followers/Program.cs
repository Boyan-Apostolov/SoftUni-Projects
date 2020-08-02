using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> likes = new Dictionary<string, int>();
            Dictionary<string, int> comments = new Dictionary<string, int>();
            while (input != "Log out")
            {
                string[] tokens = input.Split(": ");
                string command = tokens[0];
                string username = tokens[1];

                switch (command)
                {
                    case "New follower":
                        if (!likes.ContainsKey(username))
                        {
                            likes.Add(username, 0);
                            comments.Add(username, 0);
                        }
                        break;

                    case "Like":
                        int countLikes = int.Parse(tokens[2]);
                        if (!likes.ContainsKey(username))
                        {
                            likes.Add(username, 0);
                            comments.Add(username, 0);
                        }

                        likes[username] += countLikes;

                        break;

                    case "Comment":
                        
                        if (!comments.ContainsKey(username))
                        {
                            likes.Add(username, 0);
                            comments.Add(username, 0);
                        }

                        comments[username] += 1 ;
                        break;

                    case "Blocked":
                        if (likes.ContainsKey(username))
                        {
                            likes.Remove(username);
                            comments.Remove(username);
                        }
                        else
                        {
                            Console.WriteLine($"{username} doesn't exist.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{likes.Count} followers");
            foreach (var kvpLikes in likes.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                string username = kvpLikes.Key;
                int likesCount = kvpLikes.Value;
                int commentsCount = comments[username];
                Console.WriteLine($"{username}: {likesCount + commentsCount}");
            }
        }
    }
}
