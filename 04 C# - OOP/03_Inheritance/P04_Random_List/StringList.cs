using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Random_List
{
    public class StringList : List<string>
    {
        public string RemoveString()
        {
            var random = new Random();

            var index = random.Next(0, this.Count);
            var element = this[index];

            this.RemoveAt(index);
            return element;
        }
    }
}
