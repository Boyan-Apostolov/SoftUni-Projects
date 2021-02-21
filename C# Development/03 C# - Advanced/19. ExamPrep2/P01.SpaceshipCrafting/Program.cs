using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.SpaceshipCrafting
{
    class Program
    {
        private const int GLASS_MIN_VALUE = 25;
        private const int ALUMINUIM_MIN_VALUE = 50;
        private const int LITHIUM_MIN_VALUE = 75;
        private const int CARBON_FIBER_MIN_VALUE = 100;
        static void Main(string[] args)
        {
            int[] luquidsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] REEEEEphysicalItemsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> chemicalLuqids = new Queue<int>(luquidsInput);
            Stack<int> physicalItems = new Stack<int>(REEEEEphysicalItemsInput);
            int glasscount = 0;
            int aluminiumcount = 0;
            int carboncount = 0;
            int lithiumcount = 0;

            while (chemicalLuqids.Count>0 && physicalItems.Count>0)
            {
                int currentLuqid = chemicalLuqids.Dequeue();
                int currentItem = physicalItems.Pop();
                int currentSum = currentItem + currentLuqid;

                switch (currentSum)
                {
                    case GLASS_MIN_VALUE:
                        glasscount++;
                        break;
                    case ALUMINUIM_MIN_VALUE:
                        aluminiumcount++;
                        break;
                    case LITHIUM_MIN_VALUE:
                        lithiumcount++;
                        break;
                    case CARBON_FIBER_MIN_VALUE:
                        carboncount++;
                        break;
                    default:
                        physicalItems.Push(currentItem+3);
                        break;
                        
                }
            }

            if (glasscount > 0 && aluminiumcount > 0 && lithiumcount > 0 && carboncount > 0) 
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            string liqstr = chemicalLuqids.Count > 0 ? string.Join(", ", chemicalLuqids) : "none";
            Console.WriteLine($"Liquids left: {liqstr}");
            string items = physicalItems.Count > 0 ? string.Join(", ", physicalItems) : "none";
            Console.WriteLine($"Physical items left: {liqstr}");
            Console.WriteLine($"Aluminium: {aluminiumcount}");
            Console.WriteLine($"Glass: {glasscount}");
            Console.WriteLine($"Lithium: {lithiumcount}");
        }
    }
}
