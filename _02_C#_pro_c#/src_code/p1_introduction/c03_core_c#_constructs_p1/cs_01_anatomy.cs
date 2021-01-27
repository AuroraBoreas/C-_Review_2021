using System;                       // for iostream
using System.Collections.Generic;   // for containers
using System.Linq;                  // for LINQ
using System.Text;                  // for StringBuilder
using System.Threading.Tasks;       // for concurrency

// ancm?

namespace Anatomy
{
    class Program
    {
        static void Main(string[] args) // prolog
        {
            System.Console.WriteLine("***** My First C# App *****");
            System.Console.WriteLine("hello world!");
            System.Console.WriteLine();

            // wait
            Console.ReadLine();
        }   // epilog

        // various Main() functions
        // C/C++
        static void Main()
        {
            // ...
        }
        static int Main(string[] args)
        {

            return 0;
        }

        // C# only: async Main methods, P117
        static Task Main();
        static Task<int> Main();
        static Task Main(string[]);
        static Task<int> Main(string[]);
        

        // cmd-line app
        static int Main(string[] args)
        {
            for(int i=0; i<args.Length; ++i)
            {
                System.Console.WriteLine("Arg: {0}", args[i]);
            }

            Console.ReadLine();
            return -1;
        }
        
        static int Main(string[] args)
        {
            // using Environment.GetCommandLineArgs()
            string[] cmdArgs = Environment.GetCommandLineArgs();
            foreach(string arg in cmdArgs)
            {
                System.Console.WriteLine($"Arg: {arg}");
            }
            Console.ReadLine();
            return -1;
        }
    }
}