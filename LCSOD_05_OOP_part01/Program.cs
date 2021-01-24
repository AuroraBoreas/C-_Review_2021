using System;
using System.Collections.Generic;

namespace LCSOD_05_OOP_part01
{
    class Program
    {
        static void Main(string[] args)
        {
            Staff s1 = new Staff("SCY", 8);
            Staff s2 = new Staff("ZL", 12);
            Staff s3 = new Staff("LL", 12);
            Staff s4 = new Staff("LM", 8);

            Staff[] arr1 = new Staff[4];
            arr1 = new Staff[4] { s1, s2, s3, s4 };
            // or list
            List<Staff> arr2 = new List<Staff>();
            arr2 = new List<Staff> { s1, s2, s3 };
            arr2.Insert(0, s4);

            Console.WriteLine("container: array");
            for(int i=0; i<arr1.Length; ++i)
            {
                Console.WriteLine(arr1[i].ToString());
                Console.WriteLine(arr1[i].calculatePay());
            }

            Console.WriteLine("container: List");
            int j = 0;
            while(j < arr2.Count)
            { Console.WriteLine(arr2[j].calculatePay()); ++j; }


            Console.WriteLine($"{Staff.msg}, {Staff.year}, {Staff.pi}");
        }
    }
}
