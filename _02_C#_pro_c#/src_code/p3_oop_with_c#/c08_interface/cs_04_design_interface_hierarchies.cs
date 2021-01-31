using System;

namespace Return_Interface
{
    interface IDrawable
    {
        void Draw();
    }

    public interface IAdvancedDraw: IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    class BitMapImage: IAdvancedDraw
    {
        // every member defined up the chain of inheritance MUST be implemented
        public void Draw()  // implicit
        {
            System.Console.WriteLine("Drawing...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            System.Console.WriteLine("Drawing in box...");

        }

        public void DrawUpsideDown()
        {
            System.Console.WriteLine("Drawing upside down!");

        }
    }


    interface IPrintable
    {
        void Print();
        void Draw();    // <-- note possible name clash here
    }

    interface IShape: IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }

    // at this point, if u have a class supporting IShape, how many methods will it be required to implement?
    // my answer: 3 (implicit); 4 (explicit)
    // pro answer: it depends

    class Rectangle0: IShape // implicit, 3 methods implemented
    {
        public int GetNumberOfSides() => 4;

        public void Draw() => System.Console.WriteLine("Drawing...");

        public void Print() => System.Console.WriteLine("Printing...");
    }

    class Rectangle1: IShape // explicit, 4 methods implemented
    {
        public int GetNumberOfSides() => 4;

        void IDrawable.Draw() => System.Console.WriteLine("IDrawable Drawing...");
        void IShape.Draw() => System.Console.WriteLine("IShape Drawing...");

        public void Print() => System.Console.WriteLine("Printing...");
    }



    class Program
    {
        static int Main(string[] args)
        {
            // interface hierarchies
            {
                /*
                
                + why: extend codebase without breaking anything
                
                */ 

            }

            // MI with interface type
            {
                /*
                
                + summary: interface can be extremely useful in the following cases
                    - u have a single hierarchy where only a subset of the derived types supports a common behavior;
                    - u need to model a common behavior that is found across multiple hierarchies with no common parent class beyond System.Object;
                
                */

            }

            return 0;
        }

        static void SimpleInterfaceHierarchy()
        {
            System.Console.WriteLine("=> simple interface hierarchy:");

            // call from obj-lvl;
            BitMapImage myBitMap = new BitMapImage();
            myBitMap.Draw();
            myBitMap.DrawInBoundingBox();
            myBitMap.DrawUpsideDown();

            // call IAdvancedDraw explicitly
            IAdvancedDraw iAvDraw = myBitMap as IAdvancedDraw;
            if(iAvDraw != null)
                iAvDraw.DrawUpsideDown();
            
            Console.ReadLine();
        }

        
    }
}