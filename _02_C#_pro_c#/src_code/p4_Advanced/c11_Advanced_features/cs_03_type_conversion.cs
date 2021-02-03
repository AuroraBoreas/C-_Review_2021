using System;

namespace TypeConversion
{
    // struct Rectangle    // version 0
    // {
    //     public int Width { get; set; }
    //     public int Height { get; set; }

    //     public Rectangle(int w, int h): this()
    //     { Width = w; Height = h; }

    //     public void Draw()
    //     {
    //         for(int i=0; i<Height; ++i)
    //         {
    //             for(int j=0; j<Width; ++j)
    //             {
    //                 System.Console.WriteLine("*");
    //             }
    //             System.Console.WriteLine();
    //         }
    //     }

    //     public override string ToString()
    //     => $"[Width = {Width}; Height = {Height}]";
    // }

    struct Rectangle    // version 1
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h): this()
        { Width = w; Height = h; }

        public void Draw()
        {
            for(int i=0; i<Height; ++i)
            {
                for(int j=0; j<Width; ++j)
                {
                    System.Console.WriteLine("*");
                }
                System.Console.WriteLine();
            }
        }

        public override string ToString()
        => $"[Width = {Width}; Height = {Height}]";

        public static implicit operator Rectangle(Square s)
        {
            Rectangle r = new Rectangle(w=s.Length * 2, h=s.Length);
            return r;
        }
    }

    struct Square
    {
        public int Length { get; set; }
        public Square(int l): this()
        => Length = l;

        public void Draw()
        {
            for(int i=0; i<Height; ++i)
            {
                for(int j=0; j<Width; ++j)
                {
                    System.Console.WriteLine("*");
                }
                System.Console.WriteLine();
            }
        }

        public override string ToString()
        => $"[Width = {Width}; Height = {Height}]";
        

        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square{Length = r.Height};
            return s;
        }
        
    }


    class Program
    {
        static int Main(string[] args)
        {
            // custom type conversion routines, P473
            {
                /*
                
                + why are constructors in both struct Rectangle and Square, explicitly chaining to the default constructor???
                    (P475)
                    >> the reason is that 
                    - if u have a STRUCT, which makes use of Automatic property syntax;
                    - the default constructor MUST be explicitly called from ALL custom constructors to initialize the private backing fields;

                    >> yes, it is quirky rule in C#

                + "implicit", "explicit" kw
                    - c# provide them for u to control type conversion;
                    - similar mechanism with C++>11;

                + overload patter
                    
                    ```c#

                    static explicit operator T(U arg)
                    { ...; }

                    ```

                */ 
                FuckWithConversions_explicit();

            }

            // implicit type conversions
            {
                /*
                
                + pattern:
                    - "implicit" kw makes copy assignment operator syntax works in C#;
                    `U b; T a = b;` 
                    
                    - "explicit" kw makes C-style syntax works in C#;
                    `U b; T a = (T)b;

                */ 
                FuckWithConversions_implicit();

            }

            return 0;
        }

        static void FuckWithConversions_explicit()
        {
            System.Console.WriteLine("=> fun with explicit conversions:");

            Rectangle r = new Rectangle(15, 4);
            System.Console.WriteLine(r.ToString());
            r.Draw();

            System.Console.WriteLine();

            // type conversion: Rectangle -> Square
            Square s = (Square)r;
            System.Console.WriteLine(s.ToString());
            s.Draw();
            Console.ReadLine();
            
        }

        static void FuckWithConversions_implicit()
        {
            System.Console.WriteLine("=> fun with implicit type conversinos:");

            Square s3 = new Square{Length = 7};
            Rectangle rect2 = s3;   // implicit type conversion from Square to Rectangle;
            
            System.Console.WriteLine("rect2 = {0}", rect2);
            
            // explicit cast syntax still OK!
            Square s4 = new Square{Length = 3};
            Rectangle rect3 = (Rectangle)s4;

            System.Console.WriteLine("rect3 = {0}", rect3);
            Console.ReadLine();
        }

        
    }
}