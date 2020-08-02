using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                var aquarium = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
                return $"Successfully added {aquariumType}.";
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                var aquarium = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
                return $"Successfully added {aquariumType}.";
            }
            else
            {
                throw new ArgumentException("Invalid aquarium type.");
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                var decoration = new Ornament();
                this.decorations.Add(decoration);
                return $"Successfully added {decorationType}.";
            }
            else if (decorationType == "Plant")
            {
                var decoration = new Plant();
                this.decorations.Add(decoration);
                return $"Successfully added {decorationType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }

            if (!this.decorations.Models.Contains(decoration))
            {

                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            this.aquariums.Remove(aquarium);
            this.decorations.Remove(decoration);

            aquarium.AddDecoration(decoration);

            this.aquariums.Add(aquarium);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            this.aquariums.Remove(aquarium);
            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                this.aquariums.Add(aquarium);
                throw new InvalidOperationException("Invalid fish type.");
            }

            if (fishType == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                aquarium.Fish.Add(fish);
                this.aquariums.Add(aquarium);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

            if (fishType == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                aquarium.Fish.Add(fish);
                this.aquariums.Add(aquarium);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

            this.aquariums.Add(aquarium);
            throw new InvalidOperationException("Water not suitable.");
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            this.aquariums.Remove(aquarium);

            aquarium.Feed();
            this.aquariums.Add(aquarium);
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            this.aquariums.Remove(aquarium);

            int value = aquarium.Fish.Count + aquarium.Decorations.Count;

            this.aquariums.Add(aquarium);

            return $"The value of Aquarium {aquariumName} is {value}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}
