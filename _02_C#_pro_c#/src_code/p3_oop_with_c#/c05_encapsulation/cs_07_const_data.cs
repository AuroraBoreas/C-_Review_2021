using System;

namespace Const_Data
{
    class MathClass
    {
        public const double PI = 3.14;
    }

    class Program
    {

        static int Main(string[] args)
        {
            // const field data, P266
            {
                /*
                
                + concept:
                    - when compiler creates a const var, the memory address of it is NOT allowed to be changed later on
                    - same concept in C++ >= 11

                + comparison c# vs c++, const data member notation
                    
                    example as follows

                    ```c++
                    
                    class Dog
                    {
                    private:
                        // seems it is the only way to do const data member initialization
                        // this syntax works, C++ >= 11

                        int m_age;
                    public:
                        const std::string m_name = "ZL";

                        Dog(int age);
                        void display(void) const;
                    };

                    //const std::string Dog::m_name = "ZL"; // static data member initialization is not working on const..
                    inline Dog::Dog(int age)
                    {
                        m_age = age;

                        // in ctor?
                    //    m_name = "ZL";    // nope
                    }

                    inline void Dog::display(void) const
                    {
                        std::cout << "\nName: " << m_name
                                << "\nAge:  " << m_age
                                << std::endl;
                    }

                    // const data member?
                    {
                        Dog d1 = Dog(3); // can be compiled?

                        d1.display();
                        // cls-lvD:\Reference_01_code\C++\cpp_08_C++STL\src_code\SL-05-Utilities\SL_c++_auxiliary_functions\car.hl access?
                    //        std::cout << Dog.m_name << std::endl; // ofc NOT OK
                        std::cout << d1.m_name << std::endl;  // obj-lvl OK
                        // changeable?
                    //        d1.m_name = "SCY";  // not OK

                    }

                    ```

                + access:
                    - using cls-lvl prefix to access const data members
                      why: this is because const fields of a class are implicitly static
                    - it is permissible to define and access a local const var within the scope of a method or propery
                
                + 
                */ 

                TestClassWithConstData();
                LocalConstStringVar();
            }

            // static vs const
            {
                /*
                
                + mechanism
                    - c++ does NOT have cls-lvl static or const; MUST be obj-lvl
                    - const var MUST be initialized at the point of declaration
                    - static var can be intialized later after declaration
                    - also, subtle meaning difference
                
                */ 

            }

            return 0;
        }

        static void TestClassWithConstData()
        {
            System.Console.WriteLine($"=> the value of PI is: {MathClass.PI}");
            System.Console.ReadLine();
        }

        static void LocalConstStringVar()
        {
            const string fixedStr = "hello world";
            System.Console.WriteLine(fixedStr);

            // fixedStr = "u change me?";
        }


    }
}