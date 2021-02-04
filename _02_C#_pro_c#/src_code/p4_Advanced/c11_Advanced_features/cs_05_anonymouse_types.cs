using System;

namespace AnonymouseTypes
{

    class SomeClass // <-- regular class declaration and defintion
    {
        // data members
        // ctors
        // props
        // methods

    }

    class Program
    {

        static int Main(string[] args)
        {
            // anonymouse types
            {

                /*
                
                + why?
                    - when u would like to define a class simple to model a set of encapsulated (and related) data points
                    W/O any associated methods, events, or other specialized functionality;

                    - what if this type is to be used only by a handful of methods in your prg?
                    
                    >> it would be rather a bother to define a full class

                    >> we programmers are lazy af

                    >> we use anonymouse types as a solution
                
                + mechanism: it's similar with namedtuple in Python? but step further..
                    >> AnonymousType is automatically derived from System.Object;
                    >> syntax is initialization_list: `new { Name-Value pairs; };`
                
                + note
                    >> Anonymous types typically are used in the select clause of a query expression to return a subset of the properties from each object in the source sequence
                
                
                */
                FuckWithAnonymousTypes();
            }

            // equality
            {
                /*
                
                + equality test
                    - (compiler generated) Equals() method, value-based comparison;
                    - (non override) == operator, reference-based comparison;
                
                + note
                    >> comiler will generate a new class definition ONLY
                    when an anonymous type contain UNIQUE names of the anonymous type;

                    >> thus, if u declare identical anonymous types(again, meaning the same name) within the same assembly,
                    the compiler generates ONLY a single anonymous type definition;
                
                
                */ 
                FuckWithAnonymousType_equality_test();
            }

            // Anonymous Types in Anonymous Types
            {
                AnonymouseInAnonymous();
            }

            return 0;
        }

        private static void RefectOverAnonymousType(object obj)
        {
            System.Console.WriteLine("obj is an instance of : {0}", obj.GetType().Name);
            System.Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            System.Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            System.Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            System.Console.WriteLine();
        }

        static void FuckWithAnonymousTypes()
        {
            System.Console.WriteLine("=> fun with anonymous types:");

            // it's similar with namedtuple in Python? but step further..
            var myCar = new {Color="Bright Pink", Make="ZL", CurrentSpeed=55};

            // reflect over it
            RefectOverAnonymousType(myCar);

            Console.ReadLine();

        }
        
        static void FuckWithAnonymousType_equality_test()
        {
            var car1 = new { Color="Bright Pink", Make="ZL", CurrentSpeed=55 };
            var car2 = new { Color="Bright Pink", Make="ZL", CurrentSpeed=55 };

            // Equals()? comiler-generated Equals() method uses value-based semantics when testing for equality
            if(car1.Equals(car2))
                System.Console.WriteLine("-> same anonymous object!");
            else
                System.Console.WriteLine("-> Not the same anonymous object!");
            
            // ==? (non-overrid) == operator uses reference to test equality
            if(car1 == car2)
                System.Console.WriteLine("-> same anonymous object!");
            else
                System.Console.WriteLine("-> Not the same anonymous object!");
            
            // GetType()?
            if(car1.GetType().Name == car2.GetType().Name)
                System.Console.WriteLine("-> we are both the same types!");
            else
                System.Console.WriteLine("-> we are different types!");

            System.Console.WriteLine();
            RefectOverAnonymousType(car1);
            RefectOverAnonymousType(car2);
        }

        static void AnonymouseInAnonymous()
        {
            var purchaseItem = new {
                TimeBought = DateTime.Now,
                ItemBought = new {Color="Red", Make="ZL", CurrentSpeed=55 },
                Price = 34.00,
            };

            System.Console.WriteLine(purchaseItem.ItemBought);

            Console.ReadLine();
        }
        
    }
}