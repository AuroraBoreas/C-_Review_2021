using System;

namespace Generic_Delegate
{

    public delegate void MyGenericDelegate<T>(T arg);

    class Program
    {
        static int Main(string[] args)
        {
            // delegate template :> 
            {
                GenericDelegate();
            }

            // generic Action<> and Func<> delegates, P436
            {
                /*
                
                + pattern to use a custom delegate
                    - declare a delegate type that matches signature of callback functions;  // <-- typedef in c++
                    - define a delegate obj using the delegate type and pass callback function_name as arg to construct;
                    - invoke the method indirectly, or directly Invoke();
                
                    >> the name of customed "delegate type" does NOT matter at all

                + drawback of this approach
                    - u typically end up with a number of custom delegates that might never be used beyond the current task at hand;
                

                + solutuon
                    - using out-of-the-box System.Action<> delegate;
                    - using out-of-the-box System.Func<> delegate;
                    
                    >> note: System.Action<> delegate type can only points to methods with return_Type of void;
                    >> System.Func<> delegate can point to methods with return_type of non-void;
                        >> Caution: the T of the final arg of the methods is always the return_Type of the method;
                        >> syntax: 

                        ```c#

                        T func_name(U arg1, V arg2, W...args, T argN){...};
                        
                        Func<U, V, W..., T> f = new Func<U, V, W..., T>(func_name);
                        
                + alige with Action<> and Func<>
                    - Predicate<> is also supported; return true if a given var meets condition-expr, otherwise false
                        >> mechanism: Func<T, bool>

                    >> for both Action<> and Func<> types, max args are 16 though
                    
                */ 
                FuckWithSystemAction();
                FuckWithSystemFunc();
            }



            return 0;
        }

        private static void StringTarget(string arg)
        { System.Console.WriteLine("arg is uppercase is: {0}", arg.ToUpper()); }

        private static void IntTarget(int arg)
        { System.Console.WriteLine("++arg is: {0}", ++arg); }

        static void GenericDelegate()
        {
            System.Console.WriteLine("=> generic delegate:");

            MyGenericDelegate<string> mgd1 = new MyGenericDelegate<string>(StringTarget);
            mgd1("hello world! Bonjour tout le monde!");

            MyGenericDelegate<int> mgd2 = new MyGenericDelegate<int>(IntTarget);
            mgd2(9);

            Console.ReadLine();
        }

        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)       
        {
            // set color of console text
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for(int i=0; i<printCount; ++i)
                System.Console.WriteLine(msg);
            
            // restor
            Console.ForegroundColor = previous;
        }

        static void FuckWithSystemAction()
        {
            System.Console.WriteLine("=> fun with Action<> delegate type:");

            // using System.Action()
            // Q: how to do know return_type thou?
            // A: aha, System.Action<> can only point to methods with return_type of void;
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action message", ConsoleColor.Yellow, 5);

            Console.ReadLine();
        }

        private static int Add(int x, int y) => x + y;
        private static string SumToString(int x, int y) => (x+y).ToString();
        static void FuckWithSystemFunc()
        {
            System.Console.WriteLine("=> Fun with Func<> delegate type:");
            Func<int, int, int> f = new Func<int, int, int>(Add);
            int res = f(40, 40);
            System.Console.WriteLine("40 + 40 = {0}", res);

            Func<int, int, string> f2 = SumToString; // method group conversion;
            string res2 = f2(90, 300);
            System.Console.WriteLine("90 + 300 = {0}", res2);


        } 

    }
}