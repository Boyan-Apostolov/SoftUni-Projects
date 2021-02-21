using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine().Split(" ").ToList();
            string[] commandArgs = Console.ReadLine().Split(" ").ToArray();

            while (commandArgs[0] != "No")
            {
                switch (commandArgs[0])
                {
                    case "OutOfStock":
                        string outOfStockGift = commandArgs[1];

                        for (int i = 0; i <= gifts.Count-1; i++)
                        {
                            if (gifts[i] == outOfStockGift)
                            {
                                gifts[i] = "None";
                                
                            }
                        }

                        break;

                    case "Required":
                        string giftToReplaceWith = commandArgs[1];
                        int indexToReplace = int.Parse(commandArgs[2]);

                        if (indexToReplace >= 0 && indexToReplace <= gifts.Count)
                        {
                            for (int i = 0; i <= gifts.Count-1; i++)
                            {
                                if (i == indexToReplace)
                                {
                                    gifts[i] = giftToReplaceWith;
                                    
                                }
                            }
                        }

                        break;

                    case "JustInCase":
                        string inCaseGift = commandArgs[1];

                        gifts[gifts.Count-1] = inCaseGift;
                        break;
                }
                commandArgs = Console.ReadLine().Split(" ").ToArray();
            }

            foreach (string gift in gifts)
            {
                if (!(gift == "None"))
                {
                    Console.Write(gift+' ');
                }
            }

        }
    }
}
