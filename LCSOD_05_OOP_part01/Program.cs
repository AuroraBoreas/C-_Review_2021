using System;


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

            for(int i=0; i<4; ++i)
            {
                Console.WriteLine(arr1[i].ToString());
            }
        }
    }
}
