using System;
using System.Collections.Generic;

namespace Dynamic_KW
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(){}
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName; LastName = lastName; Age = age;
        }
        public override string ToString()
        => $"Name: {FirstName} {LastName}, Age: {Age}";
    }


    class VeryDynamicClass
    {
        private static dynamic myDynamicField;
        public dynamic DynamicProp { get; set; }
        public dynamic DynamicMethod(dynamic dynamicArg)
        {
            // a local dynamic
            dynamic dynamicLocalVar = "local var";
            int myInt = 10;

            if(dynamicLocalVar is int)
                return dynamicLocalVar;
            else
                return myInt;
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // role of "dynamic" kw, P659
            {
                ImplicitTypeVar();
                // evolve
                UseObjctVar();
                // step further
                UseDynamicType();
                // use
                UseDynamicType_dreamup();
            }

            // scope of "dynamic" kw
            {
                /*
                
                + comparison
                    - "var" kw can't be return_type, args,  or a member of a class;
                    - "dynamic" kw can be;
                
                */ 
                UseDynamicType_in_class();

            }

            return 0;
        }

        private static void ImplicitTypeVar()
        {
            var a = new List<int>{90};  // a is implicit List<int> type

            a = "hello"; // not OK. compiler error
        }
        
        private static void UseObjctVar()
        {
            object p = new Person(){FirstName="Zhang", LastName="Liang", Age=35};
            // convert type of p to Person class to gain access to Person ability
            System.Console.WriteLine((Person)p.ToString());
        }
        
        private static void UseDynamicType()
        {
            var s1 = "greeting";
            object s2 = "From";
            dynamic s3 = "ZL";

            System.Console.WriteLine("s1 is type of {0}", s1.GetType().Name);
            System.Console.WriteLine("s2 is type of {0}", s2.GetType().Name);
            System.Console.WriteLine("s3 is type of {0}", s3.GetType().Name);

            Console.ReadLine();
        }

        private static void UseDynamicType_change()
        {
            dynamic t = "hello";
            System.Console.WriteLine("t is type of {0}", t.GetType().Name);
            
            t = false;
            System.Console.WriteLine("t is type of {0}", t.GetType().Name);

            t = new List<int>(){90};
            System.Console.WriteLine("t is type of {0}", t.GetType().Name);

        }

        private static void UseDynamicType_dreamup()
        {
            dynamic d = "hello";
            System.Console.WriteLine(d.ToUpper());  // <-- no intellisense; be careful :s
            System.Console.WriteLine(d.toupper());  // 
            System.Console.WriteLine(d.Foo(12, "hello", DateTime.Now));
    

            Console.ReadLine();
        }

        private static void UseDynamicType_in_class()
        {
            VeryDynamicClass vdc = new VeryDynamicClass();
            dynamic x = 10;
            System.Console.WriteLine(vdc.DynamicMethod(x));
        }

    }
}