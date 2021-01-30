using System;

namespace Casting_Rule
{
    class Employee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Pay { get; set; }
        private string SSN { get; set; }
        Employee(){}
        Employee(string name)
        : this(name, "111", 0.0, "123456"){}
        Employee(int id)
        : this("noname", id, 0.0, "123456"){}
        Employee(double pay)
        : this("noname", "111", pay, "123456"){}
        Employee(string ssn)
        : this("noname", "111", 0.0, ssn){}
        // ...; more
        Employee(string name, int id, double pay, string ssn)
        {
            Name = name;
            ID = id;
            Pay = pay;
            SSN = ssn;
        }
        
        public void display()
        {
            System.Console.WriteLine($"\nName: {Name} \nID: {ID} \nPay: {Pay} \nSSN: {SSN}");
        }
    }
    
    class SalesPerson: Employee
    {
        public int SalesNumber { get; set; }
    }

    class Manager: Employee
    {
        public int StockOptions { get; set; }
    }

    abstract class Shape
    {
        // data members
        // ctors
        // props
        // methods
        public abstract void Draw();
    }

    class Circle: Shape
    {
        // ... override virtual/abstract methods
        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }

    class Hexagon: Shape
    {

    }


    class Pogram
    {
        static int Main(string[] args)
        {
            // cast
            {
                /*
                
                + concept
                    - same concept in C++
                
                + uniqueness
                    - the ultimate base classi in the System is System.Object; everything in c# "is-a" Object
                    - `(C-style)var;` cast pattern only
                
                + behavior pattern
                    - casting btwn two types is that they have "is-a" relationship
                    
                
                + 


                
                */ 
                CastingExample();

            }

            // as kw
            {

            }

            static void GivePromtion(Employee emp) 
            {
                System.Console.WriteLine("=> {0} was promoted", emp.Name);
            }

            static void CastingExample()
            {
                object zl = new Manager("ZL", 123, 99.99, "123456");
                GivePromtion(zl); // not OK. compiler doesn't know how to convert object -> Employee
                GivePromtion((Manager)zl); // OK. explicitly convert object -> Manager;

                Employee xy = new Manager("xy", 345, 99.99, "12345567");
                GivePromtion(xy); // OK

                SalesPerson zz = new SalesPerson("zz", 567, 9.9, "1234568");
                GivePromtion(zz); // OK, upcasting

                Console.ReadLine();
            }
            


            return 0;
        }
    }
}