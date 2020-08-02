using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_Telephony
{
    public class Engine : IEngine
    {
        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;
        

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone =new Smartphone();
        }
        public void Run()
        {
            string[] phoneNUmbers = Console.ReadLine().Split().ToArray();
            string[] sites = Console.ReadLine().Split().ToArray();
            foreach (var number in phoneNUmbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
            }

            foreach (var url in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
