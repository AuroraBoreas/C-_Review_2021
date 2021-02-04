using System;
using System.Collections;
using System.Linq;

namespace LINQ_Result
{

    class LinqBasedFieldsAreClunky
    {
        private static string[] vidoeGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

        private IEnumerable<string> subset = from game in vidoeGames where game.Contains(" ") orderby game select game;

        public void PrintGames()
        {
            foreach(string s in subset)
                System.Console.WriteLine(s);
        }
    }


    class Program
    {
        static int Main(string[] args)
        {
            // return the result of a LINQ query, P513d
            {
                FucWithLinq_Return_Value_Deferred_Execution();
                FucWithLinq_Return_Value_Immediate_Result();
            }

            return 0;
        }

        private static IEnumerable<string> GetStringSubset()
        {
            string[] colors = {"Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple"};
            IEnumerable<string> redColors = colors.Where(c=>c.Contains("Red")).Select(c=>c);
            return redColors;
        }

        private static string[] GetStringSubset()
        {
            string[] colors = {"Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple"};
            string[] redColors = colors.Where(c=>c.Contains("Red")).Select(c=>c).ToArray<string>();
            return redColors;
        }

        static void FucWithLinq_Return_Value_Deferred_Execution()
        {
            System.Console.WriteLine("=> LINQ Return Values Deferred Exection:");

            IEnumerable<string> subset = GetStringSubset();
            
            foreach(string item in subset)
                System.Console.WriteLine(item);

            Console.ReadLine();
        }

        static void FucWithLinq_Return_Value_Immediate_Result()
        {
            System.Console.WriteLine("=> LINQ Return Values Immediate Result:");

            string[] subset = GetStringSubset();
            
            foreach(string item in subset)
                System.Console.WriteLine(item);

            Console.ReadLine();
        }

        
    }
}