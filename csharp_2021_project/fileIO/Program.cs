using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            // var
            Console.WriteLine("\nvar;");
            int x = 10, y = 12;
            Console.WriteLine("x = {0}, y = {1}", x, y);
            Console.WriteLine($"x + y = {x + y}");
            Console.WriteLine($"x - y = {x - y}");
            Console.WriteLine($"x * y = {x * y}");
            Console.WriteLine($"x / y = {x / y}");
            Console.WriteLine($"x % y = {x % y}");
            // func
            Console.WriteLine("\nfunc;");

            // if else; switch case;
            Console.WriteLine("\nif else; switch case;");
            int c = 18;
            if (c <= 5)
            {
                Console.WriteLine("go to kindergarden");
            }
            else if (c > 5 && c <= 12)
            {
                Console.WriteLine("go to primary school");
            }
            else if (c > 5 && c <= 12)
            {
                Console.WriteLine("go to middle school");
            }
            else if (c > 12 && c < 18)
            {
                Console.WriteLine("go to high school");
            }
            else
            {
                Console.WriteLine("do w/e u want");
            };
            // loop
            Console.WriteLine("\nloop");

            for (int i =0; i <5; ++i)
            { 
                Console.Write(i.ToString()); 
                Console.Write("\t"); 
            }
            Console.WriteLine();

            int a = 0;
            while(a < 10)
            {
                ++a;
                if (a % 3 == 0 || a % 5 == 0)
                {
                    continue;
                }
                Console.Write(a.ToString());
                Console.Write("\t");
            }

            // cls

            Console.ReadKey();

        }
    }
}
