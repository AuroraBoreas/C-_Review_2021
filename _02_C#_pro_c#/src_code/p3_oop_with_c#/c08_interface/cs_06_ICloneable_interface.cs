using System;

namespace Return_Interface
{

    // class Point // version 0
    // {
    //     public int X { get; set; }
    //     public int Y { get; set; }

    //     public Point() {}
    //     public Point(int x, int y)
    //     { X = x; Y = y; }

    //     public override string ToString()
    //     { return $"X = {X}, Y = {Y}"; }
    // }

    // class Point: ICloneable // version 1
    // {
    //     public int X { get; set; }
    //     public int Y { get; set; }

    //     public Point() {}
    //     public Point(int x, int y)
    //     { X = x; Y = y; }

    //     public override string ToString()
    //     { return $"X = {X}, Y = {Y}"; }

    //     public object Clone() => new Point(this.X, this.Y);
    // }

    // class Point: ICloneable // version 2
    // {
    //     public int X { get; set; }
    //     public int Y { get; set; }
    //     public PointDescription desc = new PointDescription();

    //     public Point() {}
    //     public Point(int x, int y)
    //     : this(x, y, "noname")
    //     {}
    //     public Point(int x, int y, string n)
    //     { X = x; Y = y; desc.Name = n; }

    //     public override string ToString()
    //     { return $"X = {X}, Y = {Y}, Name = {desc.Name}, ID = {desc.PointID}"; }

    //     public object Clone() => this.MemberwiseClone();    // shallow copy
    // }

    class Point: ICloneable // version 3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();

        public Point() {}
        public Point(int x, int y)
        : this(x, y, "noname")
        {}
        public Point(int x, int y, string n)
        { X = x; Y = y; desc.Name = n; }

        public override string ToString()
        { return $"X = {X}, Y = {Y}, Name = {desc.Name}, ID = {desc.PointID}"; }

        public object Clone()
        {
            // first get a shallow copy
            Point newPoint = (Point)this.MemberwiseClone();
            // then fill in the gaps
            PointDescription currentDesc = new PointDescription(); // generate a new string name; and a new GUID;
            currentDesc.Name = this.desc.Name;
            newPoint.desc = currentDesc;
            return newPoint;
        }
    }

    class PointDescription  // version 0
    {
        public string Name { get; set; }
        public Guid PointID { get; set; }

        public PointDescription()
        {
            Name = "noname";
            PointID = Guid.NewGuid();
        }
        
    }


    class Program
    {
        static int Main(string[] args)
        {
            // ICloneable interface, P367
            {
                /*
                
                + shallow copy
                    - System.Object.MemberwiseClone();

                + deep copy
                    - member by member copy in c++ by yourself
                    - System.ICloneable in c#

                    ```c#

                    namespace System
                    {
                        public interface ICloneable
                        {
                            object Clone();
                        }
                    }
                    
                    ```

                
                */ 
                FuckWithObjectCloning();
                FuckWithObjectCloning_ICloneable();
            }

            // a more elaborate cloning example, P369
            {
                
                FuckWithObjectCloning_ICloneable_Description();
            }

            return 0;
        }

        static void FuckWithObjectCloning()
        {
            System.Console.WriteLine("=> Fuck with object cloning:");

            Point p1 = new Point(50, 50);
            Point p2 = p1; // shallow copy; why: string/object/dynamic are reference type in C# by default; class/interface/delegate/record kw
            p2.X = 0;

            System.Console.WriteLine(p1);
            System.Console.WriteLine(p2);

            Console.ReadLine();
        }
        static void FuckWithObjectCloning_ICloneable()
        {
            System.Console.WriteLine("=> Fuck with object cloning:");
            // notice Clone returns a plain System.Object
            // u MUST perform an explicit cast to obtain the derived type
            Point p3 = new Point(100, 100);
            Point p4 = (Point)p3.Clone(); // deep copy
            p4.X = 0;

            System.Console.WriteLine(p3);
            System.Console.WriteLine(p4);

            Console.ReadLine();
        }
        static void FuckWithObjectCloning_ICloneable_Description()
        {
            System.Console.WriteLine("=> Fuck with object cloning:");
            // notice Clone returns a plain System.Object
            // u MUST perform an explicit cast to obtain the derived type
            Point p3 = new Point(100, 100, "ZL");
            Point p4 = (Point)p3.Clone(); // shallow copy
            p4.X = 0;

            System.Console.WriteLine("Before modification:");
            System.Console.WriteLine("p3: {0}",p3);
            System.Console.WriteLine("p4: {0}",p4);
            p4.desc.Name = "My New Point";
            p4.X = 9;

            System.Console.WriteLine("\nChanged p4.desc.Name and p4.X");
            System.Console.WriteLine("After modification:");
            System.Console.WriteLine("p3: {0}",p3);
            System.Console.WriteLine("p4: {0}",p4);

            Console.ReadLine();
        }
        
    }
}