using System;

namespace This_Keyword
{
    class Program
    {


        // class Motorcycle    // version 0
        // {
        //     public int m_driverIntensity;
        //     public string m_name;

        //     public void PopAWheely()
        //     {
        //         for(int i=0; i<=m_driverIntensity; ++i)
        //         { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
        //     }

        //     public void SetDriverName(string name)
        //     {
        //         // name = name; // not OK
        //         this.m_name = name;
        //     }
        //     public Motorcycle(){}

        //     public Motorcycle(int driverIntensity)
        //     { m_driverIntensity = driverIntensity; }
        // }

        // class Motorcycle    // version 1
        // {
        //     public int m_driverIntensity;
        //     public string m_name;

        //     public void PopAWheely()
        //     {
        //         for(int i=0; i<=m_driverIntensity; ++i)
        //         { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
        //     }

        //     public void SetDriverName(string name)
        //     {
        //         // name = name; // not OK
        //         this.m_name = name;
        //     }
        //     public Motorcycle(){}

        //     // redundent code
        //     public Motorcycle(int driverIntensity)
        //     { 
        //         m_driverIntensity = (driverIntensity > 10)? 10 : driverIntensity; 
        //     }
        //     public Motorcycle(int driverIntensity, string name)
        //     {
        //         m_driverIntensity = (driverIntensity > 10)? 10 : driverIntensity; 
        //         m_name = name;
        //     }
        // }

        // class Motorcycle    // version 2, using constructor helper methods
        // {
        //     public int m_driverIntensity;
        //     public string m_name;

        //     public void PopAWheely()
        //     {
        //         for(int i=0; i<=m_driverIntensity; ++i)
        //         { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
        //     }

        //     public void SetDriverName(string name)
        //     {
        //         // name = name; // not OK
        //         this.m_name = name;
        //     }

        //     public void SetDriverIntensity(int driverIntensity)
        //     {
        //         m_driverIntensity = (driverIntensity > 10)? 10 : driverIntensity; 
        //     }
        //     public Motorcycle(){}

        //     // redundent code
        //     public Motorcycle(int driverIntensity)
        //     { 
        //         SetDriverIntensity(driverIntensity);
        //     }
        //     public Motorcycle(int driverIntensity, string name)
        //     {
        //         SetDriverIntensity(driverIntensity);
        //         m_name = name;
        //     }
        // }

        // class Motorcycle    // version 3, using constructor chaining(C# technique)
        // {
        //     public int m_driverIntensity;
        //     public string m_name;

        //     public void PopAWheely()
        //     {
        //         for(int i=0; i<=m_driverIntensity; ++i)
        //         { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
        //     }

        //     public void SetDriverName(string name)
        //     {
        //         // name = name; // not OK
        //         this.m_name = name;
        //     }

        //     public Motorcycle(){}

        //     // redundent code
        //     public Motorcycle(int driverIntensity)
        //     : this(driverIntensity, ""){}

        //     public Motorcycle(string name)
        //     : this(0, name){}

        //     // 'master' constructor
        //     public Motorcycle(int driverIntensity, string name)
        //     {
        //         m_driverIntensity = (driverIntensity > 10)? 10 : driverIntensity;
        //         m_name = name;
        //     }
        // }

        // class Motorcycle    // version 4, observe contructor flow
        // {
        //     public int m_driverIntensity;
        //     public string m_name;


        //     public void SetDriverName(string name)
        //     {
        //         // name = name; // not OK
        //         this.m_name = name;
        //     }

        //     public Motorcycle()
        //     { System.Console.WriteLine("In default ctor"); }

        //     // redundent code
        //     public Motorcycle(int driverIntensity)
        //     : this(driverIntensity, "")
        //     { System.Console.WriteLine("int ctor taking an integer"); }

        //     public Motorcycle(string name)
        //     : this(0, name)
        //     { System.Console.WriteLine("in ctor taking a string"); }

        //     // 'master' constructor
        //     public Motorcycle(int driverIntensity, string name)
        //     {
        //         System.Console.WriteLine("in master ctor");
        //         m_driverIntensity = (driverIntensity > 10)? 10 : driverIntensity;
        //         m_name = name;
        //     }
        //     public void PopAWheely()
        //     {
        //         for(int i=0; i<=m_driverIntensity; ++i)
        //         { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
        //     }
        // }

        class Motorcycle    // version 5, observe contructor flow
        {
            public int m_driverIntensity;
            public string m_name;


            public void SetDriverName(string name)
            {
                // name = name; // not OK
                this.m_name = name;
            }

            public Motorcycle()
            { System.Console.WriteLine("In default ctor"); }

            // redundent code
            public Motorcycle(int driverIntensity)
            : this(driverIntensity, "")
            { System.Console.WriteLine("int ctor taking an integer"); }

            public Motorcycle(string name)
            : this(0, name)
            { System.Console.WriteLine("in ctor taking a string"); }

            // 'master' constructor
            public Motorcycle(int driverIntensity=0, string name="")
            {
                System.Console.WriteLine("in master ctor");
                m_driverIntensity = (driverIntensity > 10)? 10 : driverIntensity;
                m_name = name;
            }
            public void PopAWheely()
            {
                for(int i=0; i<=m_driverIntensity; ++i)
                { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
            }
        }

        

        public static int Main(string[] args)
        {
            // this
            {
                /*
                
                + concept:
                    - in c++, this is a pointer to object itself
                    - similar concept like self in Python, me in VB, this in JS etc
                
                + 
                
                */ 

                // see definition of class Motorcycle
            }

            // constructor chaining, P229
            {
                /*
                
                + purpose:
                    - in c++ > 11, it has a smilar concept, so-called constructor delegation

                + concept:
                    - reduce code to enhance readability

                + syntax: constructor(...): constructor(...);

                + delegate sequence:

                    ```c++
                    constructor1(...){}
                    constructor2(...): constructor1(...) { // member initializer; }

                    ```

                    You can’t do member initialization in a constructor that delegates to another constructor.

                    - why: it falls into same hole of members initialization.. same pattern


                + constructor chaining in c#:
                    - designate the constructor that takes the `greatest number of args as the "master constructor"
                    - has it implementation perform the required validation logic;
                    - the remaining constructors can make use of the `this` keyword to forward the incoming arg to the master constructor, and provide any additional args as necessary

                + benifit:
                    - in this way, u need to worry only about maintaining a single constructor for the entire class
                       while the remaining constructors are basically empty
                
                + note: using the `this` keyword to chain constructor alls is never mandatory
                        however, when u make use of this technique, u do tend to end up with a more maintainable and concise cls definition

                        again, using this technique, u can simplify your programming tasks, as the real work is delegated to a signle constructor("master constructor"),
                        while the other constructors simpley "pass the buck"
                */ 

                // see cls Motorcycle version 0 - 1 - 2 - 3
            }

            // constructor calling flow
            {
                // see cls Motorcycle version 4
                FuckWitClassType_ctor_flow();
            }

            // optional args
            {
                // see cls Motorcycle version 5
            }
            return 0;
        }


        private static void FuckWitClassType_ctor_flow()
        {
            Motorcycle mc = new Motorcycle(5);
            mc.SetDriverName("ZL");
            mc.PopAWheely();
            System.Console.WriteLine($"Rider name is {mc.m_name}");
            Console.ReadLine();
            
        }

    }
}