using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Workshop
{
    public class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        //Add - FRONT
        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode(element);
                this.tail = new ListNode(element);
            }
            else
            {
                ListNode newHead = new ListNode(element);
                ListNode oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;
            }
            this.Count++;
        }


        //Add - BACK
        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                ListNode newTail = new ListNode(element);
                ListNode oldTail = new ListNode(element);

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }
            this.Count++;
        }


        //Remove - FRONT
        public int RemoveFirst()
        {
            int? removedElement = this.head?.Value;
            if (this.Count == 0 || !removedElement.HasValue)
            {
                throw new InvalidOperationException("List is empty.");

            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }
            this.Count--;
            return removedElement.Value;
        }


        //Remove - BACK
        public int RemoveLast()
        {
            int? removedElement = this.tail?.Value;
            if (this.Count == 0 || !removedElement.HasValue)
            {
                throw new InvalidOperationException("List is empty.");
            }
            else if (this.Count == 1)
            {
                this.tail = null;
                this.head = null;
            }
            else
            {
                ListNode newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }
            this.Count--;

            return removedElement.Value;
        }

        //ForEach 
        public void ForEach(Action<int> action)
        {
            ListNode currentEl = this.head;

            while (currentEl != null)
            {
                action(currentEl.Value);
                currentEl = currentEl.NextNode;
            }
        }

        //ToArray- returns array
        public int[] ToArray()
        {
            int[] array = new int[this.Count];

            int counter = 0;
            ListNode currentEl = this.head;

            while (currentEl != null)
            {
                array[counter++] = currentEl.Value;
                currentEl = currentEl.NextNode;
            }

            return array;
        }
    }
}
