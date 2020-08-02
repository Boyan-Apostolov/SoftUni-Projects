using System;
using _03_ShoppingSpree.Core;

namespace _03_ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            try
            {
                Engine engine = new Engine();
                engine.Run();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
