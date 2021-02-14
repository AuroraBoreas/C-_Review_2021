using System;

namespace PatternMatching
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string FavoriteColor { get; set; }
    }

    public class SuperHero: Person
    {
        public int MaxSpeed { get; set; }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // switch statement
            {

                System.Console.WriteLine("{0}", FindProgrammingLanguage("C#"));

            }

            // switch expression
            {
                System.Console.WriteLine("{0}", FindProgrammingLanguage("C#"));
            }

            return 0;
        }

        public static string FindProgrammingLanguage(string languageInput)
        {
            string languagePhrase;

            switch(languageInput)
            {
                case "C#":
                    languagePhrase = "C# is fun";
                    break;

                case "JavaScript":
                    languagePhrase = "JavaScript is mostly fun";
                    break;

                default:
                    throw new Exception("U code in something else I dont recognize.");
            }

            return languagePhrase;
        }

        public static string FindProgrammingLanguage2(string languageInput)
        {
            string languagePhrase = languageInput switch
            {
                "C#" => "C# is fun",
                "JavaScript" => "JavaScript is mostly fun",
                _ => throw new Exception("U code in something else I dont recognize."),

            };

            return languagePhrase;
        }

        public static void Baseline_Example()
        {
            SuperHero sHero = new SuperHero{
                FirstName = "Tony",
                LastName = "Stark",
                MaxSpeed = 10_000,
            };

            static decimal GetFuelCost(object hero)=>
            hero switch
            {
                SuperHero s when s.MaxSpeed < 1_000 => 10.00m,
                SuperHero s when s.MaxSpeed <= 10_000 => 7.00m,
                SuperHero _ => 12.00m,
                _ => throw new ArgumentException("I do not know this one", nameof(hero))
            };

            System.Console.WriteLine(GetFuelCost(sHero));
        }
        public static void Baseline_Example_relational_pattern()
        {
            SuperHero sHero = new SuperHero{
                FirstName = "Tony",
                LastName = "Stark",
                MaxSpeed = 10_000,
            };

            static decimal GetFuelCost(SuperHero hero)=>
            hero.MaxSpeed switch
            {
                < 1_000 => 10.00m,
                <= 10_000 => 7.00m,
                _ => 12.00m,
            };

            System.Console.WriteLine(GetFuelCost(sHero));
        }
        public static void Baseline_Example_logical_pattern()
        {
            SuperHero sHero = new SuperHero{
                FirstName = "Tony",
                LastName = "Stark",
                MaxSpeed = 10_000,
            };

            static decimal GetFuelCost(SuperHero hero)=>
            hero.MaxSpeed switch
            {
                1 or 2 => 1.00m;
                < 1_000 and <5_000 => 10.00m,
                <= 10_000 => 7.00m,
                _ => 12.00m,
            };

            System.Console.WriteLine(GetFuelCost(sHero));
        }


    }
}
