using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;
        private string color;
        private int capacity;
        private List<Present> list = new List<Present>();
        private int count=0;
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.Data = new List<Present>();
            this.List = new List<Present>();
            
        }
        public List<Present> Data
        {
            get { return data; }
            set { data = value; }
        }

        public List<Present> List
        {
            get { return list; }
            set { list = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        
        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        public void Add(Present present)
        {
            if (this.Capacity != 0 && !Data.Contains(present))
            {
                this.Data.Add(present);
                this.list.Add(present);
                this.Count++;
            }
        }

        public bool Remove(string name)
        {
            bool isHere = false;
            foreach (var present in Data)
            {
                if (present.Name == name)
                {
                    list.Remove(present);
                    this.Count--;
                    isHere = true;
                }
            }

            if (isHere)
            {
                this.Data = list;
                return true;

            }
            else
            {
                return false;
            }

        }

        public Present GetHeaviestPresent()
        {
            Present heavies=null;
            double weightest = int.MinValue;
            foreach (var present in Data)
            {
                if (present.Weight > weightest)
                {
                    heavies = present;
                }
            }
            return heavies;
        }

        public Present GetPresent(string name)
        {
            int index = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Name == name)
                {
                    index = i;
                }
            }
            return Data[index];
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in Data)
            {
                sb.AppendLine($"Present {present.Name} ({present.Weight}) for a {present.Gender}");
            }


            return sb.ToString();
        }
    }

}

