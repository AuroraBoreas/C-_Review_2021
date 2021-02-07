using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PersonLibrary;
namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var p = new Person("Zhang", "Liang", 35);   // <-- using parameterized ctors only;
            Person p4 = new Person { FirstName = "LL", LastName = "MM", Age = 31 }; // <-- using uniform initializer only;
            Person p2 = new Person() { FirstName="X", LastName="Y", Age=31 };   // <-- using default ctor, and uniform initializer;
            Person p3 = new Person("DD") { LastName = "EE", Age = 40 }; // <-- using paramaterized ctor, and uniform initializer;
             

            Console.WriteLine(p.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine(p3.ToString());
            Console.WriteLine(p4.ToString());

            Console.ReadLine();
        }
    }
}
