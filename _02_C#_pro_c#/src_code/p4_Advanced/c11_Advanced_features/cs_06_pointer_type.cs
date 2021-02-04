using System;

namespace PointerType
{
    unsafe struct Node
    {
        public int Value;
        public Node* Left;
        public Node* Right;

    }

    struct Node2
    {
        public int Value;

        public unsafe Node2* Left;
        public unsafe Node2* Right;
    }


    class Program
    {
        static unsafe int Main(string[] args)
        {
            // pointer type
            {
                /*
                
                + concept
                    >> same concept and operations in C++

                + operator supported in C#
                    *
                    &
                    ->
                    []
                    ++, --
                    +, -
                    ==, !=, <, >, <=, >=
                    stackalloc;             // <-- allocate C# arrays directly on the stack;
                    fixed;                  // <-- temporarily fix a variable so that its memory address can be found;
                    sizeof;
                    
                + when to use
                    - optimize select parts of application by directly manipulating memory outside the management of the CLR;
                    - call methods of a C-based.dll or COM server that demand pointer type as params;
                        >> even in this case, u can often bypass pointer types by using System.IntPtr type and members of the System.Runtime.InteropServices.Marshal type
                
                + how to use
                    - IDE setup compiler setting to allow "unsafe code"
                    >> project properties page -> select the "Allow Unsafe Code" box on the Build tab;

                    - declare a block of "unsafe code" using the "unsafe" kw
                */ 



            }

            // unsafe code with method(included Main), struct, class, members, and parameters 
            // using "unsafe" kw
            {

            }

            return 0;
        }

        static void UsingPointerType_unsafe_kw()
        {
            unsafe
            {
                // ...;
                // using pointer type only in this block;
            }

            // the pointer type can't be accessed here;
        }

        static unsafe void SquareIntPointer(int* myIntPointer)
        {
            *myIntPointer *= *myIntPointer;
        }

        static void FuckWithPointerType()
        {
            unsafe
            {
                int myInt = 42;
                SquareIntPointer(&myInt);
                System.Console.WriteLine("->myInt: {0}", myInt);
            }

            int myInt2 = 12;
            SquareIntPointer(&myInt2);  // not OK. compiler error
            System.Console.WriteLine("myInt2: {0}", myInt2);
        }
        
    }
}