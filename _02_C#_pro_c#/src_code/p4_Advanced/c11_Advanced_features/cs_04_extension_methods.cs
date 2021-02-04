using System;
using System.Reflection;


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

namespace ExtensionMethods
{

    using MyExtensions;

    static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach(var item in iterator)
            {
                System.Console.WriteLine(item);
                Console.Beep();
            }
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // extension methods, P478
            {
                /*

                + concept
                    - extension methods allow u to add new methods or properties to a class or structure, w/o modifying the original type in any direct manner;
                
                + why?
                    - handle legacy codes w/o breaking anything in production
                
                + mechanism
                    - when u define extension methods, the first restriction is that they MUST be defined within a "static" class;
                    >> each extension methods MUST be defined with the "static" kw;
                    
                    - the second point is that all extension methods are marked as such by using the "this" kw as a modifier on the first(and only the first) parameter of the method in question;
                    the additional parameters would be treated as normal incoming parameters for use by the method;
                    >> "this qualified" parameter represents the item being extended;


                */ 
                FuckWithExtensionMethods();

            }

            // import extension methods
            {
                // similar concept in C++
                // similar concept in Python
                // see namespace MyExtensionMethods

            }

            // extend types implementing specific interfaces
            {
                /*
                
                + what if i only wanna extend a specific iterfaces rather than all of classes?
                
                
                */ 
                
                ExtendInterfaceCompatibleTypes();
            }

            return 0;
        }

        static void FuckWithExtensionMethods()
        {
            System.Console.WriteLine("=> fun with extension methods:");

            int myInt = 1234567890;
            myInt.DisplayDefiningAssembly();

            // so has the DataSet
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            // and the SoundPlayer
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();
            
            // use new integer functinoality
            System.Console.WriteLine("value of myInt: {0}", myInt);
            System.Console.WriteLine("reversed digits of myInt: {0}", myInt.ReverseDigits());

            Console.ReadLine();
        }

        static void ExtendInterfaceCompatibleTypes()
        {
            System.Console.WriteLine("=> extend interface compatible types:");

            string[] data = { "Wow", "this", "is", "sort", "of", "annoying",
                               "but", "in", "a", "weird", "way", "fun!" };

            data.PrintDataAndBeep();

            System.Console.WriteLine();

            // List<T> implements IEnumerable
            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();

            Console.ReadLine();
        }
    }
}