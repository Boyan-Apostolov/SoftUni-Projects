using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using _05_FootballTeamGenerator.Common;

namespace _05_FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Statistics stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentException(GlobalConstants.EmptyNameExpectionMSG);
                }

                this.name = value;
            }
        }

        public Statistics Stats { get; }
        public double OverallSkill => this.Stats.AverageStat();
    }
}
