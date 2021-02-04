using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InternalRepresentationOfLinqStatements
{
    class Program
    {
        static int Main(string[] args)
        {
            // Linq query expr works with delegate methods, Func<>, Predict<>;
            {
                // query expr are created using Linq operators
                // Linq operators are shorthand of System.Linq.Enumerable extension methods
                QueryStringWith_Linq_operators();
                // System.Linq.Enumerable extension methods require delegates(Func<>) as params
                QueryStringWith_Enumerable_And_Full_Delegates();
                // we make Func<> short
                QueryStringWith_Enumerable_And_anonymous_methods();
                // much shorter: delegates params can instead be passed by lambda expr
                QueryStringWith_Enumerable_And_lambda();
            }

            //
            {

            }

            return 0;
        }

        static void QueryStringWith_Linq_operators()
        {
            System.Console.WriteLine("=> using Query Operators:");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            var subset = 
                from game in currentVideoGames
                where game.Contains(" ")
                orderby game
                select game;
            
            foreach(string s in subsest)
                System.Console.WriteLine("item: {0}", s);
            Console.ReadLine();
        }

        static void QueryStringWith_Enumerable_And_lambda()
        {
            System.Console.WriteLine("=> using Enumerable / lmbda expr:");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            var subset = currentVideoGames.Where(game=>game.Contains(" ")).OrderBy(game=>game).Select(game=>game);
            
            foreach(string s in subsest)
                System.Console.WriteLine("item: {0}", s);

            Console.ReadLine();
        }

        static void QueryStringWith_Enumerable_And_anonymous_methods()
        {
            System.Console.WriteLine("=> using Enumerable / Anonymous Methods:");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            //  building Func<> delegetates using anonymous methods
            Func<string, bool> searchFilter = delegate(string game){ return game.Contains(" "); };
            // or
            Predicate<string> searchFilter2 = delegate(string game) { return game.Contains(" "); };

            Func<string, string> itemToProcess = delegate(string game){ return game; }; 

            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            
            foreach(string s in subsest)
                System.Console.WriteLine("item: {0}", s);

            Console.ReadLine();
        }

        class VeryComplexQueryExpression
        {
            public static bool Filter(string game) { return game.Contains(" "); }
            public static string ProcessItem(string game) { return game; }

            public static void QueryStringWith_Enumerable_And_Raw_delegates()
            {
                System.Console.WriteLine("=> using Enumerable / Raw Delegates:");

                string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

                //  building Func<> full version;
                Func<string, bool> searchFilter = new Func<string, bool>(Filter);
                Func<string, string> itemToProcess = new Func<string, string>(ProcessItem); 

                var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
                
                foreach(string s in subsest)
                    System.Console.WriteLine("item: {0}", s);

                Console.ReadLine();
            }
        }
        
        static void QueryStringWith_Enumerable_And_Full_Delegates()
        {
            VeryComplexQueryExpression.QueryStringWith_Enumerable_And_Raw_delegates();
        }
        
    }
}