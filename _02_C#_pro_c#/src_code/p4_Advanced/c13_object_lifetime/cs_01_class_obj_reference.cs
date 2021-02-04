using System;

namespace Object_Lifetime
{
    class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }

        public override string ToString()
        => $"Name: {Name}, Color: {Color}, Speed: {Speed}";
    }

    class MySRCWrapper: IDisposable
    {
        public void Dispose()
        {
            // clean up unmanaged source;
            // dispose other contained disposable objects;
            System.Console.WriteLine("=> In Dispose!");
        }
    }
    
    class Program
    {
        static int Main(string[] args)
        {
            // System.GC
            {
                FuckWithSystemGC();
            }

            // Finalizable objects, P545
            {
                // similar conception in C++, "final" kw

                /*
                
                + definition
                    ```c#
                    namespace System
                    {
                        public class Object
                        {
                            ...;
                            protected virtual void Finalized() {}
                        }
                    }

                    ```
                
                + note
                    - It is illegal to override Finalize() on structure types;
                    >> because structs are ValueType, which are never allocated on heap to begin with, therefore, are NOT garbage collected!

                    - if u create a struct that contains unmanaged src that need to be cleaned up, u can implement the IDisposable interface
                    
                
                */ 

            }

            // IDisposable interface
            {
                /*
                
                + definition
                    ```c#
                    namespace System
                    {
                        public interface IDisposable
                        {
                            void Dispose();
                        }
                    }

                    ```
                
                + note
                    - Structures and class types can both implement IDisposable
                    (unlike overriding Finalize(), which is reserved for class types), 
                    as the object user (not the garbage collector) invokes the Dispose() method.
                    
                    >> Finalized() methods are called by System.GC;
                    >> IDisposable() methods are called by programmer;
                
                */ 
            }

            // "using" kw, P550
            {
                // similar concept in Python to manage src
                // with open(...) as f: ...;

                /*
                
                + syntax: `using(DisposableObject do = new DisposableObject()) { ...; }`

                + note
                    - If you attempt to “use” an object that does not implement IDisposable,
                    you will receive a compiler error.
                
                */ 
                FuckWithIDisposable_try_finally();
                FuckWithIDisposable_using();
            }

            return 0;
        }

        static void FuckWithSystemGC()
        {
            System.Console.WriteLine("=> fun with System.GC:");

            System.Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
            System.Console.WriteLine("This OS has {0} object generation.\n", GC.MaxGeneration + 1);

            Car refToMyCar = new Car("Zippy", 100);
            System.Console.WriteLine(refToMyCar.ToString());

            System.Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));
            Console.ReadLine();
        }

        static void FuckWithIDisposable()
        {
            System.Console.WriteLine("=> fun with IDisposable:");

            MySRCWrapper rw = new MySRCWrapper();
            if(rw is IDisposable)
                rw.Dispose();
            Console.ReadLine();
        }       


        static void FuckWithIDisposable_try_finally()
        {
            System.Console.WriteLine("=> fun with dispose:");
            MySRCWrapper rw = new MySRCWrapper();
            try
            {
                // ...;
            }
            finally
            {
                // no matter error or not
                // always call Dispose()
                rw.Dispose();
            }
        }

        static void FuckWithIDisposable_using()
        {
            System.Console.WriteLine("=> fun with dispose:");
            using(MySRCWrapper rw = new MySRCWrapper())
            {
                // use rw object;
            }
        }
        
    }
}