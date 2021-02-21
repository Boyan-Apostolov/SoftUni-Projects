using System;
using System.Collections.Generic;
using System.Text;

namespace please
{
    public class Box<T>
    {
        public Box( T values)
        {
            this.Values = values;
        }

        public T Values { get; set; }

        public override string ToString()
        {
            return $"{this.Values.GetType()}: {this.Values}";
        }

        
    }
}
