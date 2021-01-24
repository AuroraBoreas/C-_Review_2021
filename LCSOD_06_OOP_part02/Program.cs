using System;

namespace LCSOD_06_OOP_part02
{
    class Program
    {
        static void Main(string[] args)
        {
            // inheritance
            {
                NormalMember nm1 = new NormalMember("ZL", 1, 2013, "Special Rate");
                VIPMember vm1 = new VIPMember("SCY", 2, 2011);

                nm1.calculateAnnualFee();
                vm1.calculateAnnualFee();

                Console.WriteLine(nm1.ToString());
                Console.WriteLine(vm1.ToString());

            }

            // polymorphism
            {
                Member[] clubMembers = new Member[5];
                clubMembers[0] = new VIPMember("ZL", 1, 2013);
                clubMembers[1] = new NormalMember("SCY", 2, 2011, "special rate");
                clubMembers[2] = new NormalMember("LL", 3, 2011, "special rate");
                clubMembers[3] = new VIPMember("LM", 4, 2012);
                clubMembers[4] = new VIPMember("LL", 5, 2012);

                string isVIP;
                foreach(Member m in clubMembers)
                {
                    m.calculateAnnualFee();
                    Console.WriteLine(m.ToString());
                    isVIP = (m.GetType() == typeof(VIPMember))? "Yes" : "No";
                    Console.WriteLine("VIP membership? : {0}", isVIP);
                }
            }

            // abstraction
            {
                /*
                ABS(abstract class)
                
                + in C++, sytanx:
                    class ClsName
                    {
                        private:
                            // data members
                            // ...
                        public:
                            // constructors
                            // data methods
                            virtual void print(void) = 0;   // using = 1 to declare the Class is abstract class. at least 1.
                            // ...
                    };
                
                    // u cant create obj of abs class in C++
                 
                + in C#, syntax:
                    abstract class ClsName
                    {
                        // data members
                        // ...
                        // constructors
                        // ...
                        // abstract void print();
                        // ...
                    }
                    
                    // u cant create obj of abs class in C# as well
                    // good consistency thou

                    // see "abs.cs" and "drivedCls.cs"
                */

                //MyClass mc1 = new MyClass(); // not OK. compiler complains
            }

            // interface
            {
                // in C++, there is no such conception. but it can be implemented through abstract class
                // see "IShape.cs"
            }

            // access modifiers in C#
            {
                /*
                + in C++, access modifiers: private, public, protected, friend

                + in C#, access modifiers: private, public, protected, internal
                    - wtf is "internal"?
                    link: [https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers]
                    answer: The type or member can be accessed by any code in the same assembly, but not from another assembly.
                 
                */

                var myBase = new InternalBaseClass(); // OK?
            }
        }
    }
}
