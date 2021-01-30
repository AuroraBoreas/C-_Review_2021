using System;

namespace Master_Parent
{

    class Person{};
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
                                                        overriding Equals() requires overriding GetHashCode() too 
                    - Finalize()
                    - GetHashCode()
                    - ToString()
                    - GetType()
                    - MemberwiseClone()

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

            // override
            {

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

    }
}