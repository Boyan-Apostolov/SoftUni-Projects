using System;

namespace pzl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            string fullname = $"{personInfo[0]} {personInfo[1]}";
            string address = $"{personInfo[2]}";
            string town = personInfo[3]; //new
            
            var nameAndBeer = Console.ReadLine().Split();
            string name = nameAndBeer[0];
            int beerAmount = int.Parse(nameAndBeer[1]);
            bool isDrunk = false; // new
            if (nameAndBeer[2] == "drunk")
            {
                isDrunk = true;
            }

            var thirdInput = Console.ReadLine().Split();
            string hisName = thirdInput[0];
            double bankBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            Tuple<string, string,string> firsttr = new Tuple<string, string,string>(fullname, address,town);
            Tuple<string, int,bool> secondtr = new Tuple<string, int,bool>(name, beerAmount,isDrunk);
            Tuple<string, double, string> thirdtr = new Tuple<string, double, string>(hisName, bankBalance, bankName);
            Console.WriteLine(firsttr);
            Console.WriteLine(secondtr);
            Console.WriteLine(thirdtr);
        }
    }
}
