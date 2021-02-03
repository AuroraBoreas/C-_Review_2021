using System;

namespace Class_Template_Constraints
{
    // <T> MUST supports default ctor
    class MyGenericClass<T> where T: new()
    {
        // ...;
    }

    // <T> must be a class implementing IDrawable;
    // and MUST have default ctor;
    // notice the position of new();
    class MyGenericClass<T> where T: class, IDrawable, new()
    {
        // ...;
    }

    // <K> MUST extend SomeBaseClass and MUST support default ctor;
    // <T> MUST be a struct implementing IComparable<> interface;
    class MyGenericClass<K, T> where K: SomeBaseClass, new()
    where T: struct, IComparable<T>
    {
        // ...;
    }

    class BasicMath<T>  // compiler error
    {
        public T Add(T x, T y)
        { return x + y; }
        public T Sub(T x, T y)
        { return x - y; }
        public T Mul(T x, T y)
        { return x * y; }
        public T Div(T x, T y)
        { return x / y; }
    }


    // operator constraints are NOT supported under the current C#;

    // class BasicMath<T> where T: operator +, operator -, operator *, operator /  // <-- compiler error for sure: compiler does NOT know T has ability to +,-,*,/ etc
    // {
    //     public T Add(T x, T y)
    //     { return x + y; }
    //     public T Sub(T x, T y)
    //     { return x - y; }
    //     public T Mul(T x, T y)
    //     { return x * y; }
    //     public T Div(T x, T y)
    //     { return x / y; }
    // }

    
    class Program
    {
        static int Main(string[] args)
        {
            // constrain type params, P414
            {
                /*
                
                + concept
                    - "narrowing" types
                    - using "where" kw to extremely specify what a given type param MUST look like;

                + possible constraints
                    - where T: struct                   // <T> MUST be a struct type;
                    - where T: class                    // <T> MUST be a reference type;
                    - where T: new()                    // <T> MUST have a default ctor;
                                                        note: this constraint MUST be listed last on a multiconstraint type
                    - where T: NameOfBaseClass          // <T> MUST be dervied from the class specified by NameOfBaseClass;
                    - where T: NameOfInterface          // <T> MUST implement the interface specified by NameOfInterfacd;
                

                + note
                    - unless u need to build some exremely type-safe custom collections,
                    u might never need to use the "where" kw to constrain type

                + note
                    - these constraints can be used in function templates;

                */ 

                // see class MyGenericClass;

            }

            // the lack of operator constraints
            {
                /*
                
                + note
                    - u will be surprised that when creating generic methods,
                    u will get a compiler error if u apply any C# operators(+,-,*,/, etc) on the type params;

                    - operator constraints are NOT supported under the current C#;
                
                */ 

            }

            return 0;
        }

        // <T> MUST be a struct
        static void Swap<T>(ref T a, ref T b) where T: struct
        {
            // ...;
        }
        
    }
}