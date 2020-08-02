using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class MyList
    {
        private int[] data;
        private int capacity;
        public MyList() : this(4)
        {

        }
        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }
        public int Count { get; private set; }


        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }

        public void Add(int number)
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }
            this.data[this.Count] = number;
            this.Count++;
        }

        private void Resize()
        {
            var nextCapacity = this.data.Length * 2;
            var newArray = new int[nextCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newArray[i] = this.data[i];

            }
            this.data = newArray;
        }
        public void Clear()
        {
            this.Count = 0;
            this.data = new int[capacity];
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                var message = this.Count == 0 ? "The list is Empty" : $"The list has {this.Count} elements and its zero-based";
                throw new Exception($"Index out of range. {message}");
            }
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i] == element)
                {
                    return true;
                }
                
                

            }
            return false;
        }
        public void Insert(int index, int element)
        {
            this.ValidateIndex(index);

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }
            this.data[index] = element;
            this.Count++;
        }
        private void CheckIfResizeIsNeeded()
        { 
        
        }
        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var result = this.data[index];
            for (int i = index+1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }
            this.Count--;
            return result;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);
            
            var firstValue = this.data[firstIndex];
            var secondValue = this.data[secondIndex];

            this.data[secondIndex] = firstValue;
            this.data[firstIndex] = secondValue;
        }
    }
}
