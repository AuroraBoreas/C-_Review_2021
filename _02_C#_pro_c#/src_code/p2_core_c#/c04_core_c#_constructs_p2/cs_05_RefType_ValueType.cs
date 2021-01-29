using System;


namespace RefType_ValueType
{
    class Program
    {
        struct Point
        {
            private int m_x;
            private int m_y;
            // constructor
            public Point(int x, int y)
            { m_x = x; m_y = y; }
            // getter, setter
            public int X { get; set; }
            public int Y { get; set; }
            
            
            public void Increment()
            { m_x++; m_y++; }
            public void Decrement()
            { m_x--; m_y--; }
            public void Display()
            {   System.Console.WriteLine($"x = {m_x}, y = {m_y}"); }
        }

        class PointRef
        {
            private int m_x;
            private int m_y;
            // constructor
            public PointRef(int x, int y)
            { m_x = x; m_y = y; }

            public int X { get; set; }
            public int Y { get; set; }
            public void Increment()
            { m_x++; m_y++; }
            public void Decrement()
            { m_x--; m_y--; }
            public void Display()
            { System.Console.WriteLine($"x = {m_x}, y = {m_y}"); }
        }

        class ShapeInfo
        {
            public string m_info;
            public ShapeInfo(string info)
            { m_info = info; }
        }

        struct Rectangle
        {
            public ShapeInfo rectInfo;
            public int RectTop, RectLeft, RectBottom, RectRight;

            public Rectangle(string info, int top, int left, int bottom, int right)
            {
                rectInfo = new ShapeInfo(info);
                RectTop = top;
                RectLeft = left;
                RectBottom = bottom;
                RectRight = right;
            }

            public void Dispaly()
            {
                System.Console.WriteLine($"String = {rectInfo.m_info}, Top = {RectTop}, Bottom = {RectBottom}, Left = {RectLeft}, Right = {RectRight} ");
            }
        }

        class Person
        {
            public string m_name;
            public int m_age;
            public Person(){} // default constructor
            public Person(string name, int age)
            {
                m_name = name;
                m_age = age;
            }

            // repr
            public void Dispaly()
            {
                System.Console.WriteLine($"name: {m_name}, age: {m_age}");
            }
        }
        public static int Main(string[] args)
        {
            // Sytem.Object vs System.ValueType
            {
                /*
                
                + difference:
                    functionally, the only purpose of System.ValueType is to override the virtual methods defined by System.Object
                    to use value-based vs reference-based semantics

                + note:
                    in fact, the instance methods defined by System.ValueType are identical to those of System.Object
                
                
                + definition in System: struct and enum implicitly extend System.ValueType

                    ```c#       
                    public abstract class ValueType: Object
                    {
                        public virtual bool Equals(object obj);
                        public virtual int GetHashCode();
                        public Type GetType();
                        public virtual string ToString();
                    }
                    ```

                + appendix:
                    - new keyword is same with new in C++. it creates an obj allocated in heap, then return the memory address of the obj
                    - it means, pointer notation is hidden
                    - but the var pointer to new obj behaves like a pointer somehow, especially when passing it to function as args
                    - access operator is limited to symbol(.) 
                    - works like black magic in C# 
                        
                        ```c#
                            Point p1 = new Pointer(2, 3);

                        ```
                */ 

                ValueTypeAssignment_struct();

                Console.ReadLine();

            }

            // struct vs class, P144
            {
                /*
                + classes in C# are always reference types
                    - this is C# uniqueness...
                    - class and struct have no such difference in C/C++,
                      except u assign it by ref explicitly to achieve this ability
                    - how:
                        - using ref
                        MyClass a = MyClass();
                        MyClass& b = a;

                        - using pointer
                        MyClass* a = new MyClass();
                        MyClass* b = a;

                        - using shared_ptr
                        MyClass* a = new MyClass(&x, &y);
                        std::shared_ptr<MyClass> b(a);
                
                + but is class the only reference type in C#? any other exists?
                    answer: YES. link: [MSDN C# reference type]

                    the following keywords are used to define reference type
                    - class
                    - interface
                    - delegate
                    - record

                    also, built-in reference types as follows
                    - dynamic
                    - object
                    - string
                
                */ 
                ValueTypeAssignment_class();

                Console.ReadLine();

            }

            // value type containing reference type, P207
            {
                /*
                (P206)
                What is not possible is to reassign what the reference is pointing to.

                + note: to elaborate this behavior in C#
                    - passing reference types by value in C#, is alike passing pointer in C++
                    - passing reference types by reference in C#, is same with passing referece in C++
                
                */ 
                PassingPersonObjectByValue();
                PassingPersonObjectByRef();

                Console.ReadLine();

            }

            return 0;
        }
        
        static void ValueTypeAssignment_struct()
        {
            System.Console.WriteLine("Assigning value types:\n");

            Point p1 = new Point(10, 10);
            Point p2 = p1; // copy assignment operator

            p1.Display();
            p2.Display();

            p1.X = 100;
            System.Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();
        }

        static void ValueTypeAssignment_class()
        {
            System.Console.WriteLine("Assigning reference types:\n");

            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1; // copy assignment operator

            p1.Display();
            p2.Display();

            p1.X = 100;
            System.Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();

        }

        static void ValueTypeContainingRefType()
        {
            System.Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);

            System.Console.WriteLine("-> Assigning r1 to r2");
            Rectangle r2 = r1;

            System.Console.WriteLine("-> Changing values of r2");
            r2.rectInfo.m_info = "This is new info!";
            r2.RectBottom = 4444;

            r1.Dispaly(); // This is new info, others remain same
            r2.Dispaly();
        }

        private static void SendAPersonByValue(Person p)
        {
            p.m_age = 99;

            p = new Person("niki", 99); // new memory address, it becomes local var, lifespan is in this function scope
        }
        private static void SendAPersonByRef(ref Person p)
        {
            p.m_age = 555;
            p = new Person("niki", 999);
        }

        static void PassingPersonObjectByValue()
        {
            System.Console.WriteLine("=> passing person obj by value");

            Person fred = new Person("Fred", 12);
            System.Console.WriteLine("\nbefore by value call, Person is: ");
            fred.Dispaly();

            SendAPersonByValue(fred);
            System.Console.WriteLine("\nafter by value call, Person is: ");
            fred.Dispaly(); // Fred, 99

        }
        static void PassingPersonObjectByRef()
        {
            System.Console.WriteLine("=> passing person obj by ref");

            Person fred = new Person("Fred", 12);
            System.Console.WriteLine("\nbefore by ref call, Person is: ");
            fred.Dispaly();

            SendAPersonByValue(fred);
            System.Console.WriteLine("\nafter by ref call, Person is: ");
            fred.Dispaly(); // niki, 999
        }
    }
}