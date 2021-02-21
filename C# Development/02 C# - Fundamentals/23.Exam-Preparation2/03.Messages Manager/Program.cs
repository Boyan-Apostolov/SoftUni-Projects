using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sentMessages = new Dictionary<string, int>();
            Dictionary<string, int> recievedMessages = new Dictionary<string, int>();

            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split("=");
                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    string username = cmdArgs[1];
                    int sent = int.Parse(cmdArgs[2]);
                    int recieved = int.Parse(cmdArgs[3]);

                    if (!sentMessages.ContainsKey(username))
                    {
                        sentMessages.Add(username, sent);
                        recievedMessages.Add(username, recieved);
                    }
                }
                else if (cmdType == "Message")
                {
                    string sender = cmdArgs[1];
                    string receiver = cmdArgs[2];

                    if (sentMessages.ContainsKey(sender) && sentMessages.ContainsKey(receiver))
                    {
                        sentMessages[sender]++;
                        recievedMessages[receiver]++;

                        int senderTotalMessages = sentMessages[sender] + recievedMessages[sender];
                        int receiverTotalMessages = sentMessages[receiver] + recievedMessages[receiver];

                        if (senderTotalMessages >= capacity)
                        {
                            sentMessages.Remove(sender);
                            recievedMessages.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        if (receiverTotalMessages >= capacity)
                        {
                            sentMessages.Remove(receiver);
                            recievedMessages.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (cmdType == "Empty")
                {
                    string username = cmdArgs[1];

                    if (username == "All")
                    {
                        sentMessages.Clear();
                        recievedMessages.Clear();
                    }
                    else
                    {
                        if (sentMessages.ContainsKey(username))
                        {
                            sentMessages.Remove(username);
                            recievedMessages.Remove(username);
                        }
                    }
                }

                command = Console.ReadLine();

            }
            Console.WriteLine($"Users count: {sentMessages.Count}");
            recievedMessages = recievedMessages.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key).ToDictionary(a=> a.Key,b=>b.Value);

            foreach (var kvp in recievedMessages)
            {
                string username = kvp.Key;
                int totalMessages = kvp.Value + sentMessages[username];
                Console.WriteLine($"{username} - {totalMessages}");
            }
        }
    }
}
