using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private string name;
        private int evergyreq;

        public Present(string name,int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.evergyreq;
            private set { this.evergyreq = value > 0 ? value : 0; }
        }

        public void GetCrafted() => this.EnergyRequired -= 10;

        public bool IsDone() => this.EnergyRequired == 0;
    }
}
