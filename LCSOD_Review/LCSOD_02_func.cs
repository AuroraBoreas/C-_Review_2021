using System;

namespace LCSOD_02_func
{
    class Program
    {
        static int add_one(int x)
        { return ++x; }

        static void add_one(ref int x)
        { x++; }

        static void Main(string[] args)
        {
            // func
            {
                /*
                func

                + in C++, func
                    - prototype/declaration, definition
                    - inline
                    - macro
                    - syntax pattern: T N P
                    - passing args via V, Ref, Ptr
                    - passing containers like array, decaying to Ptr

                
                + in C#, func
                    - static, because main() func is static
                    - syntax pattern: T N P
                    - passing args via V, Ref
                    - passing conatainers like array, decaying to Ref
                */
                
                int x = 42;
                
                add_one(x);
                Console.WriteLine($"after passing to add_one(int {x}), x = {x}");     // output: 42
                add_one(ref x);
                Console.WriteLine($"after passing to add_one(ref int {x}), x = {x}"); // output: 43


            }
        }
    }
}