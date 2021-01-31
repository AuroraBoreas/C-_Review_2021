using System;
using System.Collections;

namespace IComparable_Interface
{

    // class Car   // version 0
    // {
    //     public string Name { get; set; } = "";
    //     public int CurrentSpeed { get; set; } = 0;
    //     public int ID { get; set; } = 0;
        
    //     public Car(){}
    //     public Car(string n, int s, int i)
    //     {
    //         Name = n;
    //         CurrentSpeed = s;
    //         ID = i;
    //     }

    //     public override string ToString()
    //     => $"\nName: {Name}, CurrentSpeed: {CurrentSpeed}, ID: {ID}";
        
    // }

    // class Car: IComparable   // version 1
    // {
    //     public string Name { get; set; } = "";
    //     public int CurrentSpeed { get; set; } = 0;
    //     public int ID { get; set; } = 0;
        
    //     public Car(){}
    //     public Car(string n, int s, int i)
    //     {
    //         Name = n;
    //         CurrentSpeed = s;
    //         ID = i;
    //     }

    //     public override string ToString()
    //     => $"\nName: {Name}, CurrentSpeed: {CurrentSpeed}, ID: {ID}";

    //     // extend
    //     public int CompareTo(object o)
    //     {
    //         Car c = o as Car;
    //         if(c != null)
    //         {
    //             if(this.ID < c.ID)
    //             { return 1; }
    //             else if(this.ID == c.ID)
    //             { return 0; }
    //             else
    //             { return -1; }
    //         }
    //         else
    //         { throw new ArgumentException("object is NOT Car type!"); }
    //     }
    // }

    // class Car: IComparable   // version 2
    // {
    //     public string Name { get; set; } = "";
    //     public int CurrentSpeed { get; set; } = 0;
    //     public int ID { get; set; } = 0;
        
    //     public Car(){}
    //     public Car(string n, int s, int i)
    //     {
    //         Name = n;
    //         CurrentSpeed = s;
    //         ID = i;
    //     }

    //     public override string ToString()
    //     => $"\nName: {Name}, CurrentSpeed: {CurrentSpeed}, ID: {ID}";

    //     // extend
    //     public int CompareTo(object o)
    //     {
    //         Car c = o as Car;
    //         if(c != null)
    //         {
    //             return this.ID.CompareTo(c.ID); // using System.Int32.CompareTo() method to shorthand
    //         }
    //         else
    //         { throw new ArgumentException("object is NOT Car type!"); }
    //     }
    // }

    class Car   // version 3
    {
        public string Name { get; set; } = "";
        public int CurrentSpeed { get; set; } = 0;
        public int ID { get; set; } = 0;
        

        public Car(){}
        public Car(string n, int s, int i)
        {
            Name = n;
            CurrentSpeed = s;
            ID = i;
        }

        public override string ToString()
        => $"\nName: {Name}, CurrentSpeed: {CurrentSpeed}, ID: {ID}";

        // we now support a custom property to return the corrent IComparer interface
        // static prop to return the NameComparer
        public static IComparer SortByName
        {
            get => (IComparer)new CarNameComparer();
        }
    }

    class CarNameComparer: IComparer    // a sorting helper class
    {
        // test name of each obj
        int IComparer.Compare(object o1, object o2)
        {
            Car c1 = o1 as Car;
            Car c2 = o2 as Car;
            if(c1 != null && c2 != null)
            { return string.Compare(c1.Name, c2.Name); }
            else
            { throw new ArgumentException("args are NOT Car type!"); }
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // System.IComparable, P372
            {
                /* 
                
                + concept
                    - op ol in c++
                    - operator.__gt__, operator.__eq__, @functools.total_ordering in python
                
                + definition
                    ```c#

                    namespace System
                    {
                        public interface IComparable
                        {
                            int CompareTo(object o);
                        }
                    }

                    ```
                    


                */
                // FuckWithObjectSorting();
                // enable Car array to support sorting
                // System.Console.WriteLine();
                // FuckWithObjectSorting_IComparable();
            }

            // specify Multiple sort orders with System.Collections.ICmoparable
            {
                // there are lots of metrics to compare two obj
                // is there a general way to compare?
                // answer: YES. System.IComparer
                /*
                
                + definition
                    ```c#

                    namespace System
                    {
                        namespace Collections
                        {
                            public interface IComparer
                            {
                                int Compare(object o1, object o2);
                            }
                        }
                    }

                    ```
                
                + System.IComparable vs System.Collections.ICmoparable
                    - System.Collections.ICmoparable is NOT implemented on the type u are trying to sort
                    - u implement this interface on any number of helper classes, one for each sort order
                
                
                */
                // System.Console.WriteLine();
                // FuckWithObjectSorting_IComparer();
            }

            // custom props and custom sort types
            {
                // u can also use a custom static prop to help the obj user along when sorting your Car types by a specific data point;
                FuckWithObjectSorting_IComparer_static_prop();   
            }

            return 0;
        }

        static void FuckWithObjectSorting()
        {
            System.Console.WriteLine("=> fun with object sorting:");

            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("ZL", 80, 1);
            myAutos[1] = new Car("XY", 40, 234);
            myAutos[2] = new Car("LL", 40, 34);
            myAutos[3] = new Car("XX", 40, 4);
            myAutos[4] = new Car("ZZ", 40, 5);

            foreach(Car c in myAutos)
                System.Console.WriteLine(c);
            Console.ReadLine();
            
        }
        static void FuckWithObjectSorting_IComparable()
        {
            System.Console.WriteLine("=> fun with object sorting:");

            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("ZL", 80, 1);
            myAutos[1] = new Car("XY", 40, 234);
            myAutos[2] = new Car("LL", 40, 34);
            myAutos[3] = new Car("XX", 40, 4);
            myAutos[4] = new Car("ZZ", 40, 5);
            Array.Sort(myAutos);

            foreach(Car c in myAutos)
                System.Console.WriteLine(c);
            Console.ReadLine();
            
        }
        
        static void FuckWithObjectSorting_IComparer()
        {
            System.Console.WriteLine("=> fun with object sorting:");

            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("ZL", 80, 1);
            myAutos[1] = new Car("XY", 40, 234);
            myAutos[2] = new Car("LL", 40, 34);
            myAutos[3] = new Car("XX", 40, 4);
            myAutos[4] = new Car("ZZ", 40, 5);

            Array.Sort(myAutos, new CarNameComparer());
            foreach(Car c in myAutos)
                System.Console.WriteLine(c);
            Console.ReadLine();
            
        }
        static void FuckWithObjectSorting_IComparer_static_prop()
        {
            System.Console.WriteLine("=> fun with object sorting:");

            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("ZL", 80, 1);
            myAutos[1] = new Car("XY", 40, 234);
            myAutos[2] = new Car("LL", 40, 34);
            myAutos[3] = new Car("XX", 40, 4);
            myAutos[4] = new Car("ZZ", 40, 5);

            Array.Sort(myAutos, Car.SortByName);
            foreach(Car c in myAutos)
                System.Console.WriteLine(c);
            Console.ReadLine();
            
        }
        
    }
}