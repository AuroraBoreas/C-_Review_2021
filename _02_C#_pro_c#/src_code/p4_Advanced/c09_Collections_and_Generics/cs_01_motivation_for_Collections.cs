using System;
using System.Collections;
using System.Collections.Generics;

namespace Motivatio_Generic
{

    class Person
    {
        public string FirstName { get; set; } = "",
        public string LastName { get; set; } = "",
        public int Age { get; set; } = 0;
        
        public Person(){}
        public Person(string fn, string ln, int a)
        {
            FirstName = fn;
            LastName = ln;
            Age = a;
        }

        public override string ToString()
        => $"\nName: {FirstName} {LastName}, Age: {Age}";
        
        public override int GetHashCode()
        => this.ToString().GetHashCode();
    }

    class PersonCollection: IEnumerable
    {
        private ArrayList arrPeople = new ArrayList();

        public Person GetPerson(int pos) => (Person)arrPeople[pos];

        public void AddPerson(Person p)
        { arrPeople.Add(p); }
        public void RemovePerson(Person p)
        { arrPeople.Remove(p); }
        public void ClearPeople()
        { arrPeople.Clear(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return arrPeople.GetEnumerator(); }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // Motivation, P379
            {
                /*
                
                + concept
                    - similar concept with STL in C++
                        -- seq: array, list, queue, forward_list;
                        -- ada: stack, heap, dequeue
                        -- ass: map, multimap, set, multiset
                        -- ICAMLOBP: iterator, const_iterator, capacity, modification, list operation, observer, bucket, hash policy;

                    - Collections in C#
                        -- nogeneric containers:
                        -- generic containers (always prefer):

                        -- IList;
                        -- IDictionary;                 // return key-val pairs
                        -- ICollection;                 // size, enumeration, thread-safety
                        -- ICloneable;                  // deep copy
                        -- IEnumerable, IEnumerator;    // foreach iteration
                        -- IComparable, IComparer;      // comparison

                    - Iterator vs Iterable?
                        # see more details on my handbook about iterable, iterator, generator, gen-expr, container

                        -- Iterator is an object, it records states of an iterable
                            ```C#

                            namespace System.Collections
                            {
                                public interface IEnumerator
                                {
                                    bool MoveNext();
                                    int CurrentPosition();
                                    void reset();
                                }
                            }

                            namespace System.Collections
                            {
                                public interface IEnumerable
                                {
                                    object GetEnumerator();
                                }
                            }
                            
                            ```
                */ 

                PrimitiveArrayDemo();

            }

            // example: work with ArrayList
            {
                WorkWithArrayList();
            }

            // System.Collections.Specialized (nongeneric-type-containers)
            {
                /*
                
                + Specialized types
                    - HybridDictionary
                    - ListDictionary
                    - StringCollection
                    - BitVector32
                
                + other interfaces
                
                */ 
            }

            // problems of nongeneric collections, P385
            {
                /*
                
                + problems caused by using nongeneric collections
                    - using System.Collections and System.Collections.Specialized results in poorly performance code on System.Object, especially for nuemrical data processing;
                    - most of nongeneric collections are NOT type-safe because they were designed to operate on System.Object;

                    >> using nongeneric collections, CLR will automatically box stack-based data into System.Object on heap, 
                       then verify heap-based type matching with stack-based type, finally unbox heap-based data to stack-based data;

                    >> they hurt;

                + note
                    - remmeber that unlinke when performing a typical cast, u MUST unbox into an appropriate data type
                
                + definition

                    ```c#

                    namespace System.Collections
                    {
                        public class ArrayList: object, IList, ICollection, IEnumerable, ICloneable
                        {
                            // ...;
                            public virtual int Add(object o);
                            public virtual void Insert(int index, object o);
                            public virtual void Remove(object o);
                            public virtual object this[int index]{get; set;}
                            // ...;
                        }
                    }

                    ```
                */ 
                SimpleBoxUnboxOperation();

                // ineffeciency: box/unbox operation
                SimpleBoxUnboxOperation_InvalidCastException();
                WorkWithArrayList_boxunbox();
            }

            // type-safe: box/unbox operation
            {
                /*
                
                + type-safe
                    - u MUST keep in mind in generic-free world:
                        the fact that a majority of the classes of System.Collections
                        can typically anything whatsoever
                        because their members are prototyped to operate on System.Object;

                + desire
                    - sometime, u want an extremelly flexible container that can hold literally anything;
                    - most of the time, u want a Type-Safe container that can operate only on a particular type of data point;

                + solution
                    - prior to generic collections, the only way is to create a custome(strong typed) collection class manually;       

                    >> while custom collections do ensure type-safety, this approach leaves u in a position where u MUST create an(almost identical) custim collection for each unique data type u wanna contain;
                    >> thus, using template :D

                    >> and, a custom collection class does NOTHING to solve the issue of box/unbox oepration penalties when your class deals with numerical data entries;
                */
                WorkWithArrayList_type_safe();
                UserPersonCollection();
            }

            // generic collections
            {
                UseGenericList();
            }


            return 0;
        }

