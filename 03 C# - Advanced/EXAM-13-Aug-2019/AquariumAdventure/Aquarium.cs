using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        public List<Fish> FishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.FishInPool = new List<Fish>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }


        public void Add(Fish name)
        {
            if (this.FishInPool.Count + 1 <= Capacity && !this.FishInPool.Contains(name))
            {
                this.FishInPool.Add(name);
            }
        }

        public bool Remove(string name)
        {
            foreach (var item in FishInPool)
            {
                if (item.Name == name)
                {
                    this.FishInPool.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public Fish FindFish(string name)
        {

            Fish fish = FishInPool.Where(x => x.Name == name).FirstOrDefault();
            return fish;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var fish in FishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
