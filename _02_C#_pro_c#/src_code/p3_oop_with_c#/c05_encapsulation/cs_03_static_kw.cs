using System;

namespace Static_KW
{
    class Program
    {
        // class SavingAccount // version 0
        // {
        //     public double m_balance;

        //     public static double m_rate = .04;

        //     public SavingAccount(double balance)
        //     { m_balance = balance; }
        // }

        // class SavingAccount // version 1
        // {
        //     public double m_balance;

        //     public static double m_rate = .04;

        //     public SavingAccount(double balance)
        //     { m_balance = balance; }

        //     public static void SetRate(double newRate)
        //     { m_rate = newRate; }

        //     public static double GetRate()
        //     { return m_rate; }
        // }

        class SavingAccount // version 2
        {
            public double m_balance;

            public static double m_rate = .04;

            public SavingAccount(double balance)
            { m_balance = balance; }

            static SavingAccount()
            {
                System.Console.WriteLine("In static ctor!");
                m_rate = .04;
            }

            public static void SetRate(double newRate)
            { m_rate = newRate; }

            public static double GetRate()
            { return m_rate; }
        }

        static class TimeUtilityClass
        {
            public static void PrintTime()
            => System.Console.WriteLine(Now.ToShortTimeString());

            public static void PrintDate()
            => System.Console.WriteLine(Today.ToShortDateString());
        }

        public static int Main(string[] args)
        {
            // static kw
            {
                /*
                
                + concept:
                    - in c#, cls level methods, cls level data members, using in
                        > static kw decorated members are shared status over objects of a class
                        > data members of a class
                        > method members of a class
                        > propertie of a class
                        > a constructor
                        > the entire class defintion
                        > in conjunction with the using kw

                    - in c++, static kw is a total different animal
                        > static kw decorated members are shared status over objects of a class
                        > static kw modifier means lifetime of modifee is as long as main
                        > static data members couple with static methods
                        > static data members must be initialized in constructor w/o static kw 
                    
                    - in python, it has no static kw, but employes @classmethod, @staticmethod to achieve similar effect

                + mechanism:
                    - compiler allocates the static data into memory exactly one time
                
                + usage:
                    - static data is perfect when u have a value that should be common to all objects of that category

                */

                FuckWithStaticMembers();
            }
            
            // static constructor
            {
                /*
                
                + mechanism:
                    - it is same mechanism with static method, static data
                    - using regular constructors will fuck up static data members
                    - compiler calls static constructors before the first use, and never calls them again for that instance of the application
                
                + note: "only one"
                    - a class may define only one single static constructor
                    - a static constructor does NOT take any access modifier and can NOT take any arg, and 
                    - a static constructor executes exactly only once, regardless of how many obj of the cls are created
                    - the runtime invokes the static constructor when it creates an instance of the class or before accessing the first static member invoked by the caller
                    - a static constructor executes before any instance-level constructors
                
                */ 

            }

            // static cls
            {
                /*
                
                + usage:
                    - static class can NOT be creatable using the `new` kw
                    - it can contain only method members or data members marked with `static` kw

                    > otherwise, compile complains

                + when to use:
                    - apply statci kw when designing a utility class
                
                */ 
                FuckWithStaticClass();
            }

            // import static members via using kw
            {
                /*
                
                Console is static cls in System
                
                + note: be aware of namespace confliction
                
                */ 
            }

            return 0;
        }

        static void FuckWithStaticMembers()
        {
            System.Console.WriteLine("=> fuck with static data members");
            SavingAccount s1 = new SavingAccount(50);
            SavingAccount s2 = new SavingAccount(100);
            SavingAccount s3 = new SavingAccount(10_000.75);
            Console.ReadLine();
        }

        static void FuckWithStaticClass()
        {
            System.Console.WriteLine("=> fuck with static class:");

            // OK
            TimeUtilityClass.PrintDate();
            TimeUtilityClass.PrintTime();

            // compile error
            // TimeUtilityClass u = new TimeUtilityClass(); // not OK
            Console.ReadLine();
            
        }


    }
}