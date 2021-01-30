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
                    - core: uniformation or compatibility 
                
                + uniqueness
                    - the ultimate base classi in the System is System.Object; everything in c# "is-a" Object
                    - `(C-style)var;` cast pattern only
                
                + behavior pattern
                    - casting btwn two types is that they have "is-a" relationship
                    
                
                + 


                
                */ 
                CastingExample();

            }

            // kw as
            {
                /*
                
                + casting is not always safe
                    - explicit casting is evaluated at runtime
                    - as a programmer, u MUST catch possible invalid casting during runtime
                
                + how to do it?
                    - using try... catch... brainlessly
                    - using typeof to check type beforehand
                    - using kw as
                        - syntax: `var as T;`
                        - return_value is null or value;
                    - using kw is
                        - syntax: `var is T;`
                        - return false or true;
                
                */ 
                CatchPossibleInvalidCast_trycatch();
                CatchPossibleInvalidCast_as();

            }

            // kw is can do more, P303
            {
                // is can also be used in conjunction with discard var _(underscore symbol)
                // purpose: create a checkall in `if` or `switch` statement
                
                object obj = null;
                if(obj is _)
                {
                    // ...;
                }

            }

            // pattern matching revisit
            {
                // see GivePromtion();
                // see GivePromtion_is();
                // see GivePromtion_wo_pattern_match();
                // see GivePromtion_with_pattern_match();

            }

            


            return 0;
        }

        static void GivePromtion(Employee emp) 
        {
            System.Console.WriteLine("=> {0} was promoted", emp.Name);
        }

        static void GivePromtion_is(Employee emp) 
        {
            System.Console.WriteLine("=> {0} was promoted", emp.Name);
            if(emp is SalesPerson)
            {
                // ...;
            }
            if(emp is Manager)
            {
                // ...;
            }
        }

        static void GivePromtion_wo_pattern_match(Employee emp)
        {
            System.Console.WriteLine("=> {0} was promoted", emp.Name);

            switch(emp)
            {
                case SalesPerson s:
                    // ...;
                    break;
                case Manager m:
                    // ...;
                    break;
            }
            Console.ReadLine();
        }

        static void GivePromtion_with_pattern_match(Employee emp)
        {
            System.Console.WriteLine("=> {0} was promoted", emp.Name);

            switch(emp)
            {
                case SalesPerson s when s.SalesNumber > 5:
                    // ...;
                    break;
                case Manager m when m.StockOptions > 10:
                    // ...;
                    break;
            }
            Console.ReadLine();
        }
        static void GivePromtion_with_pattern_match_and_discards(Employee emp)
        {
            System.Console.WriteLine("=> {0} was promoted", emp.Name);

            switch(emp)
            {
                case SalesPerson s when s.SalesNumber > 5:
                    // ...;
                    break;
                case Manager m when m.StockOptions > 10:
                    // ...;
                    break;
                case Intern _:
                    // ...;
                    break;
                case null:
                    // ...;
                    break;
            }
            Console.ReadLine();
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

        static void CatchPossibleInvalidCast_trycatch()
        {
            object zl = new Manager();
            Hexagon hx;

            try
            {
                hex = (Hexagon)zl;
            }
            catch(InvalidCastException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            
        }

        static void CatchPossibleInvalidCast_as()
        {
            object[] arrObjs = new object[4];
            arrObjs[0] = new Hexagon();
            arrObjs[1] = false;
            arrObjs[2] = new Manager();
            arrObjs[3] = "Last thing";
            
            Hexagon hx;
            foreach(object obj in arrObjs)
            {
                hx = obj as Hexagon;
                if(hx == null)
                {
                    System.Console.WriteLine("item is not a hexgon");
                }
                else
                {
                    hx.Draw();
                }
            }
        }
    }
}