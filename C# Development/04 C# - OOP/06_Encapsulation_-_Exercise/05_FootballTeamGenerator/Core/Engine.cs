using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using _05_FootballTeamGenerator.Common;
using _05_FootballTeamGenerator.Models;

namespace _05_FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split("; ", StringSplitOptions.None).ToArray();

                string commandType = cmdArgs[0];

                if (commandType == "Team")
                {
                    AddTeam(cmdArgs);
                }
                else if (commandType == "Add")
                {
                    string teamName = cmdArgs[1];
                    string playerName = cmdArgs[2];

                    this.ValidateTeamExists(teamName);
                    Statistics stats = this.CreateStats(cmdArgs.Skip(3).ToArray());

                    Player player = new Player(playerName, stats);
                    Team team = this.teams.First(t => t.Name == teamName);
                }
                else if (commandType == "Remove")
                {
                    string teanName = cmdArgs[1];
                    string playerName = cmdArgs[2];
                }
            }
        }

        private Statistics CreateStats(string[] cmdArgs)
        {
            int endurance = int.Parse(cmdArgs[0]);
            int sprint = int.Parse(cmdArgs[1]);
            int dribble = int.Parse(cmdArgs[2]);
            int passing = int.Parse(cmdArgs[3]);
            int shooting = int.Parse(cmdArgs[4]);
            return  new Statistics(endurance,sprint,dribble,passing,shooting);
        }

        private void ValidateTeamExists(string name)
        {
            if (!this.teams.Any(t=>t.Name == name))
            {
                throw  new ArgumentException(string.Format(GlobalConstants.TeamDoesNotExist, name));
            }
        }

        private void AddTeam(string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            Team team = new Team(teamName);
            this.teams.Add(team);
        }
    }
}
