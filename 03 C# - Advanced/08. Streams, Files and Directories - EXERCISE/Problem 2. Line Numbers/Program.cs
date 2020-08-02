using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];

                int lettersCount = CountOfLetters(currLine);
                int marksCount = CountOFPuntMarks(currLine);

                lines[i] = $"Line {i + 1}: {currLine} ({lettersCount})({marksCount})";
            }

            File.WriteAllLines("output.txt", lines);

        }
        static int CountOfLetters(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (Char.IsLetter(currSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }

        static int CountOFPuntMarks(string line)

        {
            int counter = 0;
            char[] marks = { '-', ',', '.', '!', '?' };

            for (int i = 0; i < line.Length; i++)
            {
                char currSumbol = line[i];

                if (marks.Contains(currSumbol))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
