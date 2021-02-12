using System;
using System.Threading;

namespace ThreadPools
{

    public class Printer
    {
        public static void PrintNumbers()
        {
            System.Console.WriteLine("PrintNumbers() in thread: {0}", Thread.CurrentThread.ManagedThreadId);

            for(int i=0; i<10; ++i)
            {
                System.Console.Write("{0} ", i);
            }
            System.Console.WriteLine();
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            // understand the role of ThreadPool, P781
            {
                /*

                + definition
                    ```c#

                    namespace System.Threading
                    {
                        public static class ThreadPool
                        {
                            ...;
                            public static bool QueueUserWorkItem(WaitCallback callBack);
                            public static bool QueueUserWorkItem(WaitCallback callBack, object state);
                        }
                    }

                    ```

                + note
                    >> if u do NOT provide a System.Object when calling QueueUserWorkItem(), the CLR automatically passes a null value;


                */
                FuckWithCLR_ThreadPool();

            }

            //
            {

            }


            return 0;
        }

        private static void PrintNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();

        }

        private static void FuckWithCLR_ThreadPool()
        {
            System.Console.WriteLine("***** Fun with the CLR ThreadPool *****\n");

            System.Console.WriteLine("Main threading started. ThreadID = {0}", Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintNumbers);

            for(int i=0; i<10; ++i)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }

            System.Console.WriteLine("All tasks queued");
            Console.ReadLine();

        }



    }
}
