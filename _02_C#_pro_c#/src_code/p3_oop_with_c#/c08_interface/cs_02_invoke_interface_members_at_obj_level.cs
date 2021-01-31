using System;

namespace Invoke_Interface_Members
{

    abstract class Shape
    {
        public void Draw();
        public abstract int GetNumberOfPoints();
    }

    interface IPoint
    {
        byte Points { get; }
    }

    class Circle: Shape, IPoint
    {
        // ...;
    }

    class Hexagon: Shape, IPoint
    {
        // ...;
    }

    class Triangle: Shape, IPoint
    {
        // ...;
    }
    class Program
    {

        static int Main(string[] args)
        {
            // invoking interface member at obj-lvl, P347
            {
                /*
                
                + background in questions
                    - supposed u have an array with element of 50 shapes objects;
                    - some shapes support IPoint interface;
                    - some shapes do NOT support;

                    >> question: how do u determine which supports IPoint interface for each element?

                + solution(ofc, same with class type casting)
                    - 1, determine at runtime by explicit casting; using try...catch(InvalidCastException)...
                    - 2, using as to obtain interface reference; syntax: `T ivar = var as T;`
                    - 3, using is to check obj; syntax: `var is T T_var;`

                
                
                */ 
                DetermineWhetherImplementInterface();
                DetermineWhetherImplementInterface_as();
                DetermineWhetherImplementInterface_is();

            }


            return 0;
        }

        static void DetermineWhetherImplementInterface()
        {
            Circle c = new Circle("XY");

            IPoint ip = null;
            try
            {
                ip = (IPoint)c;
                System.Console.WriteLine(ip.Points);
            }
            catch(InvalidCastException e)
            {
                System.Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            
        }
        static void DetermineWhetherImplementInterface_as()
        {
            Hexagon hex = new Hexagon("ZL");
            IPoint ip  = hex as IPoint;
            if(ip != null)
                System.Console.WriteLine("Points: {0}", ip.Points);
            else
                System.Console.WriteLine("oops! NOT pointy...");
                
            Console.ReadLine();
        }
        static void DetermineWhetherImplementInterface_is()
        {
            System.Console.WriteLine("=> fun with interfaces:");   

            // make an array of shapes
            Shape[] myShapes = 
            {
                new Hexagon(),
                new Circle(),
                new Triangle("Joe"),
                new Circle("JOJO"),
            };

            for(int i=0; i<myShapes.Length; ++i)
            {
                myShapes[i].Draw();

                // who is IPoint?
                if(myShapes[i] is IPoint ip)
                    System.Console.WriteLine("-> Points: {0}", ip.Points);
                else
                    System.Console.WriteLine("-> {0}\'s not pointy", myShapes[i].PetName);
                
                System.Console.WriteLine();
                Console.ReadLine();
                
            }
        }


    }
}