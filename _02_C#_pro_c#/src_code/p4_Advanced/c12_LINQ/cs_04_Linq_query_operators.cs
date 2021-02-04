using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Query_Operator
{
    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; } = 0;

        public override string ToString()
        => $"Name={Name}, Description={Description}, Number in Stock={NumberInStock}";
    }

    class Program
    {
        static int Main(string[] args)
        {
            // Linq operators
            {
                /*
                
                + common linq ops
                    - from, in
                    - Where
                    - Select
                    - join, on, equals, into
                    - orderby, ascending, descending
                    - group, by

                
                + non direct query operator shorthand methods(extension methods)
                    - Reverse<>()
                    - ToArray<>()
                    - ToList<>()
                    
                    - Exept<>()
                    - Interset<>()
                    - Union<>()
                    - Concat<>()

                    - Distinct<>();         // remove duplicates

                    - Count<>()
                    - Sum<>()
                    - Average<>()
                    - Min<>()
                    - Max<>()

                    - Count

                + syntax
                    `var subset = from item in items where condition orderby ascending[descending] select item;`
                */ 

                FuckWithQueryExpr();
            }

            // basic selection syntax
            {   
                FuckWithQueryExpr();
            }

            // Linq as a better Venn Diagramming tool, P524
            {
                DisplayDiff();
            }

            return 0;
        }

        static void FuckWithQueryExpr()
        {
            System.Console.WriteLine("=> Fun with query expr:");

            ProductInfo[] itemsInstock = new[]{
                new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH",
                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love",
                NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible",
                NumberInStock = 120},
                new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness",
                NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet",
                NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!",
                NumberInStock = 73},
            };

            SelectEverything(itemsInstock);

            Console.ReadLine();
        }
        
        static void SelectEverything(ProductInfo[] products)
        {
            System.Console.WriteLine("All product details:");

            var allProducts = from p in products select p;

            foreach(var p in allProducts)
                System.Console.WriteLine(p.ToString());

            Console.ReadLine();
        }
        
        static void SelectProductName(ProductInfo[] products)
        {
            System.Console.WriteLine("All product details:");

            var names = from p in products select p.Name;

            foreach(var name in names)
                System.Console.WriteLine(name.ToString());

            Console.ReadLine();
        }

        static void DisplayDiff()
        {
            List<string> myCars = new List<string>{"Yugo", "Aztec", "BMW"};
            List<string> yrCars = new List<string>{"BMW", "Saab", "Aztec"};

            var carDiff = (from c in myCars select c).Except(from c2 in yrCars select c2);

            System.Console.WriteLine("=>here is what u dont have, but I do:");
            foreach(string s in carDiff)
                System.Console.WriteLine(s);

            Console.ReadLine();
        }

    }
}