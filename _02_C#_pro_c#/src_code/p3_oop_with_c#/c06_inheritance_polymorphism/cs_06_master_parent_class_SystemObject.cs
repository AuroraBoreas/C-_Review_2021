using System;

namespace Master_Parent
{

    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; set; } = "";
        
        public Person(){}
        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        // override ToString()
        public override string ToString() => $"FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";

        // override Equals()
        public override bool Equals(object obj)
        {
            Person temp;
            temp = (Person)obj; // downcasting at runtime. not safe; using try.. catch.. or typeof... or as or is to avoid this
            if(temp.FirstName == this.FirstName && temp.LastName == this.LastName && temp.Age == this.Age) // this is tedious;
            { return true; }
            else
            { return false; }
            return false;
        }
        // or
        // notice that no longer do type conversion for obj to class Person;
        // why: because everything in .NET extends System.Object;
        // it means everything supports ToString()
        public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override int GetHashCode()
        {
            return SSN.GetHashCode(); // SSN must be a unique string; and it is in real life
            // or
            return ToString().GetHashCode();
        }

    }
    class Program
    {
        static int Main(string[] args)
        {
            // core membes of System.Object, P306
            {
                /*
                
                + core member list
                    instance method of Object class     meaning in life
                    - Equals()                          by default, return true only if reference comparison is same in memory;
                                                        this reference comparison is depended on Hashtable types, using GetHashCode() method;
                                                        overriding Equals() requires overriding GetHashCode() too;
                    
                    - Finalize()                        is called to free aby allocated resources before the object is destroyed;

                    - GetHashCode()                     return an int that identifies a specific obj intance;

                    - ToString()                        return currentFileName.Cls_Name by default; similarly in Python, __name__;
                                                        always remember: a prim-and-proper ToString() override should also account for ANY data defined "up the chain of inheritance";

                    - GetType()                         return a Type object that fully describes the obj u are currently referencing;
                                                        in short, this is a RunTime Type Identification(RTTI);

                    - MemberwiseClone()                 just like clone() or copy ctor or copy assignment operator in C++;

                + always remember: user-defined types extend Object

                + reference type in C#
                    - string
                    - object
                    - dynamic
                
                + kw to declare a reference type in C#
                    - record
                    - class
                    - dynamic
                    - delegate

                + definition of System.Object

                    ```c#

                    namespace System
                    {
                        public class Object
                        {
                            // virtual members
                            public virtual bool Equals(object obj);
                            protected virtual void Finalize();
                            public virtual int GetHashCode();
                            public virtual string ToString();

                            // instance-level. non-virtual members
                            public Type GetType();
                            protected object MemberwiseClone();

                            // static members
                            public static bool Equals(object objA, object objB);
                            public static bool ReferenceEquals(object objA, object objB);
                        }
                    }

                    ```
                

                */ 
                FuckWithSystemObject();

            }

            // override, or op ol?
            {
                /*
                
                + ToString()
                    - principle: prim-and-proper
                    - always remember to override ToString() that accounts for any data defined up the chain of inheritance

                + Equals()
                    - implementation method 1: data member by data member checking, tedious af
                    - implementation method 2: using a prim-and-proper ToString()

                + GetHashCode()
                    - by default, uses your object's current memory address to yield the hash value;
                    - however, if u are building a custom type that u intend to store in a Hashtable type(within System.Collections namespace), you should always override this member, as the Hashtable will be internally invoking Equals() and GetHashCode() to retrieve the correct obj;

                */ 
                // see class Person, ToString()
                // see class Person, Equals()
                // see class Person, GetHashCode()
            }

            //  using static methods of System.Object
            {
                // Equals()
                // ReferenceEquals()
                // explored alrdy during study over "know when to use new or override keyword in C#"

            }

            return 0;
        }

        static void FuckWithSystemObject()
        {
            System.Console.WriteLine("=> fuck with System.Object");

            Person p1 = new Person();

            System.Console.WriteLine("ToString: {0}", p1.ToString());
            System.Console.WriteLine("GetHashCode: {0}", p1.GetHashCode());
            System.Console.WriteLine("GetType: {0}", p1.GetType());

            // make some other references to p1;
            // reference types in C# are string, object, dynamic
            Person p2 = p1;
            object o = p2;

            // are the referens pointing to the same object in memory?
            if(o.Equals(p1) && p2.Equals(o))
            {
                System.Console.WriteLine("Same Instance!");
            }

            Console.ReadLine();

        }

        static void TestPersonClass()
        {
            System.Console.WriteLine("=> fun with Person class:");

            Person p1 = new Person("Zhang", "Liang", 35);
            Person p2 = new Person("Zhang", "Liang", 35);

            // ToString()
            System.Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            System.Console.WriteLine("p1.ToString() = {0}", p2.ToString());

            // Equals()
            System.Console.WriteLine("p1 = p2? {0}", p1.Equals(p2));

            // GetHashCode()
            System.Console.WriteLine("Same hash code?: {0}", p1.GetHashCode() == p2.GetHashCode());
            System.Console.WriteLine();

            // change age of p2, then test again
            p2.Age = 45;
            // ToString()
            System.Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            System.Console.WriteLine("p1.ToString() = {0}", p2.ToS=tring());

            // Equals()
            System.Console.WriteLine("p1 = p2? {0}", p1.Equals(p2));

            // GetHashCode()
            System.Console.WriteLine("Same hash code?: {0}", p1.GetHashCode() == p2.GetHashCode());
            Console.ReadLine();
            
        }

    }
}