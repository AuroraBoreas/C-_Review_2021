using System;
using System.Linq;
using System.Collections.Generic;

namespace LCSOD_08_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ
            // example 01
            {
                /* LINQ
                
                + what: language integrated query. query data in C#... SQL?!

                + why: idk, idc

                + how:
                    from ... where ... orderby ... select

                 
                 */

                int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };

                var evenNumberQuery =
                    from num in numbers
                    where (num % 2) == 0
                    select num;

                Console.Write("even numbers: ");
                foreach (var i in evenNumberQuery)
                {
                    Console.Write(i.ToString() + " ");
                }
                Console.WriteLine("\npress any key to continue..");

                //Console.Read();
            }

            // example 02
            {
                // (P118/150)
                Console.WriteLine("\nLINQ Example 02: ");

                List<Customer> customers = new List<Customer>
                {
                    new Customer("ZL", "111", "ABC street", 25.60m),
                    new Customer("SCY", "112", "DEF street", -325.1m),
                    new Customer("LL", "113", "GHI street", -12.2m),
                    new Customer("XY", "114", "JKL street", 12.90m),
                    new Customer("LM", "114", "JKL street", 112.90m)
                };

                var overdueCustomers =
                     from cust in customers
                     where cust.Balance < 0
                     orderby cust.Balance ascending
                     select new { cust.Name, cust.Balance }; // when selecting more than one fields, new keyword is needed.

                //Console.WriteLine(overdueCustomers.ToString());
                foreach(var c in overdueCustomers)
                {
                    /*
                    
                    P79. auto-implemented or shorthand properties are equivalent to user defined properties.
                    but in the following case, it is not equivalent thou..
                    link: []

                     */
                    //Console.WriteLine(c.ToString()); // not work as expected. because default getter, setter are not implemented..
                    Console.WriteLine($"name = {c.Name}, balance = {c.Balance}");
                }


                Console.Read();
            }
        }
    }
}
