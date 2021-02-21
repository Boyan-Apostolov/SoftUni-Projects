using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> parkingLot = new HashSet<string>();

            while (input != "END")
            {
                string[] Args = input.Split(", ").ToArray();

                string command = Args[0];
                string number = Args[1];

                if (command == "IN")
                {
                    parkingLot.Add(number);
                }
                else if (command == "OUT")
                {


                    parkingLot.Remove(number);
                }

                input = Console.ReadLine();
            }

            if (parkingLot.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
            }

        }
    }
}
