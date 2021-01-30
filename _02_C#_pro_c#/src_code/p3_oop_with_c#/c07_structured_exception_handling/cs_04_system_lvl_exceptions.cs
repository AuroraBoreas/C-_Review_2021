using System;

namespace System_Level_Exceptions
{


    class Program
    {

        static int Main(string[] args)
        {
            // System.Exception
            {
                /*
                + core exception objects
                    - ArgumentOutOfRangeException
                    - IndexOutOfRangeException
                    - StackOverflowException
                    - ...;
            
                */

                FuckWithSystemException();
            }
            
            return 0;
        }

        static void FuckWithSystemException()
        {
            NullReferenceException nullRefEx = new NullReferenceException();
            System.Console.WriteLine($"NullReferenceException is-a SystemException? : {nullRefEx is SystemException}");

            Console.ReadLine();
            
        }
    }
}