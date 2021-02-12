using System;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static int Main(string[] args)
        {
            // using Task Parallel Library(TPL), P782
            {
                /*

                + why
                    >> u can build fine-grained, scalable parallel code w/o having to work directively with Threads or ThreadPool;

                + note
                    >> in reality, TPL and Threading toolkits can work together quite naturally;

                + how
                    >> TPL automatically distribute application's workload across available CPUs dynamically, using the CLR thread pool;
                */

            }

            // the Role of the Parallel class
            {
                /*

                + System.Threading.Task.Parallel class

                    - it supports a number of method that allow u to iterate over a collection of data(specifically, an object implementing IEnumerable<T>) in parallel fashion;

                    - two primary methods, Parallel.For() and Parallel;
                    >> ForEach(), each of which defines numerous overloaded versions

                + how to use

                    - step1, specify an IEnumerable- or IEnumerable<T>-compatible container that
                    holds the data u need to process in a parallel manner;
                    >> the container could be a simple array, a nongeneric collection, a generic collection or the results of a LINQ query;

                    - step2, use the System.Func<T> and System.Action<T> delegates to specify the target method that will be called to process the data;

                */

            }

            // data parallelism
            {

            }

            return 0;
        }



    }
}
