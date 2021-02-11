using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Process_AppDomain_Context_Thread
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        public bool isDone = false;
        static int Main(string[] args)
        {
            // Process, AppDomain, Context, Thread relationshp, P749
            {
                // get current Thread, AppDoaim, Context
                ExtractExecutingThread();
            }

            // A brief review of the .NET delegate
            {
                SyncDelegateReview();

            }

            // the asynchronous nature of Delegates
            {
                AsyncDelegateInvocation();
                AsyncDelegateInvocation_synchronize();
            }

            return 0;
        }


        private static void ExtractExecutingThread()
        {
            // current Thread
            Thread currentThread = Thread.CurrentThread;
            // current AppDomain
            AppDomain ad = Thread.GetDomain();
            // current Context
            Context ctx = Thread.CurrentContext;
        }

        private static int Add(int x, int y)    // version 0
        {
            System.Console.WriteLine("Add() func on thread {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            return x + y;
        }

        private static int Add2(int x, int y)    // version 1
        {
            System.Console.WriteLine("Add() func on thread {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            return x + y;
        }

        private static void AddComplete(IAsyncResult iar)
        {
            System.Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            System.Console.WriteLine("Your addition is complete");

            isDone = true;
        }

        private static void AddComplete2(IAsyncResult iar)
        {
            System.Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            System.Console.WriteLine("Your addition is complete");
            // now get the result
            AsyncResult ar = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;

            System.Console.WriteLine("10 + 10 is {0}", b.EndInvoke(iar));
            isDone = true;
        }

        private static void SyncDelegateReview()
        {
            System.Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            int answer = b(10, 10);

            System.Console.WriteLine("Doing more work in Main()!");
            System.Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();

        }

        private static void AsyncDelegateInvocation()
        {
            System.Console.WriteLine("***** Async Delegate Invocation *****");

            System.Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);

            System.Console.WriteLine("Doing more work in Main()!");

            int answer = b.EndInvoke(ar);


            System.Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();
        }

        private static void AsyncDelegateInvocation_synchronize()
        {
            System.Console.WriteLine("***** Async Delegate Invocation *****");

            System.Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);

            while(!ar.IsCompleted)  // <-- using IAsyncResult.IsCompleted prop to check state
            {
                System.Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }

            int answer = b.EndInvoke(ar);


            System.Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();
        }

        private static void AsyncCallbackDelegate_example()
        {
            System.Console.WriteLine("***** AsyncCallbackDelegate example *****");

            System.Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);

            while(!isDone)  // <-- using IAsyncResult.IsCompleted prop to check state
            {
                System.Console.WriteLine("Working...");
                Thread.Sleep(1000);
            }

            // int answer = b.EndInvoke(ar);


            // System.Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();
        }

        private static void PassRecieveCustomStateDta()
        {
            System.Console.WriteLine();
        }

    }
}
