using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Workshop
{
    public class ListNode
    {
        public ListNode(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
        public ListNode NextNode { get; set; }
        public ListNode PreviousNode { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
