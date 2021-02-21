using System;
using System.Collections.Generic;
using System.Text;

namespace P7._Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstItem,TSecond secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondIteme = secondItem;
        }
        public TFirst FirstItem { get; set; }
        public TSecond SecondIteme { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondIteme}";
        }
    }
}
