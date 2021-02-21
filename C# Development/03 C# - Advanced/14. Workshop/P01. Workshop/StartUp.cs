using System;
using System.Collections.Generic;
using System.Linq;
namespace P01._Workshop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            for (int i = 0; i < 3; i++)
            {
                doublyLinkedList.AddFirst(i);
            }

            for (int i = 0; i <= 3; i++)
            {
                doublyLinkedList.RemoveFirst();
            }
        }
    }
}
