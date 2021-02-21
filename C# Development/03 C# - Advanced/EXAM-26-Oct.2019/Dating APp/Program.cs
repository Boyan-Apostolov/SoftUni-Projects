using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dating_APp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> males = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> females = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Stack<int> stack = new Stack<int>(males);
            Stack<int> maleStack = stack;
            maleStack.Reverse();
            Queue<int> femaleStack = new Queue<int>(females);

            int matches = 0;

            while (femaleStack.Count != 0 && maleStack.Count != 0)
            {
                int female = femaleStack.Peek();
                int male = maleStack.Peek();

                if (male > 0 && female > 0)
                {
                    if (male % 25 == 0 || female % 25 == 0)
                    {
                        if (male % 25 == 0)
                        {
                            if (maleStack.Count > 1)
                            {
                                maleStack.Pop();
                                maleStack.Pop();
                            }
                            else
                            {
                                maleStack.Pop();
                            }
                        }

                        if (female % 25 == 0)
                        {
                            if (femaleStack.Count > 1)
                            {
                                femaleStack.Dequeue();
                                femaleStack.Dequeue();
                            }
                            else
                            {
                                femaleStack.Dequeue();
                            }
                        }
                        continue;
                    }
                }

                if (male <= 0 || female <= 0)
                {
                    if (male <= 0)
                    {
                        maleStack.Pop();
                    }
                    if (female <= 0)
                    {
                        femaleStack.Dequeue();
                    }
                    continue;
                }

                if (female == male)
                {
                    femaleStack.Dequeue();
                    maleStack.Pop();
                    matches++;
                }
                else
                {
                    femaleStack.Dequeue();

                    male -= 2;
                    maleStack.Push(maleStack.Pop() - 2);

                }
            }

            Console.WriteLine($"Matches: {matches}");

            //Pinting males
            if (maleStack.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Join(", ", maleStack));
                Console.WriteLine($"Males left: {sb}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }

            //Printing Females
            if (femaleStack.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Join(", ", femaleStack));
                Console.WriteLine($"Females left: {sb}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }

        }
    }
}
