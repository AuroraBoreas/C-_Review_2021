using System;

namespace OOP_Pillars
{
    class Employee
    {
        // data members
        // ctors
        // props
        // methods
    }

    class Manger: Employee
    {
        public int StockOptions { get; set; }
    }

    class SalesPerson: Employee
    {
        public int SalesNumber { get; set; }
    }


    class Program
    {
        static int Main(string[] args)
        {
            // details of I
            {
                /*

                + base kw
                    - using base kw whenever a subclass wants to access a public or protected member defined by a parent cls 
                
                */
            }

            return 0;
        }

        static void FuckWithClsHierarchy()
        {
            System.Console.WriteLine("=>The Employee Class Hierarchy:");

            SalesPerson ZL = new SalesPerson();
            ZL.Age = 31;
            ZL.name = "ZL";
            ZL.SalesNumber = 50;
            Console.ReadLine();
            
        }

    }
}