using System;
using System.Reflection;


namespace ExtensionMethods
{
    static class MyExtensions
    {
        // this method allows any object to display the assembly it is defined in;
        public static void DisplayDefiningAssembly(this object obj)
        {
            System.Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // this method allows any integer to reverser its digits
        public static int ReverseDigits(this int i)
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
                    >> "this qualified" parameter represents the item being extended;


                */ 


            }

            //
            {

            }

            return 0;
        }

        
    }
}