using System;

namespace Nullable_Types
{


    class Program
    {

        class DatabaseReader
        {
            public int? m_numericValue = null;
            public bool? m_boolValue = true;

            public int? GetIntFromDB()
            { return m_numericValue; }

            public bool? GetBoolFromDB()
            { return m_boolValue; }
        }

        static int Main(string[] args)
        {
            // nullable types, P208
            {
                /*

                + mechnism:
                    - in Swift, similar concept is optional(symbol?)

                + syntax: T? var_name = val;
                    - note: T can only be value types
                    - note: if T is reference type, then compile error
                    - note: ? suffix is a shorthand for creating generic System.Nullable<T> struct type.

                    - class template in C++

                + effect:
                    - compound type, naming "nullable T"
                    - extends T to { ..., null }

                + usage:
                    - it is particularly useful when u are interating with databases, given that columns in a data table may be empty.

                */
                LocalNullableVars();
                LocalNullableVarsUsingNullable();

                System.Console.ReadLine();
            }

            // working with nullable types
            {
                /*

                + properties:
                    - NT.HasValue
                    - NT.Value



                */
                FuckWithNullableData();
                System.Console.ReadLine();

            }

            // null coalescing operator(symbol ??), P211
            {
                /*
                + usage: allows u to assign a value to a nullable type if the retrived value is null.

                + note: any var that might have a null value can be use of ?? operator
                    - a reference type var
                    - nullable type var

                + mechanism: similar concept like unbox optional in Swift

                */
                FuckWithNullableData_NCO();
                System.Console.ReadLine();

            }

            // null condition operator(symbol ?), P212
            {
                /*

                + purpose: check incoming data is not null before processing and simplify error checking

                + syntax: var_name?.access_op;

                */
                TestMethod_traditional(null);
                TestMethod_nullableOP(null);
            }


            return 0;
        }


        private static void ValueTypeCannotBeNull()
        {
            // bool b = null; // not OK
            // int i = null; // not OK

            string s = null; // OK

            // reference types:
            // string, object, dynamic
            // using keywords: class, interface, delegate, record to specify a reference type
        }

        private static void LocalNullableVars()
        {
            // define
            int? i =10;
            double? d = 3.14;
            bool? b = null;
            char? c = 'a';
            int?[] numbers = new int?[10];

            // string? s = "oops"; // not OK
        }

        private static void LocalNullableVarsUsingNullable()
        {
            Nullable<int> i = 10;
            Nullable<double> d = 3.14;
            Nullable<bool> b = null;
            Nullable<char> c = 'a';
            Nullable<int>[] numbers = new Nullable<int>[10];
        }

        private static void FuckWithNullableData()
        {
            System.Console.WriteLine("=> Fuck With Nullable Data:");
            DatabaseReader dr = new DatabaseReader();

            int? i = dr.GetIntFromDB();
            if(i.HasValue)
                System.Console.WriteLine($"Value of i is: {i.Value}");
            else
                System.Console.WriteLine("Value of i is undefined.");

            bool? b = dr.GetBoolFromDB();
            if(b != null)
                System.Console.WriteLine($"Value of i is: {i.Value}");
            else
                System.Console.WriteLine("Value of i is undefined.");
        }

        private static void FuckWithNullableData_NCO()
        {
            System.Console.WriteLine("=> Fuck With Nullable Data:");
            DatabaseReader dr = new DatabaseReader();

            int i = dr.GetIntFromDB()?? 100;
            bool b = dr.GetBoolFromDB()?? true;
            System.Console.WriteLine("Value of i is : {0}", i);

        }

        private static void TestMethod_traditional(string[] args)
        {
            if(args != null)
            {
                System.Console.WriteLine($"You sent me {args.Length} args.");
            }
        }

        private static void TestMethod_nullableOP(string[] args)
        {
            System.Console.WriteLine($"You sent me {args?.Length} args.");
            System.Console.WriteLine($"You sent me {args?.Length ?? 0} args.");
        }


    }
}
