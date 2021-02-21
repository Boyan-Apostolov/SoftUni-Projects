using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Riders
{
    public abstract class Rider : IRider
    {
        private string name;
        private int laps;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 5));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; }

        public int NumberOfWins
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Join(ExceptionMessages.InvalidNumberOfLaps,1));
                }

                this.laps = value;
            }
        }

        public bool CanParticipate { get; }

        public void WinRace()
        {
            throw new NotImplementedException();
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }
    }
}
