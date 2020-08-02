using System;
using System.Collections.Generic;
using System.Text;

namespace pzl
{
    public class Threeuple<TFirst,TSecond,TThird>
    {
        public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondIteme = secondItem;
            this.ThirdItem = thirdItem;
        }
        public TFirst FirstItem { get; set; }
        public TSecond SecondIteme { get; set; }
        public TThird ThirdItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondIteme} -> {this.ThirdItem}";
        }
    }
}
