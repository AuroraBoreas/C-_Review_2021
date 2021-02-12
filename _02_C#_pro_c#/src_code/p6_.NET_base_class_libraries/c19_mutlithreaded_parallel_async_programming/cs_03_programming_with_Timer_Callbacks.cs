using System;
using System.Threading;

namespace TimerCallbacks
{
    class Program
    {
        static int Main(string[] args)
        {
            // work with Timer Callbacks, P778
            {
                WorkWithTimerType();
            }

            // using discard var
            {
                WorkWithTimerType2();
            }

            return 0;
        }

        private static void PrintTime(object state)
        {
            System.Console.WriteLine("Time is : {0}", DateTime.Now.ToLongTimeString());
        }


        private static void WorkWithTimerType()
        {
            System.Console.WriteLine("***** work with Timer callback *****\n");

            TimerCallback = new TimerCallback(PrintTime);

            Timer t = new Timer(
                timeCB,
                null,
                0,
                1000
            );

            System.Console.WriteLine("hit enter key to terminate...");
            Console.ReadLine();

        }

        private static void WorkWithTimerType2()
        {
            System.Console.WriteLine("***** work with Timer callback *****\n");

            TimerCallback = new TimerCallback(PrintTime);

            Timer _ = new Timer(
                timeCB,
                null,
                0,
                1000
            );

            System.Console.WriteLine("hit enter key to terminate...");
            Console.ReadLine();

        }


    }
}
