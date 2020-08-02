using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquarium);

            string result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            
            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {

            IFish fish;
            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquariumt = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (fish.GetType() == typeof(FreshwaterFish) && aquariumt.GetType() == typeof(FreshwaterAquarium))
            {
                aquariumt.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            if (fish.GetType() == typeof(SaltwaterFish) && aquariumt.GetType() == typeof(SaltwaterAquarium))
            {
                aquariumt.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string FeedFish(string aquariumName)
        {
            var aquariumt = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in aquariumt.Fish)
            {
                fish.Eat();
            }

            return string.Format(OutputMessages.FishFed, aquariumt.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var totalPrice = aquarium.Fish.Sum(p => p.Price) + aquarium.Decorations.Sum(p => p.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
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
