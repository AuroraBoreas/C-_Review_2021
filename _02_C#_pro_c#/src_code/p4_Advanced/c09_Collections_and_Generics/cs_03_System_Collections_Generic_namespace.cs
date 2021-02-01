using System;
using System.Collections.Generic;

namespace Generic_Namespace
{
    class Person: IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(){}
        public Person(string fn, string ln, int a)
        { FirstName = fn; LastName = ln; Age = a; }

        public override string ToString()
        => $"Name: {FirstName} {LastName}, Age: {Age}";

        int IComparable<Person>.CompareTo(Person other)
        => this.Age.CompareTo(other.Age);
    }

    class SortPeopleByAge: IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            if(x?.Age > y?.Age)
            { return 1; }
            else if(x?.Age < y?.Age)
            { return -1; }
            else
            { return 0; }
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // Generic, P396
            {
                /*
                
                + key interfaces supported

                    ICollection<T>                  // size, enumeration, thread-safety
                    IComparer<T>                    // comparison
                    IDictionary<TKey, TValue>       // k-v pairs
                    IEnumerable<T>                  // return IEnumerator<T> obj
                    IEnumerator<T>                  // for-each iteration
                    IList<T>                        // Add, Remove, Update, Search
                    ISet<T>                         // set abstraction


                + classes supported

                    Dictionary<TKey, TValue>
                    LinkedList<T>
                    List<T>
                    Queue<T>
                    SortedDictionary<TKey, TValue>
                    Stack<T>
                
                */ 

            }

            // uniform initialization
            {
                // pass;
            }

            // work with List<T> class
            {
                UseGenericList_Person_cls();
            }

            // work with Stack<T> class
            {
                UseGenericStack_Person_cls();
            }

            // work with Queue<T> class
            {
                UseGenericQueue_Person_cls();
            }

            // work with SortedSet<T> class
            {
                /*
                
                + feature
                    - automatically ensures that the items in the set are sorted when u insert or remove items

                + note
                    - u need inform SortedSet<T> cls exactly how u want it to sort by passing IComparer<T> interface
                
                */
                UseGenericSortedSet_Person_cls();
            }

            // Dictionary<TKey, TValue> class
            {
                /*
                
                + note
                    - remember that when u are populating Dictionary<TKey, TValue>, key names MUST be unique
                    - or compiler error occurs
                */
                UseGenericDictionary_Person_cls(); 
            }

            return 0;
        }

        static void UseGenericList_Person_cls()
        {
            System.Console.WriteLine("=> Use Generic List:");

            List<Person> arrPeople = new List<Person>
            {
                new Person("Z", "L", 34),
                new Person("X", "Y", 34),
                new Person("L", "L", 34),
                new Person("S", "S", 34),
            };
            System.Console.WriteLine("-> Items in list: {0}", arrPeople.Count);

            foreach(Person p in arrPeople)
                System.Console.WriteLine(p);

            System.Console.WriteLine("-> Insert new Person");
            arrPeople.Insert(2, new Person("X", "X", 40));
            System.Console.WriteLine("-> Items in list: {0}", arrPeople.Count);

            // copy
            Person[] arrayOfPeople = arrPeople.ToArray();
            foreach(Person p in arrayOfPeople)
                System.Console.WriteLine("FirstName: {0}", p.FirstName);

            Console.ReadLine();
        }

        private static void UseGenericStack_Person_cls()
        {
            System.Console.WriteLine("=> Use Generic Stack:");
            
            Stack<Person> stackPeople = new Stack<Person>
            {
                new Person("Z", "L", 34),
                new Person("X", "Y", 34),
                new Person("L", "L", 34),
                new Person("S", "S", 34),
            };

            // peek
            System.Console.WriteLine("First Person is: {0}", stackPeople.Peek());
            System.Console.WriteLine("Popped off {0}", stackPeople.Pop());
            System.Console.WriteLine("\nFirst Person is: {0}", stackPeople.Peek());
            System.Console.WriteLine("Popped off {0}", stackPeople.Pop());
            System.Console.WriteLine("\nFirst Person is: {0}", stackPeople.Peek());
            System.Console.WriteLine("Popped off {0}", stackPeople.Pop());

            try
            {
                System.Console.WriteLine("\nFirst Person is: {0}", stackPeople.Peek());
                System.Console.WriteLine("Popped off {0}", stackPeople.Pop());
            }
            catch(InvalidOperationException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void GetCoffee(Person p)
        => $"{p.FirstName} got coffee!";

        private static void UseGenericQueue_Person_cls()
        {
            System.Console.WriteLine("=> use Generic Queue:");

            Queue<Person> qPeople = new Queue<Person>
            {
                new Person("Z", "L", 34),
                new Person("X", "Y", 34),
                new Person("L", "L", 34),
                new Person("S", "S", 34),
            };

            // enqueue, dequeue, peek
            qPeople.Enqueue(new Person("Ha", "Ha", 30));

            System.Console.WriteLine("{0} is first in line!", qPeople.Peek().FirstName);

            GetCoffee(qPeople.Dequeue());
            GetCoffee(qPeople.Dequeue());
            GetCoffee(qPeople.Dequeue());

            try
            {
                GetCoffee(qPeople.Dequeue());
            }
            catch(InvalidOperationException e)
            { System.Console.WriteLine(e.Message); }

            Console.ReadLine();
        }

        static void UseGenericSortedSet_Person_cls()
        {
            System.Console.WriteLine("=> use Generic SortedSet:");

            SortedSet<Person> sPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person("Z", "L", 3),
                new Person("X", "Y", 4),
                new Person("L", "L", 54),
                new Person("S", "S", 64),
            };

            foreach(Person p in sPeople)
            { System.Console.WriteLine(p); }
            System.Console.WriteLine();

            // add
            sPeople.Add(new Person("Go", "Go", 42));
            sPeople.Add(new Person("Do", "Do", 24));

            foreach(Person p in sPeople)
                System.Console.WriteLine(p);

            Console.ReadLine();
        }        

        static void UseGenericDictionary_Person_cls()
        {
            System.Console.WriteLine("=> use Generic Dictionary:");

            Dictionary<string, Person> dPeople = new Dictionary<string, Person>
            {
                { "Z", new Person("Z", "L", 3) },
                { "X", new Person("X", "Y", 4) },
                { "L", new Person("L", "L", 54) },
                { "S", new Person("S", "S", 64) },
            };

            // access
            System.Console.WriteLine(dPeople["Z"]);

            // or using Add
            Dictionary<string, Person> ddPeople = new Dictionary<string, Person>();
            ddPeople.Add("Z", new Person("Z", "L", 3));
            ddPeople.Add("X", new Person("X", "Y", 4));
            ddPeople.Add("L", new Person("L", "L", 54));
            ddPeople.Add("S", new Person("S", "S", 64));

            // access
            System.Console.WriteLine(ddPeople["X"]);

            Console.ReadLine();
        }
    }
}