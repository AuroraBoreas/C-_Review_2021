using System;

namespace LCSOD_01_var
{

    class Program
    {

        // display
        static void display(string s)
        {
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
           /*
             + var
                what: var is a "box"
                why: reusable
                how: as follows
                category: CSILFD, 
                          byte, bool, decimal
            */
            char c = 'a';
            short a = 42;
            int b = 122;
            long d = 123456789;
            float e = 3.14f;
            double f = 2.718;

            display(c.ToString());
            display(a.ToString());
            display(b.ToString());
            display(d.ToString());
            display(e.ToString());
            display(f.ToString());

            display("\n");

            /*
            
            + op
                what: a symbol that represents connnection of operands
                why: real life stuff simulation
                how: as follows
            
                category:
                    Arithmetic
                    Relational
                    Logic
                    Assignment
                    Bitwise
                    Access
                    Cast
                    Op for storage
                    Op for other

            */
            int a1 = 11;
            int a2 = 42;
            // Arithmetic ops
            // using string interpolation to reduce efforts
            display($"{a1} + {a2} = " + (a1 + a2).ToString());
            display($"{a1} - {a2} = " + (a1 - a2).ToString());
            display($"{a1} * {a2} = " + (a1 * a2).ToString());
            display($"{a1} / {a2} = " + (a1 / a2).ToString());
            display($"{a1} % {a2} = " + (a1 % a2).ToString());
            display($"{a1}++ = " + (a1++).ToString());
            display($"++{a1} = " + (++a1).ToString());


            display("\n");
            // Relational ops
            display($"{a1} == {a2} is  " + (a1 == a2).ToString());
            display($"{a1} != {a2} is " + (a1 != a2).ToString());
            display($"{a1} < {a2} is " + (a1 < a2).ToString());
            display($"{a1} <= {a2} is " + (a1 <= a2).ToString());
            display($"{a1} > {a2} is " + (a1 > a2).ToString());
            display($"{a1} >= {a2} is " + (a1 >= a2).ToString());

            display("\n");
            // Logic ops
            bool x1 = true, x2 = false;
            display($"{x1} && {x2} is  " + (x1 && x2).ToString());
            display($"{x1} || {x2} is  " + (x1 || x2).ToString());
            display($"!{x1} is  " + (!x1).ToString());

            display("\n");
            // Assignment ops: not () or {} in C++..
            decimal d1 = 10.0m;
            display($"{d1} is  " + (d1).ToString());

            display("\n");
            // Bitwise ops: not () or {} in C++..
            int b1 = 12, // 8-bit sys, 0000 1100;
                b2 = 21; // 8-bit sys, 0001 0101;
            display($"{b1} & {b2} is  " + (b1 & b2).ToString()); // 0000 0100 = 4;
            display($"{b1} | {b2} is  " + (b1 | b2).ToString()); // 0001 1101 = 29;
            display($"{b1} ^ {b2} is  " + (b1 ^ b2).ToString()); // 0001 1001 = 25;
            display($"{b1} >> 2 is  " + (b1 >> 2).ToString());   // 0000 0011 = 3;
            display($"{b1} << 2 is  " + (b1 << 2).ToString());   // 0011 0000 = 48;

            display("\n");
            // Access ops: (*ptr).; ptr->; oops, not ptr allowed in C#...

            display("\n");
            // Cast: no cast allowed in C#
            // but C-style type conversion exists
            decimal dec1 = 69.99m;
            display($"(int)({dec1}) = " + ((int)dec1).ToString());
            display($"(float)({dec1}) = " + ((float)dec1).ToString());
            display($"(double)({dec1}) = " + ((double)dec1).ToString());
            display($"(long)({dec1}) = " + ((long)dec1).ToString());

        }


    }


}
