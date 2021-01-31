using System;
using System.Collections;

namespace IEnumarable_Interface
{

    class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        
        public Car(){}
        public Car(string n, int a)
        {
            Name = n;
            Speed = a;
        }
        
    }
    // class Garage    // version 0
    // {
    //     private Car[] carArray = new Car[4];
    //     public Garage()
    //     {
    //         carArray[0] = new Car("ZL", 30);
    //         carArray[1] = new Car("XY", 31);
    //         carArray[2] = new Car("JJ", 32);
    //         carArray[3] = new Car("LL", 34);
    //     }
    // }

    // class Garage: System.Collections.IEnumerable    // version 1
    // {
    //     private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
    //     public Garage()
    //     {
    //         carArray[0] = new Car("ZL", 30);
    //         carArray[1] = new Car("XY", 31);
    //         carArray[2] = new Car("JJ", 32);
    //         carArray[3] = new Car("LL", 34);
    //     }

    //     public System.Collections.IEnumerator GetEnumerator()    // user could find and use GetEnumerator() method
    //     {
    //         return carArray.GetEnumerator();
    //     }
    // }

    // class Garage: System.Collections.IEnumerable    // version 2
    // {
    //     private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
    //     public Garage()
    //     {
    //         carArray[0] = new Car("ZL", 30);
    //         carArray[1] = new Car("XY", 31);
    //         carArray[2] = new Car("JJ", 32);
    //         carArray[3] = new Car("LL", 34);
    //     }

    //     // public System.Collections.IEnumerator GetEnumerator()
    //     // {
    //     //     return carArray.GetEnumerator();
    //     // }
        
    //     // hide the functionality of IEnumerable from the obj-lvl; simple make use of explicit interface implementation
    //     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //     {
    //         return carArray.GetEnumerator();
    //     }
    // }

    // class Garage: System.Collections.IEnumerable    // version 3
    // {
    //     private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
    //     public Garage()
    //     {
    //         carArray[0] = new Car("ZL", 30);
    //         carArray[1] = new Car("XY", 31);
    //         carArray[2] = new Car("JJ", 32);
    //         carArray[3] = new Car("LL", 34);
    //     }

    //     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //     {
    //         foreach(Car c in carArray)
    //         { yield return c; }
    //     }

    //     // foreach is NOT required;
    //     // but it makes little sense to write it like this anyway; because it wont sync if u update codebase
    //     // System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //     // {
    //     //     yield return carArray[0];
    //     //     yield return carArray[1];
    //     //     yield return carArray[2];
    //     //     yield return carArray[3];
    //     // }
        
    // }

    // class Garage: System.Collections.IEnumerable    // version 4
    // {
    //     private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
    //     public Garage()
    //     {
    //         carArray[0] = new Car("ZL", 30);
    //         carArray[1] = new Car("XY", 31);
    //         carArray[2] = new Car("JJ", 32);
    //         carArray[3] = new Car("LL", 34);
    //     }

    //     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //     {
    //         throw new Exception("this won't get called!");
    //         foreach(Car c in carArray)
    //         { yield return c; }
    //     }        
    // }

    // class Garage: System.Collections.IEnumerable    // version5
    // {
    //     private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
    //     public Garage()
    //     {
    //         carArray[0] = new Car("ZL", 30);
    //         carArray[1] = new Car("XY", 31);
    //         carArray[2] = new Car("JJ", 32);
    //         carArray[3] = new Car("LL", 34);
    //     }

    //     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //     {
    //         throw new Exception("this won't get called!");
    //         return actualImplementation();

    //         // this is private function
    //         System.Collections.IEnumerator actualImplementation()
    //         {
    //             foreach(Car c in carArray)
    //             { yield return c; }

    //         }
    //     }        
    // }
    class Garage: System.Collections.IEnumerable    // version6
    {
        private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
        public Garage()
        {
            carArray[0] = new Car("ZL", 30);
            carArray[1] = new Car("XY", 31);
            carArray[2] = new Car("JJ", 32);
            carArray[3] = new Car("LL", 34);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // throw new Exception("this won't get called!");
            return actualImplementation();

            // this is private function
            System.Collections.IEnumerator actualImplementation()
            {
                foreach(Car c in carArray)
                { yield return c; }

            }
        }        
        public IEnumerable GetTheCar(bool returnReversed)
        {
            // do some error checking here
            return actualImplementation();

            IEnumerable actualImplementation()
            {
                if(returnReversed)
                {
                    for(int i=carArray.Length; i != 0; --i)
                    {
                        yield return carArray[i-1];
                    }
                }
                else
                {
                    foreach(Car c in carArray)
                    { yield return c; }
                }
                
            }

        }
    }


    class Program
    {
        static int Main(string[] args)
        {
            // IEnumerable, P361
            {
                /*
                
                + truth of matter
                    - any type supporting GetEnumerator() can be evaluated by the foreach construct;
                    - GetNumerator() is formalized dby the IEnumerable interface, which is found lurking within System.Collections namespace;

                + definition
                    - GetNumerator() return System.Collections.IEnumator;

                        ```c#
                        
                        namespace System.Collections
                        {
                            public interface IEnumerator
                            {
                                bool MoveNext();
                                object Current{get;}
                                void Reset();
                            }

                            public interface IEnumerable
                            {
                                IEnumerable GetNumerable();
                            }

                            // ...;

                        }
                        
                        
                        ```



                    - this interface enables u to traverse the internal obj contained by the IEnumerable-compatible container
                */ 

                IterateOverAnArray();   // OK;
                FunWithIEnumerableOrEnumerator();   // not OK; user-defined class type does not support GetNumerator() method;
            }

            // build iterator using yield kw
            {
                // same concept in Python
                // do some error checking + using local function as a wrapper to return IEnumerable;
                FunWithIEnumerableOrEnumerator();
            }

            // build a named iterator
            {
                // just like Python, yield kw can be used witin any method, it creates named iterator
                // be aware that return_type is IEnumerable interface
                FunWithYieldKeyword();

            }

            return 0;
        }


        static void IterateOverAnArray()
        {
            int[] myArrayOfInts = { 10, 20, 30, 40 };
            foreach(int i in myArrayOfInts)
            { System.Console.WriteLine(i); }

            Console.ReadLine();
        }

        static void FunWithIEnumerableOrEnumerator()
        {
            System.Console.WriteLine("=> Fun with IEnumerable or IEnumerator:");

            Garage g = new Garage();

            // iterate
            foreach(Car c in g)
            {
                System.Console.WriteLine("{0} is going {1} MPH", c.Name, c.Speed);
            }

            Console.ReadLine();
        }

        static void FunWithYieldKeyword()
        {
            System.Console.WriteLine("=> fun with yield keyword:");

            Garage g = new Garage();

            foreach(Car c in g)
            {
                System.Console.WriteLine("{0} is going {1} MPH", c.Name, c.Speed);
            }

            Console.WriteLine();

            // reverse
            foreach(Car c in g.GetTheCar(true))
            {
                System.Console.WriteLine("{0} is going {1} MPH", c.Name, c.Speed);
            }

            Console.ReadLine();
        }
    }
}