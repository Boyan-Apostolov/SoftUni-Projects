using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)        //add, multiply, subtract, divide
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (command== "add")
            {
                Console.WriteLine(a+b);
            }
            else if (command== "multiply")
            {
                Console.WriteLine(a*b);
            }
            else if (command== "subtract")
            {
                Console.WriteLine(a - b);
            }
            else if (command== "divide")
            {
                Console.WriteLine(a/b);
            }












          //  switch (command)
          //  {
              //  case "ädd": Add(a, b); break;
              //  case "multiply": Multiply(a, b); break;
               // case "subtract": Subtract(a, b); break;
               // case "divide": Devide(a, b); break;

//default:
               //     break;
           // }
            

        }

       // static void Add(double first, double second)
      //  {

       //     Console.WriteLine( first + second);
            
       // }
//static void Multiply(double first, double second)
      //  {
      //     Console.WriteLine(first * second);
      //  }
     //   static void Subtract(double first, double second)
      //  {
      //      Console.WriteLine(first - second);
      //  }
      //  static void Devide(double first, double second)
      //  {
      //      Console.WriteLine(first / second);
      //  }
    }
}
