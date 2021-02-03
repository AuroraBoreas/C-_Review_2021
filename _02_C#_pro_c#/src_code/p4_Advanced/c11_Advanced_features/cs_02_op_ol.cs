using System;


namespace OP_OL
{
    class Point: IComparable<Point> 
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Point(){}
        public Point(int x, int y)
        { X = x; Y = y; }

        public override string ToString()
        => $"[{X}, {Y}]";

        public override int GetHashCode()
        => this.ToString().GetHashCode();

        public static bool operator==(Point p1, Point p2)
        => p1.ToString() == p2.ToString();

        public static bool operator!=(Point p1, Point p2)
        => p1.ToString() != p2.ToString();

        public int IComparable<Point>.CompareTo(Point other)
        {
            if(this.X > other.X && this.Y > other.Y)
                return 1;
            else if(this.X < other.X && this.Y < other.Y)
                return -1;
            else
                return 0;
        }

        public static bool operator<(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator<=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
        public static bool operator>(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator>=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;

        public static Point operator+(Point p1, Point p2)
        => new Point(p1.X + p2.X, p2.X + p2.Y);
        public static Point operator-(Point p1, Point p2)
        => new Point(p1.X - p2.X, p2.X - p2.Y);       
    }

    class Program
    {
        static int Main(string[] args)
        {
            // OP OL
            {
                /*
                
                + overloadability of C# ops
                    +, -, ~, ++, --, true, false;       // unary op
                    +, -, *, /, %, &, |, ^, <<, >>;     // binary op
                    ==, !=, <, >, <=, >=;               // logic op
                    []                                  // NOT allowed in C#
                    ()                                  // NOT allowed in C#
                    +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=;   // NOT allowed, but feebie when implatemented binary op in C#
                
                */ 
                
                // see class Point
            }

            // overloading Equality op
            {
                // see class Point
            }

            // overloading comparison op
            {
                /*
                
                + note
                    - using IComparable<T> interface template works great too;
                
                */
                // see class Point
            }

            return 0;
        }

        
    }
}