using System;

namespace Return_Interface
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

    class Garage: System.Collections.IEnumerable    // version 1
    {
        private Car[] carArray = new Car[4];    // System.Array alrdy implements IEnumerable;
        public Garage()
        {
            carArray[0] = new Car("ZL", 30);
            carArray[1] = new Car("XY", 31);
            carArray[2] = new Car("JJ", 32);
            carArray[3] = new Car("LL", 34);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return carArray.GetEnumerator();
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

            // IEnumerator
            {

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
    }
}