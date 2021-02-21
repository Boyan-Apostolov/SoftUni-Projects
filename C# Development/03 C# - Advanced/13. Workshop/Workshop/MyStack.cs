using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class MyStack
    {
        private int capacity;
        public int Count { get; set; }
        private int[] data;

        public MyStack() :this(4)
        {
       
        }

        

        public MyStack(int capacity)
        {
            this.data = new int[capacity];
            this.capacity = capacity;
        }

        public void Push(int number)
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }

            this.data[this.Count] = number;
            this.Count++;
        }

        private void Resize()
        {
            var newCapacity =this.data.Length * 2;
            var newData = new int[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        public int Pop(int number)
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
            var result = this.data[Count - 1];
            this.Count--;
            return result;

        }

        public int Peek(int number)
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
            var result = this.data[Count - 1];
            
            return result;
        }

        public void Clear()
        {
            this.data = new int[this.capacity];
            this.Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count-1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }
    }
}
