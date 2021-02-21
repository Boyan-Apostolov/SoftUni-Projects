using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T first, T second)
        {
            this.left = first;
            this.right = second;
        }

        public bool AreEqual()
        {
            return this.left.Equals(this.right);
        }
    }
}
