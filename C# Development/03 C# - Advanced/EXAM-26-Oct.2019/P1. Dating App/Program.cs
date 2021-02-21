using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] males = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            ////Stack<int> male = new Stack<int>(males);
            //males.Reverse();

            List<int> males = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            

            //int[] females = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //Queue<int> female = new Queue<int>(females);

            List<int> females = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            
            ////for (int i = 0; i < Math.Abs(females.Count + males.Count); i++)
            //{

            //    if (!(males.Any() || females.Any()))
            //    {
            //        break;
            //    }

            //    if (i < males.Count)
            //    {
            //        if (males[i] <= 0)
            //        {
            //            males.Remove(males[i]);
            //        }
            //        else if (males[i] % 25 == 0)
            //        {
            //            males.Remove(males[i]);
            //        //    males.Remove(males[i + 1]);
            //        }
            //    }

            //    if (i < females.Count)
            //    {
            //        if (females[i] <= 0)
            //        {
            //            females.Remove(females[i]);
            //        }
            //        else if (females[i] % 25 == 0)
            //        {
            //            females.Remove(females[i]);
            //            //females.Remove(females[i + 1]);
            //        }
            //    }



            //    //matching
            //    if (females[i] == males[i])
            //    {
            //        males.Remove(males[i]);
            //        females.Remove(females[i]);
            //        matches++;
            //    }
            //    else
            //    {
            //        females.Remove(females[i]);
            //        males[i] -= 2;
            //    }

            //}



            Stack<int> maleCandidates = new Stack<int>(males);
            Queue<int> femaleCandidates = new Queue<int>(females);

            int matches = 0;

            while (femaleCandidates.Count != 0 && maleCandidates.Count != 0)
            {
                int girl = femaleCandidates.Peek();
                int guy = maleCandidates.Peek();

                maleCandidates = new Stack<int>(RefineMatches(maleCandidates.ToList()));

                maleCandidates.Reverse();

                femaleCandidates = new Queue<int>(RefineMatches(femaleCandidates.ToList()));

                if (girl == guy)
                {
                    femaleCandidates.Dequeue();
                    maleCandidates.Pop();
                    matches++;
                }

                else
                {
                    femaleCandidates.Dequeue();

                    maleCandidates.Push(maleCandidates.Pop() - 2);
                }

            }

            Console.WriteLine($"Matches: {matches}");

            //Pinting males
            if (males.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Join(", ", males));
                Console.WriteLine($"Males left: {sb}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }

            //Printing Females
            if (females.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Join(", ", females));
                Console.WriteLine($"Females left: {sb}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }

            static List<int> RefineMatches(List<int> people)
            {

                people.RemoveAll(x => x <= 0);

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i] % 25 == 0)
                    {
                        people.RemoveAt(i);

                        if (i < people.Count)
                        {
                            people.RemoveAt(i);
                        }

                    }
                }


                return people;
            }
        }
    } }
