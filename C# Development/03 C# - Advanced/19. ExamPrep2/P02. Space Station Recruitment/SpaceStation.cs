using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02._Space_Station_Recruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        private SpaceStation()
        {
            this.data = new List<Astronaut>();
        }

        public SpaceStation(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count+1<= this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astronaut = this.data.FirstOrDefault(a=> a.Name == name);
            if (astronaut == null)
            {
                return false;
            }

            this.data.Remove(astronaut);
            return true;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstronaut = this.data.OrderByDescending(a => a.Age).FirstOrDefault();
            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = this.data.FirstOrDefault(a => a.Name == name);
            return astronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            foreach (Astronaut astronaut in this.data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
