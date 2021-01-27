using System;   // for iostream

/*
wait, it does not compile as well.

procedures:
- add reference and select System.Numerics.dll

*/

// ancm?

namespace BuildApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // setup Console GUI
            Console.Title = "My Rocking App";
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;

            System.Console.WriteLine("*************************************");
            System.Console.WriteLine("***** Welcome to My Rocking App *****");
            System.Console.WriteLine("*************************************");

            Console.BackgroundColor = ConsoleColor.Black;

            // wait
            Console.ReadLine();
            
        }

    }
}