using System;

namespace Partial_Class
{
    class Employee  // version 0
    {
        private string m_name;
        private int m_id;
        private double m_pay;
        private string m_ssn;

        // constructors
        Employee(){}
        Employee(string name)
        : this(name, 1, 30.0, "12345"){}
        Employee(int id)
        : this("noname", id, 30.0, "12345"){}
        Employee(string name, int id, double pay, string ssn)
        {
            m_name = name; m_id = id; m_pay = pay; m_ssn = ssn;
        }

        // getter, setter
        public string Name { get => m_name; set => m_name = value; }
        public string ID { get => m_id; set => m_id = value; }
        public double Pay { get => m_pay; set => m_pay = value; }

        // repr
        public void Display()
        {
            System.Console.WriteLine($"\nName: {m_name} \nID: {m_id} \nPay: {m_pay} \nSSN: {m_ssn}");
        }

    }

    partial class Employee  // part 01
    {
        // methods

        // props

    }

    partial class Employee  // part 02
    {
        // data members
        // ctors
    }

    class Container
    {
        partial class Nested
        {
            void Test(){}
        }

        partial class Nested
        {
            void Test2(){}
        }
    }

    // or
    partial class Container2
    {
        partial class Nested{}
    }

    partial class Container2
    {
        partial class Nested{}
    }

    partial class Moon{};
    partial class Moon{};

    partial class Earth: Planet, IRotate {}
    partial class Earth: IRevolve {}


    class Program
    {
        static int Main(string[] args)
        {
            // partial kw
            {
                /*
                
                + syntax: partial class Cls_Name;

                    ```c#
                    partial class Cls_Name
                    {
                        ...;
                    }

                    ```
                + mechanism
                    - in c++, no such mechanism but
                    // - it is alike to "xxx.h" + "xxx.cpp" class definition + declaration pattern in c++
                    // - but not 100% for sure
                    - in c#, split class into several parts which can be worked by programmers
                    - all parts should be declared with partial kw
                    - all parts should have same-lvl access modifiers
                    - read more at link [MSDN C# partical class]
                    - compiler auto combine all parts together at compile time

                
                */ 

            }

            return 0;
        }


    }
}