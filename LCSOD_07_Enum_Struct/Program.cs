using System;

namespace LCSOD_07_Enum_Struct
{
    enum DaysOfWeek
    {
        Mon,
        Tue,
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
            {
                /*
                 
                + in C++, enum syntax:
                    enum EName
                    {
                        // ... // by default, starts from 0;
                    }

                    C++ >= 11
                    enum class EName
                    {
                        // ... // u can't compare different enum members from now on
                    }
                 

                + in C#, similar with C++ < 11


                + ctrl + K + D to auto format my code!

                 */


                DaysOfWeek myDay = DaysOfWeek.Fri;
                Console.WriteLine($"{myDay}");
            }

            // struct
            {
                /*
                 
                + in C++, struct is close to class
                    by convension, using class for complex simulation, using struct for simple simulation.
                    by default, members of class is private
                    by default, members of struct is public
                    access modifiers: private, public, protected and friend are useable in both struct and class
                
                + in C#, similar conception as C++
                    // skip
                 
                 */

            }
        }
    }
}
