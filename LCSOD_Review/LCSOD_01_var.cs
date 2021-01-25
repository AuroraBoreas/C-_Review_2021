using System;

namespace LCSOD_01_var
{
    class Program
    {
        static viod Main(string[] args)
        {
            /*
            
            + var
            + what/why/how: skip
            + syntax pattern: T N V
            + category: CSIL, FD, BBD
                -   char    -- '';
                    short   --
                    int     --
                    long    --
                    float   -- 3.14f;
                    double  -- // default
                    byte    --
                    bool    -- 
                    decimal -- 16.30m;

            + type conversions:
                - implicit type conversion.
                - explicit type conversion.
                    - C-style, syntax: (T)var;
                    - ???

            + operators:
                Arithmetic: +, -, *, /, %, ++(postfix), ++(prefix) 
                Relational: ==, !=, <, <=, >, >=
                Logic: && || !
                Assignment: =
                Bitwise: & | ^ << >> 
                Access: ., ref
                Cast: (T)var;
                Op for storage: new;
                Op for other: ? :;
            */ 

            // var
            {
                char a1 = 'a';
                short a2 = 12;
                int a3 = 42;
                long a4 = 43L;
                float a5 = 3.14f;
                double a6 = 2.718;
                byte a7 = 255;
                bool a8 = true;
                decimal a9 = 31.2m;
            }
            
            // op
            {
                int x1 = 42,
                    x2 = 24;
                
                Console.WriteLine(string.Format("{0} + {1} = {2}", x1, x2, x1 + x2));
                Console.WriteLine(string.Format("{0} - {1} = {2}", x1, x2, x1 - x2));
                Console.WriteLine(string.Format("{0} * {1} = {2}", x1, x2, x1 * x2));
                Console.WriteLine(string.Format("{0} / {1} = {2}", x1, x2, x1 / x2));
                Console.WriteLine(string.Format("{0} % {1} = {2}", x1, x2, x1 % x2));
                Console.WriteLine(string.Format("{0}++", x1++)); // output: 42, x1 = 43; 
                Console.WriteLine(string.Format("++{0}", ++x1)); // output: 44, x1 = 44;
            }

            // type conversions
            {
                int y1;
                y1 = 3.14f;              // ouch. y1 = 3. downcasting
                double y2 = (double)314; // OK. upcasting
            }

            // 
        }
    }
}