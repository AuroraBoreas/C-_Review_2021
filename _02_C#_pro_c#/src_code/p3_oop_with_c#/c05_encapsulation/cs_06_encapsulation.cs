  
using System;


namespace OOP_Pillars
{

    class Program
    {
        // class Employee // version 0
        // {
        //     private string m_name;
        //     private int m_ID;
        //     private float m_pay;

        //     public Employee(){}
        //     public Employee(string name, int id, float pay)
        //     {
        //         m_name = name;
        //         m_ID = id;
        //         m_pay = pay;
        //     }

        //     public string Name
        //     {
        //         get => m_name;
        //         set => m_name = value;
        //     }
        //     public int ID
        //     {
        //         get => m_ID;
        //         set => m_ID = value;
        //     }
        //     public int Pay
        //     {
        //         get => m_Pay;
        //         set => m_Pay = value;
        //     }

        //     public void GiveBonus(float amount)
        //     {
        //         m_pay += amount;
        //     }

        //     public void Display()
        //     {
        //         System.Console.WriteLine($"Name: {m_name}");
        //         System.Console.WriteLine($"ID: {m_ID}");
        //         System.Console.WriteLine($"Pay: {m_pay}");
        //     }
        // }

        // class Employee // version 1
        // {
        //     private string m_name;
        //     private int m_ID;
        //     private float m_pay;
        //     private int m_age;

        //     public Employee(){}
        //     public Employee(string name, int id, int age, float pay)
        //     {
        //         m_name = name;
        //         m_ID = id;
        //         m_age = age;
        //         m_pay = pay;
        //     }

        //     public string Name
        //     {
        //         get => m_name;
        //         set => m_name = value;
        //     }
        //     public int ID
        //     {
        //         get => m_ID;
        //         set => m_ID = value;
        //     }
        //     public int Pay
        //     {
        //         get => m_pay;
        //         set => m_pay = value;
        //     }
        //     public int Age
        //     {
        //         get => m_age;
        //         set => m_age = value;
        //     }

        //     public void GiveBonus(float amount)
        //     {
        //         m_pay += amount;
        //     }

        //     public void Display()
        //     {
        //         System.Console.WriteLine($"Name: {m_name}");
        //         System.Console.WriteLine($"ID: {m_ID}");
        //         System.Console.WriteLine($"Age: {m_age}");
        //         System.Console.WriteLine($"Pay: {m_pay}");
        //     }
        // }

        // class Employee // version 2
        // {
        //     private string m_name;
        //     private int m_ID;
        //     private float m_pay;
        //     private int m_age;
        //     private string m_SSN;

        //     public Employee(){}
        //     public Employee(string name, int id, int age, float pay, string SSN)
        //     {
        //         m_name = name;
        //         m_ID = id;
        //         m_age = age;
        //         m_pay = pay;

        //         m_SSN = SSN;
        //     }

        //     public string Name
        //     {
        //         get => m_name;
        //         set => m_name = value;
        //     }
        //     public int ID
        //     {
        //         get => m_ID;
        //         set => m_ID = value;
        //     }
        //     public int Pay
        //     {
        //         get => m_pay;
        //         set => m_pay = value;
        //     }
        //     public int Age
        //     {
        //         get => m_age;
        //         set => m_age = value;
        //     }

        //     public string SSN
        //     {
        //         get => m_SSN;
        //     }

        //     public void GiveBonus(float amount)
        //     {
        //         m_pay += amount;
        //     }

        //     public void Display()
        //     {
        //         System.Console.WriteLine($"Name: {m_name}");
        //         System.Console.WriteLine($"ID: {m_ID}");
        //         System.Console.WriteLine($"Age: {m_age}");
        //         System.Console.WriteLine($"Pay: {m_pay}");
        //     }
        // }
        class Employee // version 3
        {
            private string m_name;
            private int m_ID;
            private float m_pay;
            private int m_age;
            private string m_SSN;

