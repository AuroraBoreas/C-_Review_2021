using System;


// pattern: ncm?
namespace LCSOD_06_OOP_p1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Staff
            {
                /*

                */

                Staff s1 = new Staff(); // default constructor

                Staff[] staffs = new Staff[5];
                staffs[0] = new Staff("ZL", 8);
                staffs[1] = new Staff("Zhang", "Liang", 8);
                staffs[2] = new Staff("SCY", 8);
                staffs[3] = new Staff("LL", 12);

                foreach(Staff s in staffs)
                {
                    Console.WriteLine(s.ToString());
                }

            }


        }
    }
}