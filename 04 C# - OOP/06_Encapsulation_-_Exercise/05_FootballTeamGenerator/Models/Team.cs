using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _05_FootballTeamGenerator.Common;

namespace _05_FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
        {
            this.Name = name;
        }

        //public int Rating
        //{
        //    get
        //    {
        //        if (this.players.Count ==0)
        //        {
        //            return 0;
        //        }
        //    }
        //}

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentException(GlobalConstants.EmptyNameExpectionMSG);
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            if (!this.players.Any(p=> p.Name == player.Name))
            {
                throw  new InvalidOperationException(string.Format(GlobalConstants.RemovingMissingPlayerExeptionMSG,player.Name,this.Name));
            }

            this.players.Remove(player);
        }

        public int Rating => (int)Math.Round((this.players.Sum(p => p.OverallSkill) / this.players.Count));

    }
}
