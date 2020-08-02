using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : IElectricCar, ICar
    {


        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Batteries = batteries;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Batteries { get; }

        public virtual string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Batteries} Batteries").AppendLine(this.Start()).AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }


    }
}
