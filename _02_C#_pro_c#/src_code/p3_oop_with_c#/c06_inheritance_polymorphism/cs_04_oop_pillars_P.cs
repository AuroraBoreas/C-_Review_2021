using System;

namespace OOP_Pillars
{

    partial class Employee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Pay { get; set; }
        
        public Employee(string s, int id, double p)
        {
            Name = s; ID = id; Pay = p;
        }
        public virtual void GiveBonus(float amount)
        { this.Pay += amount; }

        public void Display()
        {
            System.Console.WriteLine($"\nName: {Name} \nID: {ID} \n Pay: {Pay}");
        }
        // ...;
    }

    class Manager: Employee
    {
        public int StockOptions { get; set; }
        
        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random rnd = new Random();
            StockOptions += rnd.Next(500);
        }
    }

    class SalesPerson: Employee
    {
        public int SalesNumber { get; set; }
        
        public override void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if(SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if(SalesNumber >= 101 && salesBonus <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // polymorphism
            {
                // using override kw to explicitly override virtual methods of base class
                /*
                
                + mechnism:
                    - same with override in C++ >= 11
                
                */ 
                FuckEmployeeClassHierarchy();
            }

            // sealing virtual members using sealed kw
            {
                /*
                
                + mechnism:
                    - same with final in c++ >= 11

                */ 

            }

            // abc
            {
                /*
                
                + mechnism:
                    - same with abc in C++
                
                */ 

            }
            return 0;
        }

        static void FuckEmployeeClassHierarchy()
        {
            System.Console.WriteLine("=> fun with Employee class hierarchy:");

            Manager m1 = new Manager("ZL", 1234, 999.999);
            m1.GiveBonus(300);
            m1.Display();
            Console.ReadLine();
        }

    }
}