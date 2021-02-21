using System;
using System.Linq;
namespace _6._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersString = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            

            var line = string.Empty;

            while (line != "end")
            {
                line = Console.ReadLine();

                string[] lineParameters = line.Split();

                switch (lineParameters[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(lineParameters[1]);
                        numbersString.Add(numberToAdd);
                        break;
                    //To do
                    case "Remove":
                        int numberToRemove = int.Parse(lineParameters[1]);
                        numbersString.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int indexToRemoveAt = int.Parse(lineParameters[1]);
                        numbersString.RemoveAt(indexToRemoveAt);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(lineParameters[1]);
                        int indexToInserAt = int.Parse(lineParameters[2]);
                        numbersString.Insert(indexToInserAt, numberToInsert);
                        break;

                }


            } 

            Console.WriteLine(string.Join(" ", numbersString));

        }
    }
}
