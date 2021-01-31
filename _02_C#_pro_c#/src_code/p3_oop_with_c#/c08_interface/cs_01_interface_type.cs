using System;
using System.Data;

namespace Interface_Type
{
    // abstract class CloneableType    // version 0
    // {
    //     public abstract object Clone();
    // }

    abstract class Shape
    {
        public abstract byte GetNumberOfPoins();
    }
    interface CloneableType    // version 1
    {
        public abstract object Clone();
    }

    abstract class Car
    {}

    class MiniVan: Car, CloneableType   // nope, C# class does not support MI
    {

    }

    interface IPoint
    {
        byte Points{get;}
    }

    class Pencile: IPoint
    {
        // ...;
    }

    class SwitchBlade: Object, IPoint
    {
        // ...;
    }

    class Utensil{}
    class Fork: Utensil, IPoint
    {
        // ...;
    }
    struct PitchFork: ICloneable, IPoint
    {
        // ...;
    }

    class Triangle: Shape, IPoint
    {
        public Triangle(){}
        public Triangle(string name): base(name){}
        public override void Draw()
        {
            // ...;
        }

        // IPoint implementation
        public byte Points
        {
            get => 3;
        }

    }


    class Program
    {

        static int Main(string[] args)
        {

            // interface
            {
                /*
                
                + concept
                    - inheritance chain(top-down), what we see is inheritance and polymorphism;
                    - inheritance chain(bottom-up), what we see is interface; all derived classes share the same protocol, which is interface;
                
                + formal definition
                    - an interface is nothing more than a named set of abstract members;
                
                */ 

            }
            
            // interfce vs abc, P340
            {
                /*

                ref link: https://www.c-sharpcorner.com/article/abstract-class-vs-interface-c-sharp/
                
                table: interface vs abc
                
                | abc                                                   | interface                     |
                |-------------------------------------------------------|-------------------------------|
                | ctors;                                                | N/A                           |
                | data members;                                         | N/A                           |
                | props;                                                | props;                        |
                | static props;                                         | N/A                           |
                | non-abstract methods(mayby with implementations);     | N/A                           |
                | abstract methods;                                     | YES                           |
                | access modifiers;                                     | N/A                           |
                | default access modifier: private;                     | public;                       |
                | inherit from another abc or interface? : Both;        | interface only;               |
                | concept: not full abstraction;                        | full abstraction;             |
                | Multiple Interface?: N/A;                             | YES;                          |
                |                                                       |                               |

                conclusion: interface is an abstraction above abc somehow; highly polymorphic;

                

                */ 
            }

            // implement an interface, P345
            {
                /*

                + note
                    - when a class(or struct) extends its functionality by supporting interfaces, it does so using a comma-delimited list in definition;
                      remember the direct base class MUST be the first item listed after the colon operator;

                    - implementing an interface is an all-or-nothing proposition;

                */ 

            }

            //
            {

            }


            return 0;
        }

        private static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            System.Console.WriteLine("your clone is a: {0}", theClone.GetType().Name);
        }
        static void FirstLookAtInterface()
        {
            System.Console.WriteLine("=> first look at interface");

            string myStr = "hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.Sqlclient.SqlConnection sqlCnn = new System.Data.SqlConnection();

            // seemingly unrelated types
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);

            Console.ReadLine();
            
        }

        static void FuckWithInterface()
        {
            IPoint p = new IPoint();    // not OK, compile error;
        }
    }
}