using System;

namespace Custom_Generic_Methods
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

    public static class MyGenericMethods
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = b;
            b = a; a = temp;
        }

        public static void DisplayBaseClass<T>()
        => $"Base class of {typeof(T)} is : {typeof(T).BaseType}";
    }

    class Program
    {
        static int Main(string[] args)
        {
            // Custom Generic Methods, P408
            {
                /*
                
                + concept
                    - function template in C++

                */ 
                SwapObject_function_template();
            }

            // interface of type params
            {
                /*
                
                + note
                    - you should always get in the habit of always specifying the type params explicitly
                    - not let compiler infer param types implicitly, even it works;
                    - why: interence of type params works only if the generic method has at least one param;

                */ 
                FunWithParams_type_inference();

            }

            // member template
            {

            }

            return 0;
        }

        static void SwapObject_function_template()
        {
            void swap(ref int a, ref int b)
            {
                int temp = b;
                b = a; a = temp;
            }
            void swap(ref Person a, ref Person b)
            {
                Person temp = b;
                b = a; a = temp;
            }

            // function template
            void swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b; b = temp;
            }

            System.Console.WriteLine("=> fun with Generic Methods:");

            // swap 2 ints
            int a = 42, b = 100;
            System.Console.WriteLine($"-> before swap: a = {a}, b = {b}");
            swap<int>(ref a, ref b);
            System.Console.WriteLine($"-> after swap: a = {a}, b = {b}");
            System.Console.WriteLine();

            // swap 2 strings
            string s1 = "hello", s2 = "world";
            System.Console.WriteLine($"-> before swap: s1 = {s1}, s2 = {s2}");
            swap<string>(ref s1, ref s2);
            System.Console.WriteLine($"-> after swap: s1 = {s1}, s2 = {s2}");

            Console.ReadLine();
        }

        private static void DisplayBaseClass<T>()
        {
            // BaseType is a method used in reflection
            System.Console.WriteLine($"Base Class of {typeof(T)} is : {typeof(T).BaseType}");
        }

        static void FunWithParams_type_inference()
        {
            System.Console.WriteLine("=> fun with function template:");

            DisplayBaseClass<int>();
            DisplayBaseClass<string>();

            // compiler error
            DisplayBaseClass(); // <-- not OK
            Console.ReadLine();
        }
        

        
    }
}