using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(":").ToList();
            string[] commandArgs = Console.ReadLine().Split(" ").ToArray();
            List<string> deck = new List<string>();

            while (commandArgs[0] != "Ready")
            {
                switch (commandArgs[0])
                {
                    case "Add":
                        string currentCard = commandArgs[1];

                        if (cards.Contains(currentCard))
                        {
                            deck.Add(currentCard);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;

                    case "Insert":
                        string cardName = commandArgs[1];
                        int cardIndex = int.Parse(commandArgs[2]);

                        if ((cards.Contains(cardName)) && (cardIndex >= 0 && cardIndex <= cards.Count-1))
                        {
                            deck.Insert(cardIndex, cardName);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;

                    case "Remove":
                        string cardToRemove = commandArgs[1];
                        if (deck.Contains(cardToRemove))
                        {
                            deck.Remove(cardToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;

                    case "Swap":
                        string cardIndex1 = commandArgs[1];
                        string cardIndex2 = commandArgs[2];

                        int indexOfCard1 = 0;

                        int indexOfCard2 = 0;

                        for (int i = 0; i <= deck.Count-1; i++)
                        {
                            if (deck[i] == cardIndex1)
                            {
                                indexOfCard1 = i;
                            }
                        }
                        for (int i = 0; i <= deck.Count-1; i++)
                        {
                            if (deck[i] == cardIndex2)
                            {
                                indexOfCard2 = i;
                            }
                        }



                        string temp = deck[indexOfCard1];
                        deck[indexOfCard1] = deck[indexOfCard2];
                        deck[indexOfCard2] = temp;


                        break;

                    case "Shuffle":
                        deck.Reverse();
                        break;
                }
                commandArgs = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine(string.Join(" ",deck));
        }
    }
}
