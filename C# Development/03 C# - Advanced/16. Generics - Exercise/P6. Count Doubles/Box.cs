using System;
using System.Collections.Generic;
using System.Text;

namespace please
{
    public class Box<T> where T : IComparable
    {
        public Box( List<T> value)
        {
            this.Values = value;
        }

        public List<T> Values { get; set; }

        public override string ToString()
        {
            return $"{this.Values.GetType()}: {this.Values}";
        }

        public int CountGreaterElements(List<T> elements, T elementToCompare)
        {
            int counter = 0;
            foreach (var element in elements)
            {
                if (elementToCompare.CompareTo(element) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        
    }
}
