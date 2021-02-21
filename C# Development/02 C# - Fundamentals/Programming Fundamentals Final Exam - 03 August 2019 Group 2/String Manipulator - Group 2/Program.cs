using System;

namespace String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] tokens = input.Split(" ");
                if (tokens[0] == "Change")
                {
                    char charToReplace = char.Parse(tokens[1]);
                    char replecementChar = char.Parse(tokens[2]);

                    text = text.Replace(charToReplace, replecementChar);
                    Console.WriteLine(text);
                }
                else if (tokens[0] == "Includes")
                {
                    string stringToInclude = tokens[1];
                    if (text.Contains(stringToInclude))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (tokens[0] == "End")
                {
                    string endingString = tokens[1];
                    if (text.EndsWith(endingString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (tokens[0] == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (tokens[0] == "FindIndex")
                {
                    char findIndex = char.Parse(tokens[1]);
                    int index = text.IndexOf(findIndex);
                    Console.WriteLine(index);
                }
                else if (tokens[0] == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);
                    text = text.Substring(startIndex, length);
                    Console.WriteLine(text);
                }
                input = Console.ReadLine();
            }
        }
    }
}
