using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Query_To_Collection
{
    class Car
    {
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";
    }

    class Program
    {
        static int Main(string[] args)
        {
            // Linq works with Generic containers
            {
                LinqOverGenericCollections();

            }

            // Linq works with Non-generic containers
            {
                /*
                
                + background
                    >> Linq query expr works on any IEnumerable<T> container types;
                    >> Astonishingly, containers of System.Collections have no IEnumerable<T> implementation;
                
                + solution
                    >> using generic Enumerable.OfType<T>() extension method to transfer to IEnumerable<T>-compatible object;
                
                */ 
                LinqOverNongenericCollections();

            }

            // using OfType<T>() to filter
            {
                OfTypeFilter();
            }

            return 0;
        }

        static void LinqOverGenericCollections()
        {
            System.Console.WriteLine("=> Linq over generic collections:");

            List<Car> myCars = new List<Car>
            {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            var CarSpeedGreaterThan55 = 
                from c in myCars
                where c.Speed > 55
                select c;
            
            foreach(Car c in CarSpeedGreaterThan55)
                System.Console.WriteLine("{0} is going to fast!", c.Name);

            Console.ReadLine();

        }

        static void LinqOverNongenericCollections()
        {
            System.Console.WriteLine("=> Linq over non-generic collections:");

            ArrayList myCars = new ArrayList()
            {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            
            // transform ArrayList into an IEnumerable<T>-compatible type;
            var myCarsEnum = myCars.OfType<Car>();

            var subset = 
                from c in myCarsEnum
                where c.Speed > 90 && c.Make == "BMW"
                orderby c
                select c;
            

            foreach(var c in subset)
                System.Console.WriteLine("{0} is going too fast", c.Name);
        }

        static void OfTypeFilter()
        {
            System.Console.WriteLine("=> using OfType<T> to filter:");

            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] {10, 400, 8, false, new Car(), "string data"});
            var myInts = myStuff.OfType<int>();

            foreach(int i in myInts)
                System.Console.WriteLine("Int value: {0}", i);

            Console.ReadLine();
        }
        
    }
}