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

            // System.Environment cls
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

            // System.Console cls
            {
                /*

                + selected properties
                    - beep()
                    - clear()

                    - backgroundcolor
                    - foregroundcolor
                    - bufferweight
                    - bufferheight

                    - title
                    - windowheight
                    - windowwidth
                    - windowtop
                    - windowleft


                */

                Console.WriteLine("**** Basic I/O ****");
                getUserData();
                Console.ReadLine();
                /*
                VS C# code snippet

                #helloworld
                ~
                cclear
                cgo
                class
                classa
                classd
                const
                cr
                crk
                csproj_1.0
                csproj_1.1
                csproj_2.0
                csproj_2.1
                csproj_3.1
                csproj_5
                cwl
                dowhile
                else
                enum
                exception
                for
                foreach
                guid
                guidn
                if
                ifelse
                iif
                immutable
                interface
                linq_distinct
                linq_where
                lock
                main
                method
                method_async
                msgbox
                mstest
                namespace
                prop
                propi
                propinit
                propr
                pum
                pvm
                record
                singleton
                singletonl
                singletonts
                struct
                switch
                tls
                todo
                try
                tryf
                using
                while

                */


            }

            // string interpolation, formatting
            {
                /*

                + formatting numeric data

                    .NET numeric format characters

                    C or c  -> currency
                    D or d  -> digit
                    E or e  -> scientific exp
                    F or f  -> floating-point
                    G or g  -> general
                    N or n  -> basic numerical formatting with comma
                    X or x  -> hex
                */

                formatNumericData();

                displayMessage();

                System.Console.ReadLine();

            }


            // var
            {
                localVarDeclaration();
                System.Console.ReadLine();
            }

            // intrinsic datatype and new operator
            {
                /*

                + all intrinsic data types support what is known as default constructor. this allows u to create a var using new keyword, which automatically sets the var to its default value

                    - bool          -> false
                    - numeric       -> 0 or 0.0
                    - char          -> ''
                    - BigInteger    -> 0
                    - DateTime      -> 1/1/0001 12:00:00AM
                    - Obj           -> null
                    - String        -> null

                */
                objectFunctionality();
            }

            // members of numerical data types
            {
                // cls hierarchy of CTS on P131

                dataTypeFunctionality();
            }

            // boolean
            {
                // boolean does not support MinValue/MaxValue properties but
                boolFalseTrueString();
                System.Console.ReadLine();
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

        private static void getUserData()
        {
            // get name and age
            System.Console.WriteLine("please enter your name: ");
            string userName = System.Console.ReadLine();
            System.Console.WriteLine("please enter your age: ");
            string userAge = System.Console.ReadLine();

            // get echo color
            ConsoleColor prevColor = Console.Foregroundcolor;
            Console.Foregroundcolor = ConsoleColor.Yellow;

            // echo to the console
            System.Console.WriteLine("hello {0}! You are {1} yo.", userName, userAge);

            // restore previous color
            Console.Foregroundcolor = prevColor;

        }

        private static void formatNumericData()
        {
            // formatting numeric charactors
            int x = 99999;
            System.Console.WriteLine($"The value {x} in various formats:");
            System.Console.WriteLine("c format: {0: c}", x);
            System.Console.WriteLine("d format: {0: d9}", x);
            System.Console.WriteLine("f format: {0: f3}", x);
            System.Console.WriteLine("n format: {0: n}", x);

            // note the difference between uppercase vs lowercase
            System.Console.WriteLine("E format: {0: E}", x);
            System.Console.WriteLine("e format: {0: e}", x);
            System.Console.WriteLine("X format: {0: X}", x);
            System.Console.WriteLine("x format: {0: x}", x);

        }

        private static void displayMessage()
        {
            // using string.Format()
            string msg = string.Format("100000 in hex is {0:x}", 100000);
            // u need to reference PresentationFramework.dll
            // in order to compile this line of code
            System.Windows.MessageBox.Show(msg);
        }

        private static void localVarDeclaration()
        {
            System.Console.WriteLine("=> Data Declaration");

            // T N V
            int myInt = 42;
            string myString = "Hello world";
            System.Boolean b1 = true,
                           b2 = false,
                           b3 = b1;
            bool b4 = false;


            // default
            long myLong = default;

            System.Console.WriteLine("your data: {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);

        }

        private static void NewingDataType()
        {
            System.Console.WriteLine("=> Using new to create var:");

            bool b = new bool();
            int  i = new int();
            double d = new double();
            DateTime dt = new DateTime();

            System.Console.WriteLine($"{b} {i} {d} {dt}");
            System.Console.WriteLine();
        }

        private static void objectFunctionality()
        {
            System.Console.WriteLine("=> System.Object Functionality:");

            System.Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            System.Console.WriteLine("12.Equals() = {0}", 12.Equals(42));
            System.Console.WriteLine("12.ToString() = {0}", 12.ToString());
            System.Console.WriteLine("12.GetType() = {0}", 12.GetType());

            System.Console.WriteLine();
        }

        private static void dataTypeFunctionality()
        {
            System.Console.WriteLine("=>Data Type Functionality:");

            System.Console.WriteLine("Max of int: {0}", int.MaxValue);
            System.Console.WriteLine("Min of int: {0}", int.MinValue);
            System.Console.WriteLine("Max of double: {0}", double.MaxValue);
            System.Console.WriteLine("Min of double: {0}", double.MinValue);
            System.Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            System.Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            System.Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);

            System.Console.ReadLine();
        }

        private static void boolFalseTrueString()
        {
            System.Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            System.Console.WriteLine("bool.TrueString: {0}", bool.TrueString);

        }
    }
}
