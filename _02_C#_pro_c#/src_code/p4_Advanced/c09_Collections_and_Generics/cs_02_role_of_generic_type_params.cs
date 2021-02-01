using System;
using System.Collections;
using System.Collections.Generic;


namespace Generic_Type_Params
{

    // class Car: IComparable      // version 0
    // {
    //     public string Name { get; set; }
    //     public int CurrentSpeed { get; set; }
    //     public int ID { get; set; }
        
    //     public Car(){}
    //     public Car(string n, int s, int a)
    //     { Name = n; CurrentSpeed = s; ID = a; }

    //     public override string ToString()
    //     => $"Name: {Name}, CurrentSpeed: {CurrentSpeed}, ID: {ID}";

    //     // IComparable explicit implementation
    //     int IComparable.CompareTo(object obj)
    //     {
    //         Car tmp = obj as Car;
    //         if(tmp != null)
    //         { return this.ID.CompareTo(tmp.ID); }
    //         else
    //             throw new ArgumentException("args is NOT Car type!");

    //     }
    // }

    class Car: IComparable<Car>     // version 1
    {
        public string Name { get; set; }
        public int CurrentSpeed { get; set; }
        public int ID { get; set; }
        
        public Car(){}
        public Car(string n, int s, int a)
        { Name = n; CurrentSpeed = s; ID = a; }

        public override string ToString()
        => $"Name: {Name}, CurrentSpeed: {CurrentSpeed}, ID: {ID}";

        // IComparable explicit implementation
        int IComparable<Car>.CompareTo(Car obj)
        {
            // no need to check type because params are Car type specified
            return this.ID.CompareTo(tmp.ID);
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            // Generic Type Params, P391
            {
                /*
                
                + note
                    - only class, interface, delegate, struct can be written generically
                    - enum can not;

                    - <T>; T shards for Type
                    - <Tkey>; Tkey or K is used for keys
                    - <TValue>; TValue or V is used for values 

                + Object Viewer
                    - using OV to see details in Visual Studio IDEL; 
                
                */ 

            }

            // Specifying Type Params for Generic classes/structs
            {
                /*
                
                + concept
                    - same with meta-programming template in C++

                + definition

                    ```c#
                    namespace System.Collections.Generics
                    {
                        public class List<T>:
                            IList<T>, ICollection<T>, IEnumarable<T>, IReadOnlyList<T>
                            IList, ICollection, IEnumarable
                        {
                            // ...;

                            public void Add(T item);
                            public ReadOnlyCollection<T> AsReadOnly();
                            public int BinarySearch(T item);
                            public void Contains(T item);
                            public void CopyTo(T[] array);
                            public int FindIndex(System.Predicate<T> match);
                            public T FindLast(System.Predicate<T> meatch);
                            public bool Remove(T item);
                            public int RemoveAt(System.Predicate<T> match);
                            public T[] ToArray();
                            public bool TrueForAll(System.Predicate<T> match);
                            public T this[int index] { get; set; }

                            // ...;
                        }
                    }
                    ```
                
                */ 

            }

            // specify type params for generic members
            {
                SpecifyTypeParamsForGenericMembers();
            }

            // specify type params for generic interfaces
            {
                /*
                
                + definition
                    ```c#

                    namespace System
                    {
                        public interface IComparable<T>
                        {
                            int CompareTo(T o);
                        }
                    }

                    ```
                */ 

            }

            
            return 0;
        }

        static void SpecifyTypeParamsForGenericMembers()
        {
            // declaration pattern comparison
            int[] myInts = { 10, 4, 2, 33, 93 };    // size-fixed array
            Array.Sort<int>(myInts);

            foreach(int i in myInts)
                System.Console.WriteLine(i);
        }

        static void SpecifyTypeParamsForGenericInterface()
        {
         
        }
        
    }
}