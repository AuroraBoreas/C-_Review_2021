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
            }

            //
            {

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
            string s1 = "greeting";
            object s2 = "From";
            dynamic s3 = "ZL";

            System.Console.WriteLine("s1 is type of {0}", s1.GetType().Name);
            System.Console.WriteLine("s2 is type of {0}", s2.GetType().Name);
            System.Console.WriteLine("s3 is type of {0}", s3.GetType().Name);

            Console.ReadLine();
        }

    }
}