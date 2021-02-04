using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MyExtensions
{
    static class MyExtensions
    {
        // this method allows any object to display the assembly it is defined in;
        public static void DisplayDefiningAssembly(this object obj) // <-- extend System.Object
        {
            System.Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // this method allows any integer to reverser its digits
        public static int ReverseDigits(this int i) // <-- extend System.Int32
        {
            // int -> char[]
            char[] digits = i.ToString().ToCharArray();
            // reverse
            Array.Reverse(digits);
            // char[] -> string
            string newDigits = new string(digits);
            return Convert.ToInt32(newDigits);
        }
    }
}

namespace LINQ_Specific_Constructs
{
    using MyExtensions;

    class Program
    {
        static int Main(string[] args)
        {
            // LINQ, P499
            {
                /*
                
                + LINQ-centric features
                    >> implicit typed local vars
                    >> object/collection initialization syntax
                    >> lambda expr
                    >> extension methods
                    >> anonymous types
                
                + the query operators of LINQ are designed to work with any type implementing IEnumerable<T>
                (either directly or via extesion methods)
                
                */ 


            }

            // core LINQ-centric assemblies, P504
            {
                /*
                
                + System.Core.dll

                + System.Data.DataSetExtensions.dll

                + System.Xml.Linq.dll
                
                */ 
                QueryOverString();
                QueryOverString_with_ExtensionMethods();
                QueryOverString_with_LINQ();

            }

            // reflect over a LINQ result set
            {
                QueryOverString_query_expr_reflect();
                QueryOverString_extension_method_reflect();
            }

            // return value 
            {
                /*
                
                + return value
                    >> using "var" kw to declare return_result impicitly;
                    >> using System.Collections.IEnumerable<T> as explicit return_value;
                
                */ 

            }

            
            // deferred exectuon, P511
            {
                /*
                
                + deferred execution
                    >> compiler executes LINQ query expr until u iterate over the return_value
                    >> why?
                        >> u are able to apply the same LINQ query multiple times to the same container
                        and rest assured u are obtaining the latest and greatest results; 
                
                */ 
            }

            // immediate execution
            {
                ImmediateExecution();                
            }

            return 0;
        }

        static void ReflectOverQueryResults(object resultSet, string queryType="Query Expr")
        {
            System.Console.WriteLine($"***** Info about your query using {queryType} *****");
            System.Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            System.Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        static void QueryOverString()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // filter
            IEnumerable<string> SUBSET = 
            from g in currentVideoGames
            where g.Contains(" ")
            orderby g
            select g;

            foreach(string s in g)
                System.Console.WriteLine("->item: {0}", s);

            Console.ReadLine();
        }
        
        static void QueryOverString_with_ExtensionMethods()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // query expr
            // IEnumerable<string> SUBSET = 
            // from g in currentVideoGames
            // where g.Contains(" ")
            // orderby g
            // select g;

            // extension methods
            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

            foreach(string s in g)
                System.Console.WriteLine("->item: {0}", s);

            Console.ReadLine();
        }

        static void QueryOverString_with_LINQ()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // LINQ syntax
            // IEnumerable<string> SUBSET = 
            // from g in currentVideoGames
            // where g.Contains(" ")
            // orderby g
            // select g;

            // query expression
            // IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            string[] subset = new string[];
            
            for(int i=0; i<currentVideoGames.Length; ++i)
            {
                if(currentVideoGames[i].Contains(" "))
                    subset.Append(currentVideoGames[i]);
            }

            // sort
            Array.Sort(subset);

            foreach(string s in subset)
                System.Console.WriteLine("item: {0}", s);

            Console.ReadLine();

        }

        static void QueryOverString_query_expr_reflect()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            var subset = 
                from g in currentVideoGames
                where g.Contains(" ")
                orderby g
                select g;

            ReflectOverQueryResults(subset);

            foreach(string s in subset)
                System.Console.WriteLine("item: {0}", s);

            Console.ReadLine();
        }

        static void QueryOverString_extension_method_reflect()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            // var subset = 
            //     from g in currentVideoGames
            //     where g.Contains(" ")
            //     orderby g
            //     select g;
            var subset = currentVideoGames.Where(g=>g.Contains(" ")).OrderBy(g=>g).Select(g=>g);

            ReflectOverQueryResults(subset, "Extension Method");

            foreach(string s in subset)
                System.Console.WriteLine("item: {0}", s);

            Console.ReadLine();
        }

        static void QueryInts_deferred_execution()
        {
            System.Console.WriteLine("=> fun with deferred execution:");

            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 4, 8 };

            var subset = 
            from i in numbers
            where i < 10
            select i;
            
            // LINQ statement evaluated here
            foreach(var i in subset)
                System.Console.WriteLine("{0} < 10", i);
            System.Console.WriteLine();
            // change some data in the array
            numbers[0] = 4;

            // evaluated again!
            foreach(var j in subset)
                System.Console.WriteLine("{0} < 10", j);
            System.Console.WriteLine();

            ReflectOverQueryResults(subset);
        }

        static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // get data right now as int[]
            int[] subsetAsIntArray = numbers.Where(n=>n<10).Select(n=>n).ToArray<int>();

            // ToList<T>
            List<int> subsetAsList = numbers.Where(n=>n<10).Select(n=>n).ToList<int>();

        }
    }
}