using System;

namespace LCSOD_04_make_decisions
{
    class Program
    {
        static bool isLeapYear(int year)
        { return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0); }

        static bool setDate(int ye, int mo, int da)
        {
            if (ye < 1) return false;
            if (mo < 1 || mo > 12) return false;
            if (da < 1 || da > 31) return false;
            switch(mo)
            {
                case 2: if(isLeapYear(ye))
                        {
                            if (da > 29)
                            { return false; }
                        }
                        else
                        { 
                            if (da > 28)
                            { return false; } 
                        }
                        break;
                case 4:
                case 6:
                case 9:
                case 11: if (da > 30) { return false; } break;
            }

            return true;
        }

        static void Main(string[] args)
        {
            {
                /*
                + if() {} else if() {} else {} statement 

                */

                int year = 2021;
                // shortcut
                string res = isLeapYear(year) ? "is" : "is not";
                Console.WriteLine($"{year} {res} leap year.");
                // or
                if(isLeapYear(year))
                { res = "is"; }
                else
                { res = "is not";  }
                Console.WriteLine($"{year} {res} leap year.");
            }

            {
                /*
                + switch(...) case(...) default(...) 
                */
                int year = 2021, month = 12, day = 33;
                Console.WriteLine($"setDate({year}/{month}/{day}) == {setDate(year, month, day)}");
            }

            {
                /* exception handler
                - try ... catch ...
                - try ... finally ...
                - try ... catch ... finally ...
                
                common exception classes:
                - ArithmeticException
                - ArrayTypeMismatchException
                - DivideByZeroException
                - IndexOutOfRangeException
                - InvalidCastException
                - NullReferenceException
                - OutOfMemoryException
                - OverflowException
                - StackOverflowException
                - TypeInitializationException

                */
                int a = 42;
                int b = 0;
                var res = 0;

                try
                {
                    res = a / b;
                }
                catch(DivideByZeroException ex)
                { Console.WriteLine(ex.Message); res = -1; }
                finally
                { res = -2; }

                Console.WriteLine(string.Format("{0}/{1} = {2}", a, b, res)); // -2
            }
        }
    }
}
