using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace SystemThreading
{
    public class Printer
    {
        public void PrintNumbers()
        {
            System.Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            // print out numbers
            System.Console.WriteLine("your numbers: ");
            for (int i = 0; i < 10; ++i)
            {
                System.Console.WriteLine("{0} ", i);
                Thread.Sleep(2000);
            }
            System.Console.WriteLine();

        }
    }
    public class Printer2
    {
        public void PrintNumbers()
        {
            System.Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            // print out numbers
            System.Console.WriteLine("your numbers: ");
            Random rnd = new Random();

            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(2000 * rnd.Next(5));
                System.Console.WriteLine("{0} ", i);
            }
            System.Console.WriteLine();

        }
    }
    public class Printer3
    {
        private object threadLock = new object();

        public void PrintNumbers()
        {
            lock(threadLock)
            {
                System.Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                // print out numbers
                System.Console.WriteLine("your numbers: ");
                Random rnd = new Random();

                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(2000 * rnd.Next(5));
                    System.Console.WriteLine("{0} ", i);
                }
                System.Console.WriteLine();
            }

        }
    }

    [Synchronization]
    public class Printer4: ContextBoundObject
    {
        public void PrintNumbers()
        {

            System.Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            // print out numbers
            System.Console.WriteLine("your numbers: ");
            Random rnd = new Random();

            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(2000 * rnd.Next(5));
                System.Console.WriteLine("{0} ", i);
            }
            System.Console.WriteLine();
        }
    }



    class Program
    {
        static int Main(string[] args)
        {
            // System.Threading namespace
            {
                /*

                + core types

                    - Interlocked
                    - Mutex
                    - Monitor

                    - ParameterizedThreadStart
                    - ThreadStart

                    - Semaphore

                    - Thread
                    - ThreadPool

                    - ThreadPriority
                    - ThreadState

                    - Timer

                    - TimerCallback

                */

            }

            // System.Threading.Thread class, P763
            {
                /*

                + key static members
                    - CurrentContext
                    - CurrentThread

                    - GetDomain()
                    - GetDomainID()

                    - Sleep()

                + select instance-level members
                    - IsAlive
                    - IsBackground

                    - Name
                    - Priority
                    - ThreadState

                    - Abort()
                    - Iterrupt()
                    - Join()

                    - Start()
                    - Suspend()
                    - Resume()

                */

                ObtainStatisticsAboutCurrentThreadOfExecution();

            }

            // Priority
            {
                /*

                + Priority props

                ```C#

                public enum ThreadPriority
                {
                    Lowest,
                    BelowNormal,
                    Normal,             // <-- by default
                    AboveNormal,
                    Highest
                }

                ```


                */
            }

            // Manually creating secondary threads
            {
                /*

                + steps
                    1. Create ParameterizedThreadStart or ThreadStart delegate type that matches signature of method
                    2. Create method
                    3. Create Thread
                    4. Pass the delegate obj to the Thread
                    5. Thread.Start()
                */
                WorkingWithThreadStartDelegate();
                WorkWithParameterizedThreadStart();
                WorkWithAutoResetEventClass();
            }

            // foreground and background threads
            {
                /*

                + foreground vs background
                    - CLR can NOT terminate prg, unless foreground threads finished their unit of work;
                    - CLR can terminate prg, w/e background is doing;

                */
            }

            // issue of concurrency
            {
                SynchronoizingThreads();

            }

            // using "lock" keyword
            {
                UsingLockKeyword();
            }

            // System.Threading.Monitor type
            {
                /*

                + "lock" kw is just a shorthand of System.Threading.Monitor type;

                    when compiler see kw "lock", it transalets into..

                    ```c#

                    private object threadLock = new object();

                    Monitor.Enter(threadLock);
                    try
                    {
                        ...;
                    }
                    finally
                    {
                        Moniter.Exit(threadLock);
                    }

                    ```

                */
            }

            // System.Threading.Interlocked type
            {
                /*

                + arithmetic operation and assignment operation are NOT atomic;

                + using Interlocked type instead;


                */
            }

            // using [Synchronization] attriubte
            {
                // see class Printer4 declaration;
                // rationale: ContextboundObject class-level effectively locks down all instance membe code of the obj for thread safety;

            }

            return 0;
        }

        private static void ObtainStatisticsAboutCurrentThreadOfExecution()
        {
            System.Console.WriteLine("***** Primary Thread Stats *****");

            Thread primaryThread = Thread.CurrentThread;
            // name it, empty string by default
            primaryThread.Name = "ThePrimaryThread";

            // get info of AppDomain, Context
            System.Console.WriteLine("Name of current AppDomain: {0}", Thread.GetDomain().FriendlyName);
            System.Console.WriteLine("ID  of current Context: {0}", Thread.CurrentContext.ContextID);

            // display stats
            System.Console.WriteLine("Thread Name: {0}", primaryThread.Name);
            System.Console.WriteLine("Has thread started?: {0}", primaryThread.IsAlive);
            System.Console.WriteLine("Priority level: {0}", primaryThread.Priority);
            System.Console.WriteLine("Thread state: {0}", primaryThread.ThreadState);

            Console.ReadLine();
        }



        private static void WorkingWithThreadStartDelegate()
        {
            System.Console.WriteLine("***** The Amazing Thread App *****\n");

            System.Console.WriteLine("Do u wanna [1] or [2] threads");
            string threadCount = Console.ReadLine();

            // name the current thread
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // display thread info
            System.Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);

            // make worker class
            Printer p = new Printer();

            switch (threadCount)
            {
                case "2":
                    // now make the thread
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;

                case "1":
                    p.PrintNumbers();
                    break;

                default:
                    System.Console.WriteLine("I dont know what u want... u get 1 thread");
                    goto case "1";
            }

            System.Windows.Forms.MessageBox.Show("I'm busy!", "work on main thread...");
            Console.ReadLine();

        }

        class AddParams
        {
            public int a, b;
            public AddParams(int num1, int num2)
            { a = num1; b = num2; }
        }

        private static void Add(object data)
        {
            if(data is AddParams)
            {
                System.Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                System.Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
            }
        }

        private static void Add2(object data)
        {
            if(data is AddParams)
            {
                System.Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                System.Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
            }
        }

        private static void Add3(object data)
        {
            if(data is AddParams)
            {
                System.Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                System.Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);

                WaitHandle.Set();
            }
        }


        private static void WorkWithParameterizedThreadStart()
        {
            System.Console.WriteLine("***** Adding with Thread object *****");
            System.Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);

            // make an AddParams obj to pass to the secondary thread
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParamArrayAttribute(Add2));
            t.Start(ap);

            Thread.Sleep(5);
            Console.ReadLine();
        }

        private static void WorkWithAutoResetEventClass()
        {
            System.Console.WriteLine("***** Adding with Thread objects *****");
            System.Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add3));
            t.Start(ap);

            WaitHandle.WaitOne();
            System.Console.WriteLine("Other thread is done!");

            System.Console.WriteLine();
        }

        private static void BackgroundThreads()
        {
            System.Console.WriteLine("***** Background Threads *****\n");

            Printer p = new Printer();
            Thread bgThread = new Thread(new ThreadStart(p.PrintNumbers));

            bgThread.IsBackground = true;
            bgThread.Start();
        }

        private static void SynchronoizingThreads()
        {
            System.Console.WriteLine("***** Synchronizing Threads ***** \n");
            Printer2 p = new Printer2();

            Thread[] threads = new Thread[10];
            for (var i = 0; i < 10; i++)
            {
                Thread[i] = new Thread(new ThreadStart(p.PrintNumbers))
                {
                    Name = $"Worker thread #{i}"
                };
            }
            foreach(Thread t in threads)
                t.Start();

            Console.ReadLine();

        }

        private static void UsingLockKeyword()
        {
            System.Console.WriteLine("***** Synchronizing Threads ***** \n");
            Printer3 p = new Printer3();

            Thread[] threads = new Thread[10];
            for (var i = 0; i < 10; i++)
            {
                Thread[i] = new Thread(new ThreadStart(p.PrintNumbers))
                {
                    Name = $"Worker thread #{i}"
                };
            }
            foreach(Thread t in threads)
                t.Start();

            Console.ReadLine();
        }

    }
}
