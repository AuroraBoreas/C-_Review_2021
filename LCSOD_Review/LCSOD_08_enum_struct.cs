using System;


// pattern: ncm?
namespace LCSOD_08_enum_struct
{
    enum DaysOfWeek
    {
        Mon,
        Tus,
        Wed,
        Thu,
        Fri,
        Sat,
        Sun
    }
    class Program
    {
        static void Main(string[] args)
        {
            // enum
            {
                /*
                similar concept in c++
                */

                DaysOfWeek myDay = DaysOfWeek.Fri;

                Console.WriteLine($"{myDay}");

            }

            // struct
            {
                // same concept in c++
                // skip
            }
        }
    }
}