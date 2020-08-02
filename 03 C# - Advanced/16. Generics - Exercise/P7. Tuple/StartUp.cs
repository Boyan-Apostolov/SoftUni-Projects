using System;

namespace P7._Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            string fullname = $"{personInfo[0]} {personInfo[1]}";
            string address = $"{personInfo[2]}";

            var nameAndBeer = Console.ReadLine().Split();
            string name = nameAndBeer[0];
            int beerAmount = int.Parse(nameAndBeer[1]);

            var thirdInput = Console.ReadLine().Split();
            var firstArg = int.Parse(thirdInput[0]);
            var secondArgs = double.Parse(thirdInput[1]);
            Tuple<string, string> firsttr = new Tuple<string, string>(fullname, address);
            Tuple<string, int> secondtr = new Tuple<string, int>(name, beerAmount);
            Tuple<int, double> thirdtr = new Tuple<int, double>(firstArg, secondArgs);
            Console.WriteLine(firsttr);
            Console.WriteLine(secondtr);
            Console.WriteLine(thirdtr);
        }
    }
}
