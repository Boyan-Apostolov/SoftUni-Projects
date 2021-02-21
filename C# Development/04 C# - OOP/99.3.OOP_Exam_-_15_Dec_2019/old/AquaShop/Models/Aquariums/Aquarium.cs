using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public class Aquarium:IAquarium
    {
        private string name;

        public Aquarium(string name, int capacity)
        {
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; }
        public int Comfort => CalculateComfort();

        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }

        private int CalculateComfort()
        {
            int comfort = 0;
            foreach (var decoraions in this.Decorations)
            {
                comfort += decoraions.Comfort;
            }

            return comfort;
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.Fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            if (!this.Fish.Contains(fish))
            {
                return false;
            }

            this.Fish.Remove(fish);
            return true;
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            /*
             "{aquariumName} ({aquariumType}):
             Fish: {fishName1}, {fishName2}, {fishName3} (…) / none
             Decorations: {decorationsCount}
             Comfort: {aquariumComfort}"
             
             */
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name} ({GetType().Name})");

            if (this.Fish.Any())
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.Fish)}");
            }
            else
            {
                sb.AppendLine("Fish: none");
            }

            sb.AppendLine($" Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
