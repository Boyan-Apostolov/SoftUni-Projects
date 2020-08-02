using System;
using System.Xml.Linq;

namespace P01_Prototype
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();
            sandwichMenu["BLT"] = new Sandwich("Wheat","Bacon", "", "Lettuce, Tomatues");
            sandwichMenu["PB&J"] = new Sandwich("White", "","", "PB&Jelly");

            Sandwich blt1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich pbj1 = sandwichMenu["PB&J"].Clone() as Sandwich;
            Sandwich blt2 = sandwichMenu["BLT"].Clone() as Sandwich;

        }
    }
}
