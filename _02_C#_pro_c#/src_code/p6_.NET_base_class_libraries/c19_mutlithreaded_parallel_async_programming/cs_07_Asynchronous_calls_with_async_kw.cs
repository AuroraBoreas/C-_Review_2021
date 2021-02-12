using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AsynchronousCalls
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // "async", "await" kw
            {
                /*

                + note
                    >> "await" kw before naming the method that will be called in an asynchronous manner;
                    >> this is important: if u decorate a method with the "async" kw but do NOT have at least one internal "await"-centric method call, u have essentially built a synchronous method call(in fact, u will be given a compiler warning to this effect);

                + naming conventions for asynchronous methods
                    >> "awaitable" method is simply a method that returns a Task<T>;
                    >> remember, "await" token is in charge of extracting the internal return value contained in the Task object;

                    >> MS recommends(as a best practice) that Any method returning a Task be marked with an Async suffix;

                + how to build an asynchronous method that return void?
                    >> using the nongeneric Task class and omit any return statement

                */
                System.Console.WriteLine(" fun with Async ===>");

                string message = await DoWorkAsync();
                System.Console.WriteLine(message);



            }

            // wrap up, P802
            {
                /*

                + wrapping up async and await

                    > 1, Methods(also lambda-expr) can be marked with "async" kw to enable the method to do work in a nonblocking manner;

                    > 2, Methods(also lambda-expr) marked with the "async" kw will run synchronously until the "await" kw is encountered;

                    > 3, a single "async" method can have multiple "await" contexts;

                    > 4, when the "await" expression is encountered, the calling thread is suspended until the awaited task is complete. in the meantime, control is returned to the caller of the method;

                    > 5, the "await" kw will hide the returned Task object from view, appearing to directly return the underlying return value. Methods with no return value simply return void;

                    > 6, Parameter checking and other error handling should be done in the main section of the method, with the actual "async" portion moved to a private function;

                    > 7, for stack variables, the ValueTask is more efficient than the Task object, which might cause boxing and unboxing;

                    > 8, as a naming convention, methods that are to be called asynchronously should be marked with the "Async" suffix;

                */

                await MethodReturningVoidAsync();
                System.Console.WriteLine("void method completed");
            }


            return 0;
        }

        static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work!";
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(()=>
            {
                Thread.Sleep(5_000);
                return "Done with work!";
            });
        }

        static void FuckWithAsync()
        {
            System.Console.WriteLine("Fun with Async ====>");

            List<int> l = default;
            System.Console.WriteLine(DoWork());
            System.Console.WriteLine("Completed");
            Console.ReadLine();
        }

        static async Task MethodReturningVoidAsync()
        {
            await Task.Run(()=>
                {
                    // ...;
                    Thread.Sleep(4_000);
                    // ...;
                }
            );

            System.Console.WriteLine("void method completed");
        }

        static async Task MultiAwaits()
        {
            await Task.Run(()=>{Thread.Sleep(2_000);});
            System.Console.WriteLine("Done with first task!");

            await Task.Run(()=>{Thread.Sleep(2_000);});
            System.Console.WriteLine("Done with second task!");

            await Task.Run(()=>{Thread.Sleep(2_000);});
            System.Console.WriteLine("Done with third task!");
        }

        static async Task MethodWithProblemsFixed(int firstParam, int secondParam)
        {
            System.Console.WriteLine("Enter");
            if(secondParam < 0)
            {
                System.Console.WriteLine("bad data");
                return;
            }

            actualImplementation();

            async Task actualImplementation()
            {
                await Task.Run(()=>
                {
                    Thread.Sleep(4_000);
                    System.Console.WriteLine("First Complete");
                    System.Console.WriteLine("Something bad happened");
                });
            }
        }

    }
}
