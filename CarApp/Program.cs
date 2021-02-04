using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsCar sc1 = new SportsCar("ZL", 100, 20);
            MiniVan mv1 = new MiniVan { PetName = "XY", MaxSpeed=100, CurrentSpeed=10 };
            Console.WriteLine(sc1.ToString());
            Console.WriteLine(mv1.ToString());

            sc1.TurboBoost();
            mv1.TurboBoost();


            Console.ReadLine();
        }
    }
}
