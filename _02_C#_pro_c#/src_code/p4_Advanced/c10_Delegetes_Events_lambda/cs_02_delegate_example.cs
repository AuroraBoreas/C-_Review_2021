using System;

namespace Delegate_Example
{

    public delegate int BinaryOp(int x, int y);
    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Sub(int x, int y) => x - y;
    }


    class Program
    {
        static int Main(string[] args)
        {
            // delegate example, P423
            {
                SimpleDelegateExample();
            }

            // investigate a Delegate object
            {
                /*
                
                + note
                    - class static method; d.Target wont display
                    - class nonstatic method; d.Target will display
                
                */ 
                investigateDelegateObject();
            }

            return 0;
        }

        static void SimpleDelegateExample()
        {
            System.Console.WriteLine("=> Simple Delegate Example:");

            BinaryOp b = new BinaryOp(SimpleMath.Add); // hmmm, it is same pattern with C++ callback
            System.Console.WriteLine("10 + 10 is {0}", b(10, 10));
            System.Console.WriteLine("10 + 10 is {0}", b.Invoke(10, 10));   // <-- Invoke() is not necessary called explicitly;

            Console.ReadLine();
            
        }
        
        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach(Delegate d in delObj.GetInvocationList())
            {
                System.Console.WriteLine("Method Name: {0}", d.Method);
                System.Console.WriteLine("Type Name: {0}", d.Target);  
            }
        }

        static void investigateDelegateObject()
        {
            BinaryOp p = new BinaryOp(SimpleMath.Sub);
            DisplayDelegateInfo(p);

            Console.ReadLine();
        }


    }
}