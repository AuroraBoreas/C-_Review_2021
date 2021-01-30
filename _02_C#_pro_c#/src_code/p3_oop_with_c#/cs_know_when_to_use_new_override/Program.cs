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
            Base bc = new Base();
            Derived dc = new Derived();
            Base bcdc = new Derived();

            bc.Method1();   // bc method1
            bc.Method2();   // bc method2
            dc.Method1();   // dc method1. override method to implement dc's own method
            dc.Method2();   // dc method2
            bcdc.Method1(); // dc method1. polymorphism(v-table) due to override
            bcdc.Method2(); // bc method2. implicit type conversion, upcasting


            /*
            
            conclusion:
            - new is used to explicitly hide implementation above and suppress compiler warning
            - override always pairs with virtual, is used to achieve polymorphism via v-table
             
            */

        }
    }
}