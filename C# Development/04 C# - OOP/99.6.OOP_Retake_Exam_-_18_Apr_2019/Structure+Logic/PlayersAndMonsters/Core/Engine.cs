using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IManagerController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                if (input[0] == "AddPlayer")
                {
                    string playerType = input[1];
                    string playerName = input[2];

                    result = controller.AddPlayer(playerType, playerName);
                }
                else if (input[0] == "AddCard")
                {
                    string cardType = input[1];
                    string cardName = input[2];

                    result = controller.AddCard(cardType, cardName);
                }
                else if (input[0] == "AddPlayerCard")
                {
                    string username = input[1];
                    string cardName = input[2];

                    result = controller.AddPlayerCard(username, cardName);
                }
                else if (input[0] == "Fight")
                {
                    string attackUser = input[1];
                    string enemyUser = input[2];

                    result = controller.Fight(attackUser, enemyUser);
                }
                else if (input[0] == "Report")
                {
                    result = controller.Report();
                }

                writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