        static void PrimitiveArrayDemo()
        {
            System.Console.WriteLine("=> primitive array demo:");

            string[] strArray = { "First", "Second", "Third" };
            // Length
            System.Console.WriteLine("this array has {0} items", strArray.Length);
            System.Console.WriteLine();

            // loop
            foreach(string str in strArray)
            { System.Console.WriteLine("Arry Entry: {0}", str); }
            System.Console.WriteLine();

            // Reverse
            for(int i=strArray.Length; i != 0; --i)
            { System.Console.WriteLine("Array Entry: {0}", strArray[i-1]); }
            System.Console.WriteLine();

            // Sort
            Array.Sort(strArray);

            // Add
            strArray[3] = "Four";

            Console.ReadLine();
        }

        static void WorkWithArrayList()
        {
            System.Console.WriteLine("=> work with ArrayList:");

            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] {"first". "second", "third"});

            // capacity
            System.Console.WriteLine("this collection has {0} items", strArray.Count);

            // Add
            strArray.Add("fourth");
            System.Console.WriteLine("this collection has {0} items", strArray.Count);

            // display
            foreach(string str in strArray)
            { System.Console.WriteLine("Entry: {0}", str); }
            System.Console.WriteLine();

            Console.ReadLine();
        }

        static void SimpleBoxUnboxOperation()
        {
            // make a ValueType var
            int myInt = 25; // in stack
            // box it into obj reference
            object boxedInt = myInt;
            // unbox the reference back into corresponding int
            // CLR firstly verifies the recerving data type is equivalent to the boxed type
            // and if so, it copies the value back into a local stack-based var;
            int unboxInt = (int)boxedInt;

            /*
            
            ildasm.exe analyzer
            
            .method private hidebysig static void SimpleBoxUnboxOperation() cil managed
            {
            // Code size 19 (0x13)
            .maxstack 1
            .locals init ([0] int32 myInt, [1] object boxedInt, [2] int32 unboxedInt)
            IL_0000: nop
            IL_0001: ldc.i4.s 25
            IL_0003: stloc.0
            IL_0004: ldloc.0
            IL_0005: box [mscorlib]System.Int32         // <-- box
            IL_000a: stloc.1
            IL_000b: ldloc.1
            IL_000c: unbox.any [mscorlib]System.Int32   // <-- unbox
            IL_0011: stloc.2
            IL_0012: ret
            } // end of method Program::SimpleBoxUnboxOperation
            
            */ 

        }

        static void SimpleBoxUnboxOperation_InvalidCastException()
        {
            int myInt = 42;
            object boxedInt = myInt;

            // unbox in the wrong data type to trigger runtime exception
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                 System.Console.WriteLine(ex.Message);
            }
            System.Console.WriteLine();
        }

        static void WorkWithArrayList_boxunbox()
        {
            // ValueTypes are automatically boxed when
            // passed to a method requesting an object
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            Console.ReadLine();
        }
        
        static void WorkWithArrayList_type_safe()
        {
            ArrayList myObjects = new ArrayList();
            myObjects.Add(true);
            myObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            myObjects.Add(66);
            myObjects.Add(3.14);

            Console.ReadLine();
        }

        static void UserPersonCollection()
        {
            System.Console.WriteLine("=> custom Person Collection:");

            PersonCollection myPeople = new PersonCollection();
            myPeople.Add(new Person("Zhang", "Liang", 30));
            myPeople.Add(new Person("Xie", "HuiYing", 30));
            myPeople.Add(new Person("Wen", "Miao", 30));

            foreach(Person p in myPeople)
            { System.Console.WriteLine(p); }

            Console.ReadLine();
        }   
    }

    static void UseGenericList()
    {
        System.Console.WriteLine("=> fun with Generics:");

        // create
        List<Person> morePeople = new List<Person>();
        // add
        morePeople.Add(new Person("Zhang", "Liang", 40));
        // access
        System.Console.WriteLine(morePeople[0]);
        
        List<int> moreInts = new List<int>();
        moreInts.Add(10);
        moreInts.Add(2);
        int sum = moreInts[0] + moreInts[1];
        
    }
}