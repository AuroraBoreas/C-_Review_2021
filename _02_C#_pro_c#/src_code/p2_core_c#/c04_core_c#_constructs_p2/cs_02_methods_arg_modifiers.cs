using System;

namespace Methods_And_Modifiers
{
    class Program
    {
        public static void Main(string[] args)
        {
            // T N P
            {
                /*
                
                + C# uniqueness: expression-bodied members.
                    it shortens the syntax for single-line methods
                
                */

                int res = add(12, 42);
            }

            // args modifiers, P178
            {
                /*
                
                + mechanism is similar with C/C++

                + arg modifiers
                    - (None)        passing by value
                    - out           passing by Ref
                    - ref           passing by Ref
                    - params        paramarray in VB, variadic template in C/C++, *args in Python etc
                
                    - note: args with out modifier must be assigned to a valid value before exiting method scope
                    - note: if u don't arg with out modifer, then use _ (underscore) to ignore

                + named arguments: keyword args

                */

                FuckWithMethods_ByVal();

                // C# 7 allows for out args to be declared in the method call, P180
                FuckWithMethods_out();

                // return multiple out args
                int x; string y; bool z;
                FillTheseValues(out x, out y, out z);

                // note1: args with out modifier must be assigned to valid values before leaving method scope 
                ThisWontCompile(); // not OK

                // note2: ignore if u dont care
                string dt = "2021-2-31";
                if(DateTime.TryParse(dt, out _))
                {
                    // ...;
                }

                // ref modifier mechanism is same with ref& in C/C++
                FuckWithMethods_ref();

                // ref as return_value in C#
                SimpleReturnDemo();
                SimpleReturnDemo_ref();

                // params
                FuckWithMethods_params();

                // position args, keyword args, default args
                string s1 = "hello world";
                EnterLogData(s1);

                // named args (keyword args)
                DisplayFancyMessageDemo();
                
                // method overloading
                // skip

                // local functions, P191
                // C# 7 allows to create functions inside of a method
                {

                }

                Console.ReadLine();
                
            }

        }

        private static int add(int a, int b) // normal
        { return (a + b); }

        private static int add(int a, int b) => a + b; // one-step to lambda

        private static int add(int x, int y)
        {
            int ans = x + y;
            x = 10000;
            y = 88888;

            return ans;
        }
        
        private static void add(int x, int y, out int z)
        {
            z = x + y;
        }

        private static void FuckWithMethods_ByVal()
        {
            System.Console.WriteLine("***** Fuck With Methods *****");

            int a = 42,
                b = 36;
            
            System.Console.WriteLine($"Before call, a = {a}, b = {b}"); // 42, 36
            System.Console.WriteLine($"Answer is: {add(a, b)}");        // 78
            System.Console.WriteLine($"After call, a = {a}, b = {b}");  // 42, 36
        }

        private static void FuckWithMethods_out()
        {
            System.Console.WriteLine("***** Fuck With Methods *****");

            int a = 42,
                b = 36;

            System.Console.WriteLine($"Before call, a = {a}, b = {b}");              // 42, 36
            System.Console.WriteLine($"Answer is: {add(a, b, out int ans)}");        // 78
            System.Console.WriteLine($"After call, a = {a}, b = {b}");               // 42, 36
        }

        private static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 42;
            b = "hello world";
            c = true;
        }

        private static void ThisWontCompile(out int a)
        {
            System.Console.WriteLine("Error! forgot to assign output arg!");
        }

        private static void SwapStrings(ref string a, ref string b)
        {
            string tmp = b;
            b = a;
            a = tmp;            
        }

        private static void FuckWithMethods_ref()
        {
            System.Console.WriteLine("***** Fuck with methods: *****");

            string x = "hello",
                   y = "world";

            System.Console.WriteLine($"before swap, x = {x}, y = {y}");
            SwapStrings(ref x, ref y);
            System.Console.WriteLine($"after swap, x = {x}, y = {y}");

        }

        private static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        private static ref string SimpleReturn_ref(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        private static void SimpleReturnDemo()
        {
            string[] sArray = { "one", "two", "three" };
            int pos = 1;

            System.Console.WriteLine("=> use simple return:");
            System.Console.WriteLine($"before: {sArray[0]}, {sArray[1]}, {sArray[2]}");
            var output = SimpleReturn(sArray, pos);
            output = "new";
            System.Console.WriteLine($"after: {sArray[0]}, {sArray[1]}, {sArray[2]}");
        }
        private static void SimpleReturnDemo_ref()
        {
            string[] sArray = { "one", "two", "three" };
            int pos = 1;

            System.Console.WriteLine("=> use simple return:");
            System.Console.WriteLine($"before: {sArray[0]}, {sArray[1]}, {sArray[2]}");
            ref var output = ref SimpleReturn(sArray, pos);
            output = "new";
            System.Console.WriteLine($"after: {sArray[0]}, {sArray[1]}, {sArray[2]}");
        }

        private static double CaculateAverage(params double[] values)
        {
            double res = 0;
            if(values.Length > 0)
            {
                foreach(double value in values)
                {
                    res += value;
                }

                res = res / values.Length;
            }
            
            return res;
        }

        private static void FuckWithMethods_params()
        {
            System.Console.WriteLine("=> Fuck with Methods params:");

            double ave;
            ave = CaculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            System.Console.WriteLine($"average of data is: {ave}");

            // or pass an array of doubles
            double[] data = { 4.0, 3.2, 2.718 };
            ave = CaculateAverage(data);
            System.Console.WriteLine($"average of data is: {ave}");

            // or 0?
            System.Console.WriteLine($"average of data is: {CalculateAverage()}");
            System.Console.WriteLine();
        }

        private static void EnterLogData(string msg, string owner = "Programmer")
        {
            System.Console.Beep();
            System.Console.WriteLine($"Error: {msg}");
            System.Console.WriteLine($"Owner of Error: {owner}");
        }

        private static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string msg)
        {
            // store odd colors
            ConsoleColor oldTextColor = ConsoleColor.ForegroundColor;
            ConsoleColor oldBackgroundColor = ConsoleColor.BackgroundColor;
            
            // set new colors
            ConsoleColor.ForegroundColor = textColor;
            ConsoleColor.BackgroundColor = backgroundColor;
            System.Console.WriteLine(msg);

            // restore
            ConsoleColor.ForegroundColor = oldTextColor;
            ConsoleColor.BackgroundColor = oldBackgroundColor;

        }

        private static void DisplayFancyMessageDemo()
        {
            System.Console.WriteLine("***** fuck with methods by named args(or keyword args) *****");
            
            DisplayFancyMessage(msg: "wow, fancy af",
                                textColor: ConsoleColor.DarkRed,
                                backgroundColor: ConsoleColor.White);

            System.Console.WriteLine();
        }

        private static int AddWrapper(int x, int y)
        {
            return Add();

            int Add()
            {
                return x + y;
            }
        }

    }
}