            public Employee(){}
            public Employee(string name, int id, int age, float pay, string SSN)
            {
                m_name = name;
                m_ID = id;
                m_age = age;
                m_pay = pay;

                m_SSN = SSN;
            }

            public string Name
            { get; set; }
            public int ID
            { get; set; }

            public int Pay
            { get; set; }

            public int Age
            { set; }    // not OK

            public string SSN
            { get; }    // OK

            public void GiveBonus(float amount)
            {
                m_pay += amount;
            }

            public void Display()
            {
                System.Console.WriteLine($"Name: {m_name}");
                System.Console.WriteLine($"ID: {m_ID}");
                System.Console.WriteLine($"Age: {m_age}");
                System.Console.WriteLine($"Pay: {m_pay}");
            }
        }

        // class Car // version 0
        // {
        //     private string m_name;
        //     public int m_speed;
        //     public string m_color;

        //     public string Name { get; set; }
        //     public int Speed { get; set; }
        //     public string Color { get; set; }
        //     public void Display()
        //     {
        //         System.Console.WriteLine($"\nName: {m_name}, \nSpeed: {m_speed}, \nColor: {m_color}");
        //     }
        // }

        class Car // version 1
        {
            // no need to define backing fields
            // private string m_name;
            // public int m_speed;
            // public string m_color;

            public string Name { get; set; }
            public int Speed { get; set; }
            public string Color { get; set; }
            public void Display()
            {
                System.Console.WriteLine($"\nName: {m_name}, \nSpeed: {m_speed}, \nColor: {m_color}");
            }
        }

        // class Garage // version 0
        // {
        //     // hidden is 0
        //     public int NumberOfCars
        //     { get; set; }

        //     // hidden is null
        //     public Car MyAuto { get; set; }
        // }

        // class Garage // version 1
        // {
        //     // hidden is 0
        //     public int NumberOfCars
        //     { get; set; }

        //     // hidden is null
        //     public Car MyAuto { get; set; }

        //     public Garage()
        //     {
        //         MyAuto = new Car();
        //         NumberOfCars = 1;
        //     }

        //     public Garage(int n, Car c)
        //     { NumberOfCars = n; MyAuto = c; }
        // }

        class Garage // version 2
        {
            // hidden is 0
            public int NumberOfCars
            { get; set; } = 1;

            // hidden is null
            public Car MyAuto { get; set; } = new Car();

            public Garage()
            {}

            public Garage(int n, Car c)
            { NumberOfCars = n; MyAuto = c; }
        }

        // class Point // version 0
        // {
        //     public int X { get; set; }
        //     public int Y { get; set; }

        //     public Point(int x, int y)
        //     { this.X = x; this.Y = y; }
        //     public Point(){}
        //     public void Display()
        //     { System.Console.WriteLine($"[{X}, {Y}]"); }
        // }

        enum PointColor
        {
            LightBlue, BloodRed, Gold
        }

        class Point // version 1
        {
            public int X { get; set; }
            public int Y { get; set; }
            public PointColor Color { get; set; }

            public Point(int x, int y)
            { this.X = x; this.Y = y; this.Color = PointColor.Gold; }
            public Point(PointColor pc){ Color = pc; }

            public Point()
            : this(PointColor.BloodRed)
            {}

            public void Display()
            {
                System.Console.WriteLine($"[{X}, {Y}]");
                System.Console.WriteLine($"Point is {Color}");
            }
        }

        class Rectangle
        {
            private Point topLeft = new Point();
            private Point bottomRight = new Point();

            public Point TopLeft
            { get; set; }
            public Point BottomRight
            { get; set; }

            public void Display()
            {
                System.Console.WriteLine("[TopLeft: {0}, {1}, {2} BottomRight: {3}, {4}, {5}]", topLeft.X, topLeft.Y, topLeft.Color, bottomRight.X, bottomRight.Y, bottomRight.Color);
            }
        }

