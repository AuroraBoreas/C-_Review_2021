using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Reflection;

using CarLibrary;

namespace review
{
    public enum Colors
    {
        red, blue, green, yellow, pink
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Print()
        {
            Console.WriteLine("[{0}, {1}]", X, Y);
        }
    }

    public delegate int FuncName(int x, int y); // declare a delegate type(function pattern/signatures)

    class Program
    {
        static void Main(string[] args)
        {
            MyVariable();
            Console.WriteLine();

            MyStrings();
            Console.WriteLine();

            MyFunctions();
            Console.WriteLine();

            MyControlFlow();
            Console.WriteLine();

            MyClass();
            Console.WriteLine();

            MyCollections();
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void MyVariable()
        {
            /*
             [source, data types]
             -----
             System.Object;
                - ValueType (stack)
                    -- C S I L, F D, B B D,
                    -- enum, struct
                - RefereceType (heap)
                    -- string
                    -- class
                    -- delegate
                    -- multidelegate
                    -- record
                    -- dynamic

            keywords;
                - T var_name;   // can initialize later; or compiler will default it;
                - var var_name = must_initialized when declaration;
                - dynamic var_name;
                
             -----

             
             */


            // ValueType
            checked
            {
                char c = 'a';
                short s = 255;
                int i = 100;
                long l = 12434L;

                float f = 3.14f;
                double d = 1.9999999999999999;

                byte b = 12;
                Boolean bl = false;
                decimal de = 2.718m;

                Console.WriteLine(c.ToString());
                Console.WriteLine("{0:2C}", s); // currency
                Console.WriteLine("{0:D}", i);
                Console.WriteLine("{0:E}", l);
                Console.WriteLine("{0:2F}", f);
                Console.WriteLine("{0:3F}", d);
                Console.WriteLine(b);
                Console.WriteLine(bl);
                Console.WriteLine(de);
            }

            // enum
            Console.WriteLine(Colors.red);

            // struct
            Point x = new Point(3, 4);
            Console.WriteLine(x.ToString());

            // type trait(reflection)
            

        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Sub(int x, int y)
        { return x - y;  }

        private static int Mul(int x, int y)
        { return x * y; }
        private static int Fibonacci(int n)
        {
            return (n < 2) ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        private static int Factorial(int n)
        {
            return (n < 2) ? 1 : n * Factorial(n - 1);
        }

        // tuple as return value
        private static (int, int) TupleAsReturnValue()
        {
            return (3, 4);
        }

        // passing value as args
        private static void AddOne(int x)
        {  x++;  }
        // passing reference as args
        private static void AddOne(ref int x)
        { x++; }
        // params
        private static int MySum(params int[] args)
        {
            int res = 0;
            for (int i = 0; i < args.Length; ++i)
                res += args[i];

            return res;
        }
        static void MyFunctions()
        {
            /*
            
            [source, function]
            ----

            * regular function, postion args, keyword args;
            * overloading; note: function signatures in C#;
            * using Tuple as return type;
            * params
            * val or ref as args; note: reference in C#
            * delegate type: generic; like function template in C++;
            * Func<>
            * Action<>
            * Predict<>; == Funct<, Boolean>
            * anonymouse function
            * lambda expr
            
            ----
             
            */
            // regular
            Console.WriteLine("Add function: {0}", Add(3, 4));  // 7
            Console.WriteLine("fibonacci: {0}", Fibonacci(4));  // 5
            Console.WriteLine("factorial: {0}", Factorial(5));  // 120
            // tuple as return value
            Console.WriteLine(TupleAsReturnValue().Item1);
            // passing as val or ref
            int x = 42;
            AddOne(x);
            Console.WriteLine(x);   // 42
            AddOne(ref x);
            Console.WriteLine(x);   // 43;
            // params
            int[] arr = { 1, 2, 3, 4 };
            Console.WriteLine(MySum(arr));  // 10

            // delegate
            FuncName f = new FuncName(Add);
            //f += Sub;
            //f += Mul;
            Console.WriteLine(f(3, 4));

            // generic function
            Console.WriteLine("\nFunc<>:");
            Func<int, int> g = new Func<int, int>(Factorial);
            g += Fibonacci;
            Console.WriteLine(g(6));    // 720, 
        }

        static void MyStrings()
        {
            string txt = "hello world!";
            // length
            Console.WriteLine(txt.Length);
            // index
            Console.WriteLine(txt[0]);
            // contains
            Console.WriteLine(txt.Contains("hello"));
            // substring
            Console.WriteLine(txt.Substring(5, 2));
            // concat
            Console.WriteLine(txt + " ZL");
            // replace
            Console.WriteLine(txt.Replace('o','a'));
            // interpolation
            string s = String.Format($"{txt}, {txt}");
            Console.WriteLine(s);
            // String.builder
            StringBuilder sb = new StringBuilder();
            sb.Append(txt);
            sb.Append("ZL");
            sb.Append("French");
            sb.Append("LL");
            Console.WriteLine(sb.ToString());                       
        }

        static void MyStatement()
        {
            int x = 4;
            int y = 10;
            int res = x * y - x * y;

            Console.WriteLine(res);
        }

        static void MyControlFlow()
        {
            /*
            
            [source, controlflow]
            ----
            * ifelse
            * switchcase
            * trycatch            
            ----

             
            */

            // if...else if...else
            var x = 42;

            if(x < 10)
            {
                Console.WriteLine("x < 10");
            }
            else if(x >= 10 && x < 20)
            {
                Console.WriteLine("x >= 10 && x < 20");
            }
            else if(x >=20 && x < 30)
            {
                Console.WriteLine("x >=20 && x < 30");
            }
            else if(x >= 30 && x < 40)
            {
                Console.WriteLine("x >= 30 && x < 40");
            }
            else
            {
                Console.WriteLine("x>=40");
            }

            // switch case
            var color = Colors.red;
            switch(color)
            {
                case Colors.red:
                    Console.WriteLine("red");
                    break;
                case Colors.blue:
                    Console.WriteLine("blue");
                    break;
                case Colors.green:
                    Console.WriteLine("green");
                    break;
                case Colors.yellow:
                    Console.WriteLine("yellow");
                    break;
                case Colors.pink:
                    Console.WriteLine("pink");
                    break;
                default:
                    Console.WriteLine("I dont know");
                    break;
            }

            // try...catch...finally;
            var a = 10; var b = 0;
            dynamic res;
            try
            {
                res = a / b;
                Console.WriteLine(res);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                res = "Infinity";
                Console.WriteLine(res);
            }
        }

        private static void DisplayMessage(object sender, EngineEventArgs e)
        {
            Console.WriteLine(e.Info);
        }
        
        static void MyClass()
        {
            /*
            
            [source, class]
            ----

            * A E I P; 
            * S O L I D;
            
            + keywords:
                - A
                    -- abstract, override, virtual, new
                - E
                    -- private, public, protect, internal
                    -- sealed
                - I
                    -- new
                - P
                    -- virtual, override
            ----
             
            */
            Car myCar = new Car("ZL", 20, 100, "red");
            myCar.EngineEvent += DisplayMessage;

            for(int i=0; i<10; ++i)
            {
                myCar.Accelerate(15);
            }
        }

        static void MyCollections()
        {
            // Array
            Console.WriteLine("\nArray:");
            Car[] myCars = new Car[4]
            {
                new Car("ZL", 20, 110, "red"),
                new Car("LL", 30, 120, "blue"),
                new Car("ZZ", 40, 150, "green"),
                new Car("MM", 10, 200, "yellow"),
            };
            // LINQ
            var res =
                from car in myCars
                where car.MaxSpeed > 100 && car.Color.Length > 4
                orderby car.CurrentSpeed
                select car;

            foreach(Car r in res)
            {
                Console.WriteLine(r.ToString());
            }


            // List
            Console.WriteLine("\nList:");
            List<Car> myListCars = new List<Car>
            {
                new Car("ZL", 20, 100, "red"),
                new Car("LL", 30, 120, "blue"),
                new Car("ZZ", 40, 150, "green"),
                new Car("MM", 10, 200, "yelllow"),
            };
            Console.WriteLine(myListCars.Count);    // 4

            // Dictionary
            Console.WriteLine("\nDict:");
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            myDict.Add(1, "hello");
            myDict.Add(2, "world");
            myDict.Add(3, "ZL");
            myDict.Add(4, "number1");
            Console.WriteLine(myDict[1]);   // hello


            // Set
            HashSet<int> mySet1 = new HashSet<int>();   // 1, 2, 3, 4, 5
            HashSet<int> mySet2 = new HashSet<int>();   // 4, 5, 6, 7, 8

            for (int i=1; i<6; ++i)
            {
                mySet1.Add(i);
                mySet2.Add(i + 3);
            }

            // union
            Console.WriteLine("\nSet:");
            HashSet<int> tmp = new HashSet<int>(mySet1);
            mySet1.UnionWith(mySet2);
            Console.WriteLine(mySet1.Count);    // 1,2,3,4,5,6,7,8
            foreach(int i in mySet1)
            {
                Console.Write(i.ToString(), '\t');
            }
            Console.WriteLine();

        }


    }
}