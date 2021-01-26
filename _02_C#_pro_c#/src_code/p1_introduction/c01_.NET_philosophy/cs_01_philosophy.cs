// ancm?

namespace Pilosohpy
{
    class Program
    {
        static int Main(string[] args)
        {
            /*
            
            terminology
            
            + why: Uniform and generalize all languages(C++, VB, C#, F#) in .NET 

            + compilation pattern:
                src code -> .NET compilers -> IL(assemblies) -> machine code 

            + library pattern:
                CTS: common type system
                CLS: common language specifications

                mscorlib.dll
                mscoree.dll
            
            + Object Viewer, ildasm.exe
                - shortcut: VS console -> ildasm


            + more details on paper notebook
                ...

            */

            // System.Environment
            {
                /*

                + Properties:
                    ExitCode
                    Is64BitOperatingSystem
                    MachinName
                    NewLine
                    SystemDirectory
                    UserName
                    Version                
                
                */
                
                showEnvironmentInfo();
                
                Console.ReadLine();
            }

            return 0;
        }

        static void showEnvironmentInfo()
        {
            foreach(string driver in Environment.GetLogicalDrivers())
            { Console.WriteLine("Drive: {0}", driver); }

            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
        }
    }
}