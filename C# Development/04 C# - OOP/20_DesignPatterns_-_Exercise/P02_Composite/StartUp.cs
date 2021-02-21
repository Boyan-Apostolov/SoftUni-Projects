using System;

namespace P02_Composite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootbox = new CompositeGift("RootBox",0);
            SingleGift sg = new SingleGift("TruckToy",289);
            SingleGift plain = new SingleGift("PlaneToy",587);

            rootbox.Add(sg);
            rootbox.Add(plain);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            SingleGift soldier = new SingleGift("SoldierToy", 200);

            childBox.Add(soldier);

            rootbox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is {rootbox.CalculateTotalPrice()}");
        }
    }
}
