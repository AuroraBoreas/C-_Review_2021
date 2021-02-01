using System;

namespace Custom_Generic_Struct_Class
{
        struct Point<T>
        {
            public T X { get; set; }
            public T Y { get; set; }

            public Point(T x, T y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            => $"[{X}, {Y}]";

            // reset TValue
            public void ResetPoint()            
            {
                X = default(T);
                Y = default(T);
            }
        }
    class Program
    {

        static int Main(string[] args)
        {
            // Custom Generic Struct and classes, P411
            {
                /*
                
                + concept
                    - class template in C++

                + 
                
                */ 

                // see class Point;

            }

            // default(T) kw
            {
                /*
                
                + default
                    - "default" kw is overloaded in C#;
                    - when used with generics, it represents the default value of a type param;

                    >> common rules:
                        - numeric values have a default value of 0;
                        - reference types have a default value of null;
                        - fieds of a struct are set to 0 or null

                + default clause in switch..case..default statement

                */ 
                FuckWithGenericStruct();

            }

            return 0;
        }

        static void FuckWithGenericStruct()
        {
            System.Console.WriteLine("=> Fun with generic structs:");

            Point<int> p = new Point<int>(10, 10);
            System.Console.WriteLine("p.ToString()={0}", p.ToString());
            p.ResetPoint();
            System.Console.WriteLine("p.ToString()={0}", p.ToString());
            System.Console.WriteLine();

            // using double
            Point<double> p2 = new Point<double>(3.14, 2.718);
            System.Console.WriteLine("p2.ToString()={0}", p2.ToString());
            p2.ResetPoint();
            System.Console.WriteLine("p2.ToString()={0}", p2.ToString());
            
            Console.ReadLine();

        }
        
    }
}