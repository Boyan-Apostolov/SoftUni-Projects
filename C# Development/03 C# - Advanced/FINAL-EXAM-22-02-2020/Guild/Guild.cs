using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Player> roster { get; set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player astronaut)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(astronaut);
            }
        }

        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < this.roster.Count; i++)
            {
                if (this.roster[i].Name == name)
                {
                    this.roster.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        public void PromotePlayer(string name)
        {
            for (int i = 0; i < this.roster.Count; i++)
            {
                if (this.roster[i].Name == name)
                {
                    this.roster[i].Rank = "Member";
                    break;
                }
            }
        }

        public void DemotePlayer(string name)
        {
            for (int i = 0; i < this.roster.Count; i++)
            {
                if (this.roster[i].Name == name)
                {
                    this.roster[i].Rank = "Trial";
                    break;
                }
            }
        }

        public Player[] KickPlayersByClass(string cls)
        {
            Player[] players = this.roster.Where(x => x.Class == cls).ToArray();
            foreach (var player in players)
            {
                this.roster.Remove(player);
            }
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
