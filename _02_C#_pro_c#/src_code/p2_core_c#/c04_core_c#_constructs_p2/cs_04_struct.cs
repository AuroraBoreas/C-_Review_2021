using System;

namespace Struct_Type
{
    class Program
    {
        public static void Main(string[] args)
        {
            // struct
            {
                /*
                
                + mechanism: same concept in C/C++
                
                */ 
            }
        }

        struct Point
        {
            private int x;
            private int y;

            public void Increment()
            {
                x++; y++;
            }

            public void Decrement()
            {
                x--; y--;
            }

            public void Display()
            {
                System.Console.WriteLine($"x = {x}, y = {y}");
            }
        }

        private static void UsePoint()
        {
            System.Console.WriteLine("=> struct demo:");

            Point myPoint;
            myPoint.x = 349;
            myPoint.y = 76;
            myPoint.Display();

            // adjust
            myPoint.Increment();
            myPoint.Display();
            
            Console.ReadLine();
            
        }


    }
}