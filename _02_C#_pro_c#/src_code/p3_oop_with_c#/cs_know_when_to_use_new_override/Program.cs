using System;

namespace cs_know_when_to_use_new_override
{
    //class Base  // version 0
    //{
    //    public void Method1()
    //    {
    //        Console.WriteLine("BC - Method1");
    //    }

    //    public void Method2() { Console.WriteLine("BC - Method2"); }
    //}
    class Base  // version 1, using virtual-override pair
    {
        virtual public void Method1()
        {
            Console.WriteLine("BC - Method1");
        }

        public void Method2() { Console.WriteLine("BC - Method2"); }
    }
    //class Derived: Base // version 0
    //{
    //    public void Method2()   // compiler warning, as DC Method2 is hiding BC Method2
    //    {
    //        Console.WriteLine("DC - Method2");
    //    }
    //}

    //class Derived : Base // version 1, using new kw to shadding
    //{
    //    public new void Method2()   // using new to suppress the warning and explicitly hide implementation above me. output should be same
    //    {
    //        Console.WriteLine("DC - Method2");
    //    }
    //}

    class Derived : Base // version 2, using override kw
    {
        override public void Method1()  // compiler error, as override must match with virtual pair
        { Console.WriteLine("DC - Method1"); }
        public new void Method2()   // using new to suppress the warning and explicitly hide implementation above me. output should be same
        {
            Console.WriteLine("DC - Method2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // link 1: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
            // link 2: https://stackoverflow.com/questions/1399127/difference-between-new-and-override
            Base bc = new Base();
            Derived dc = new Derived();
            Base bcdc = new Derived();

            bc.Method1();           // bc method1
            bc.Method2();           // bc method2
            Console.WriteLine();

            dc.Method1();           // dc method1. override method to implement dc's own method
            ((Base)dc).Method1();   // bc method1. using upcasting to access original method of the base class
            dc.Method2();           // dc method2
            
            Console.WriteLine();
            bcdc.Method1();         // dc method1. polymorphism(v-table) due to override
            ((Base)bcdc).Method1(); // dc method1.
            bcdc.Method2();         // bc method2. implicit type conversion, upcasting


            /*
            
            conclusion:
            - new is used to explicitly hide implementation above and suppress compiler warning.
              but u can still access the original method by upcasting to the base class type

            - override may pair with virtual, and MUST be used on abstract methods; is used to achieve polymorphism via v-table.
              but u can never Access the original method by upcasting to the base class type
             
            */

        }
    }
}