        static int Main(string[] args)
        {
            // prop
            {
                TestClassEmployee();
            }

            // automatic prop
            {
                /*
                + note:
                    - "read-only automatic property" can omit the set scope;
                    - "write-only automatic property" can NOT omit
                + can be verbose
                    - verbose, level one
                    - verbose, level two
                + default values
                    - ValueType, autogenerated prop will be assigned a safe default value
                    - ReferenceType, autogenerated prop will be assigned a default value of null(which can prove problematic if u are not careful)
                + initialization autoprop
                    - synax: private int numberOfDoors = 2;
                */

                TestClassCar(); // version 0
                TestClassGarage_Ver1();
            }

            // initialization constructors, P263
            {
                /*
                + initialization
                    - traditional way
                    - uniform initialization
                + note
                    - be aware that when u are constructing a type using initialization syntax, u are able to invoke any constructor defined by class
                */

                TestListInitialization();
                CallingCustomCtorWithInitSyntax();
            }

            // initialization Data with init syntax, p264
            {

                FuckWithInitDataSyntax();

            }

            return 0;
        }

        static void TestClassEmployee()
        {
            Employee emp1 = new Employee();
            emp1.Name = "ZL";
            emp1.Display();
            System.Console.ReadLine();
        }


        static void TestClassCar()
        {
            System.Console.WriteLine("=> FuckWithAutoProp:");

            Car c = new Car();
            c.Name = "ZL";
            c.Speed = 100;
            c.Color = "Red";

            System.Console.WriteLine($"Your car is named {c.Name}? that's odd...");
            c.Display();

            System.Console.ReadLine();
        }

        static void TestClassGarage()
        {
            Garage g = new Garage();

            System.Console.WriteLine($"Number of Cars: {g.NumberOfCars}");
            System.Console.WriteLine(g.MyAuto.Name); // not OK, g.MyAuto is set to null by default

            System.Console.ReadLine();

        }

        static void TestClassGarage_Ver1()
        {
            System.Console.WriteLine("=> Fuck with automatic property:");

            Car c = new Car();
            c.Name = "SCY";
            c.Speed = 200;
            c.Color = "Red";
            c.Display();

            Garage g = new Garage();
            g.MyAuto = c;

            System.Console.WriteLine($"Number of Cars: {g.NumberOfCars}");
            System.Console.WriteLine(g.MyAuto.Name); // not OK, g.MyAuto is set to null by default

            System.Console.ReadLine();

        }

        static void FuckWithObjInitSyntax()
        {
            System.Console.WriteLine("=> fun with obj init syntax:");

            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 10;
            p1.Display();

            Point p2 = new Point(20, 20);
            p2.Display();

            Point p3 = new Point(x = 30, y = 30);
            p3.Display();

            System.Console.ReadLine();

        }

        static void TestListInitialization()
        {
            // calling default constructor implicitly
            Point p1 = new Point{ X = 30, Y = 30 };
            // calling default constructor explicitly
            Point p2 = new Point() { X = 30, Y = 30 };
            // calling parametarized constructor
            Point p3 = new Point(10, 16) { X = 100, Y = 100 }; // X 100, Y 100;
            System.Console.ReadLine();
        }

        static void CallingCustomCtorWithInitSyntax()
        {
            Point goldPoint = new Point(PointColor.Gold){X=90, Y=20};
            goldPoint.Display();
            System.Console.ReadLine();
        }

        static void FuckWithInitDataSyntax()
        {
            // calling default ctor implicitly
            Rectangle r1 = new Rectangle
            {
                TopLeft = new Point{X=10, Y=10},
                BottomRight = new Point{X=200, Y=200}
            };

            r1.Display();

            // old-school approach
            Rectangle r = new Rectangle();
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 10;
            r.TopLeft = p1;
            Point p2 = new Point();
            p2.X = 200;
            p2.Y = 200;
            r.BottomRight = p2;
            r.Display();

            System.Console.ReadLine();
        }

    }
}