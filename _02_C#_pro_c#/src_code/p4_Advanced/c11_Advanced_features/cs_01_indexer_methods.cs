using System;
using System.Collections.Generic;

namespace Indexer_Methods
{

    class Point
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

        public static Point operator+(Point p1, Point p2)
        => new Point(p1.X + p2.X, p2.X + p2.Y);
        public static Point operator-(Point p1, Point p2)
        => new Point(p1.X - p2.X, p2.X - p2.Y);       
    }

    class PointCollection: IEnumerable
    {
        private Point[] arrPoints = new Point[];

        public Point this[int index]
        {
            get => (Point)arrpoint[index];
            set => arrPoints[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        => arrPoints.GetEnumerator();
    }

    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; } = 0;

        public Person(){}
        public Person(string fn, string ln, int a)
        { FirstName = fn; LastName = ln; Age = a; }

        public override string ToString()
        => $"Name: {FirstName} {LastName}, Age: {Age}";
        
    }

    class PersonCollection: IEnumerable
    {
        private Dictionary<string, Person> dictPersons = new Dictionary<string, Person>();
        
        public Person this[string name]
        {
            get => (Person)dictPersons[name];
            set => dictPersons[name] = value;
        }

        public void Clear()
        => dictPersons.Clear();

        public int Count()
        => dictPersons.Count;

        // implemenation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        => dictPersons.GetEnumerator();
    }

    class SomeContainer
    {
        private int[,] my2DIntArray = new int[10, 10];
        public int this[int i, int j]
        {
            get => my2DIntArray[i, j];   
            set => my2DIntArray[i, j] = value;
        }

    }

    interface IStringContainer
    {
        string this[int index] { get; set; }
    }

    class SomeClass: IStringContainer
    {
        private List<string> myStrings = new List<string>();
        public string this[int index]
        {
            get => myStrings[index];
            set => myStrings.Insert(index, value);
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // index methods (subscript op[] overload in C++), P460
            {
                /*
                
                + why
                    - C# can NOT overload subscript op [], use indexer methods to achieve same effect

                */ 
                // see class PointCollection, numeric index
                // see class PersonCollection, string index
                FuckWithIndexerMethods();
            }

            // indexer with multidimensions
            {
                // see class SomeContainer
            }

            // indexer definitions on iterface type
            {

                // see IStringConstainer, class SomeContainer
            }

            return 0;
        }

        static void FuckWithIndexerMethods()
        {
            System.Console.WriteLine("=> fun with indexer methods:");

            PersonCollection pc = new PersonCollection();
            pc["ZL"] = new Person("Zhang", "Liang", 30);
            pc["XY"] = new Person("Xiao", "Ying", 30);
            
            Person ZL = pc["ZL"];
            System.Console.WriteLine(p.ToString());

            Console.ReadLine();
        }

        
    }
}