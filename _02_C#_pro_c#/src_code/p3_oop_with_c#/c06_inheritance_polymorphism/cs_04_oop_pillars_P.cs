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



    // abstract class Shape // version 0
    // {
    //     public string PetName { get; set; }
    //     public Shape(string name = "noname")
    //     { PetName = name; }

    //     public virtual void Draw()
    //     {
    //         System.Console.WriteLine("Inside Shape.Draw()");
    //     }
    // }

    // class Circle: Shape
    // {
    //     public Circle(){}
    //     public Circle(string name)
    //     : base(name){}
    // }

    // class Hexagon: Shape
    // {
    //     public Hexage(){}
    //     public Hexagon(string name): base(name){}
    //     public override void Draw()
    //     {
    //         System.Console.WriteLine($"Drawing {PetName} the Hexagon");
    //     }

    // }
    abstract class Shape    // version 1
    {
        public string PetName { get; set; }
        public Shape(string name = "noname")
        { PetName = name; }

        public abstract void Draw();
    }

    class Circle: Shape
    {
        public Circle(){}
        public Circle(string name)
        : base(name){}
    }

    class Hexagon: Shape
    {
        public Hexage(){}
        public Hexagon(string name): base(name){}
        public override void Draw()
        {
            System.Console.WriteLine($"Drawing {PetName} the Hexagon");
        }

    }

    class ThreeDCircle
    {
        public void Draw()
        { System.Console.WriteLine("Drawing a 3D circle"); }
    }

    class ThreeDCircle: Circle
    {
        public new string PetName { get; set; }
        public new void Draw()
        { System.Console.WriteLine("Drawing a 3D circle"); }
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
                    - virtual methods have declaration only, defnition is set to =0;
                    - can't initialized and create obj
                    - methods marked with abstract are pure protocol

                    + c# uniqueness
                        - derived classes are NEVER required to override virtual methods
                        - to force each derived classes to override using abstract kw to define methods
                        - if derived classes are not override abstract methods, they are noncreatable abstract type that MUST be adorned with the abstract kw

                    + shared
                        - abstract members do not provide any implementation like c++
                        - abstract methods can only be defined in abc (both true in c++ and c#)

                + Base or Interface
                    - Top-down design and creation, what u see is inheritance and polymorphism
                    - after creation, what u see is derived classes share Interface


                */
                FuckWithPolymorphism();
            }

            // member shadowing, P297
            {
                /*

                + mechnism
                    - same with c++

                    - c# uniqueness:
                        - using new kw to hide any implementation above
                        - can apply new kw to any member type inherited



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

        static void FuckWithPolymorphism()
        {
            Hexagon hex = new Hexagon("ZL");
            hex.Draw();

            Circle cir = new Circle("XY");
            cir.Draw();
            System.Console.ReadLine();
        }

        static void FuckWith3DCircle()
        {
            ThreeDCircle o = new ThreeDCircle();
            o.Draw();

            ((Circle)o).Draw(); // upcasting
            System.Console.ReadLine();
        }
    }
}
