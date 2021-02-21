using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private string name;
        private int capacity;
        private List<Rabbit> rabbits;
        private List<Cage> cages;
        private bool available;
        private int count;


        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Rabbit>(capacity);

            this.Available = true;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<Rabbit> Data
        {
            get { return rabbits; }
            set { rabbits = value; }
        }

        public int Count
        {
            get { return Data.Count; }

        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }




        //Methods:
        public void Add(Rabbit rabbit)
        {
            if (this.Data.Count < capacity)
            {
                this.Data.Add(rabbit);

            }
        }

        //FIX
        public bool RemoveRabbit(string name)
        {

            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Name == name)
                {

                    Data.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Species == species)
                {
                    Data.RemoveAt(i);
                }
            }
        }

        public string SellRabbit(string name)
        {
            string spc = null;
            string nam = null;
            foreach (Rabbit rabbit in Data)
            {
                if (rabbit.Name == name)
                {
                    this.Available = false;
                    spc = rabbit.Species;
                    nam = rabbit.Name;

                }
            }

            return $"Rabbot ({spc}): {nam}";
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var soldRabbits = this.Data.Where(x => x.Species == species).ToList();
            for (int i = 0; i < soldRabbits.Count; i++)
            {
                soldRabbits[i].Available = false;
            }
            return soldRabbits.ToArray();
        }



        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Rabbits available at {this.Name}:");
            sb.AppendLine();

            foreach (Rabbit rabbit in Data)
            {
                if (rabbit.Available)
                {
                    sb.AppendLine($"Rabbit ({rabbit.Species}): {rabbit.Name}");
                }
            }
            return sb.ToString();
        }
    }
}
