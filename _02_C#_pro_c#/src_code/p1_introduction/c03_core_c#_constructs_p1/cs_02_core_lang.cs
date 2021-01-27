using System;
using System.Numerics; // for BigIntegers
using System.Text;     // for mutable strings

/*
wait, it does not compile as well.

procedures:
- add reference and select System.Numerics.dll

*/

// ancm?

namespace Pilosohpy
{
    class Program
    {
        static int Main(string[] args)
        {
            // System.Environment cls
            {
                /*
                + Properties:
                    ExitCode
                    Is64BitOperatingSystem
                    MachinName
                    NewLine
                    SystemDirectory
                    UserName
                    Version
                */

                showEnvironmentInfo();

                Console.ReadLine();
            }

            // System.Console cls
            {
                /*
                + selected properties
                    - beep()
                    - clear()
                    - backgroundcolor
                    - foregroundcolor
                    - bufferweight
                    - bufferheight
                    - title
                    - windowheight
                    - windowwidth
                    - windowtop
                    - windowleft
                */

                Console.WriteLine("**** Basic I/O ****");
                getUserData();
                Console.ReadLine();
            }

            // string interpolation, formatting
            {
                /*
                + formatting numeric data
                    .NET numeric format characters
                    C or c  -> currency
                    D or d  -> digit
                    E or e  -> scientific exp
                    F or f  -> floating-point
                    G or g  -> general
                    N or n  -> basic numerical formatting with comma
                    X or x  -> hex
                */

                formatNumericData();

                displayMessage();

                System.Console.ReadLine();

            }


            // var
            {
                localVarDeclaration();
                System.Console.ReadLine();
            }

            // intrinsic datatype and new operator
            {
                /*
                + all intrinsic data types support what is known as default constructor. this allows u to create a var using new keyword, which automatically sets the var to its default value
                    - bool          -> false
                    - numeric       -> 0 or 0.0
                    - char          -> ''
                    - BigInteger    -> 0
                    - DateTime      -> 1/1/0001 12:00:00AM
                    - Obj           -> null
                    - String        -> null
                */
                objectFunctionality();
            }

            // members of numerical data types
            {
                // cls hierarchy of CTS on P131

                dataTypeFunctionality();
            }

            // boolean
            {
                // boolean does not support MinValue/MaxValue properties but
                boolFalseTrueString();
                System.Console.ReadLine();
            }

            // System.Char, P133
            {
                charFunctionality();

                Console.ReadLine();
            }

            // Parsing values from string data, P134
            {
                parseFromString();

                Console.ReadLine();
            }

            // T.TryParse()
            {
                parseFromStringsWithTryParse();

                Console.ReadLine();
                
            }

            // System.DateTime cls, System.TimeSpan cls
            {
                userDatesAndTimes();

                Console.ReadLine();

            }

            // BigInteger
            {
                useBigIntegerDemo();

                Console.ReadLine();
            }

            // digit separator literal _
            {
                // similar concept in Python, Julia using _ to separate long digits
                useDigitSeparators();
                Console.ReadLine();
                
            }

            // binary literal
            {
                useBinaryLiterals();
                Console.ReadLine();
                
            }


            // System.String cls
            {
                /*
                
                + select members
                    - length

                    - compare()
                    - Contains()

                    - Equals()
                    - Format()

                    - Insert()
                    - Padleft()
                    - Padright()
                    
                    - Remove()
                    - Replace()

                    - split()
                    - Trim()
                    
                    - ToUpper()
                    - ToLower()
                
                */ 
                usebasicStringManipulation();
                Console.ReadLine();
                
            }

            // Strings and Equality
            {
                /*
                
                + equality/relational op for string in C#
                    - CurrentCulture
                    - CurrentCultureIgnoreCase

                    - InvariantCulture
                    - InvariantCultureIgnoreCase

                    - Ordinal
                    - OrdinalIgnoreCase
                
                */ 

                StringEqualitySpecifyingCompareRules();
                Console.ReadLine();

            }

            // differs with C/C++, Strings are immutable in C# like Python
            {
                string s1 = "Zhang Liang";
                s1[0] = 'S'; // not OK. compiler complains

                // this is not good for frequent word/text processing due to the nature of copy
                // using System.Text.StringBuilder type instead
                fuckWithStringBuilder();
                Console.ReadLine();

                // string interpolation
            }

            // type conversion
            {
                /*
                narrowing and widening data type conversion
                (downcasting, upcasting in C++, especially care about uniform initializer)
                */ 

                fuckWithDataTypeConversion();
                Console.ReadLine();
            }

            // checked keyword
            {
                /*
                
                + mechanism:
                    when u wrap a statement(or a block of statement) within the scope of the checked keyword
                    C# compiler emits additional CIL instructions that test for overflow condtions that may result when +, -, *, / operations

                    if overflow has occurred, u will receive a runtime exception: System.OverflowException
                */ 

                processBytes();
                Console.ReadLine();

                // or using Advanced Build Setting in project's property page for project-wide overflow/underflow data checking

            }

            // unchecked keyword
            {
                /*
                
                + mechanism
                    if enabled project-wide overflow/underflow check,
                    unchecked keyword disables the throwing of an overflow exception on a case-by-case basis.

                + usage:
                    similar with checked keyword
                
                */ 

            }

            // var keyword, P156
            {
                /*
                similar concept in Swift, or auto in C++ (strong typed langs)

                similar restrictions like auto in C++
                - declaration + initialization in one line
                - class data members or return_type or arg_type are not allowed to use var type

                - note: var type is strong type data
                - note: c# allows dynamic typing using keyword dynamic

                */ 

                // see class ThisWillNeverCompiler
                declareImplicitVars();

                // using var type in LINQ
                LinqOverInts();

                Console.ReadLine();
            }

            // loops, P161
            {
                // same concepts in C/C++
                ForLoopExample();
                WhileLoopExample();

                Console.ReadLine();
            }

            // control flow, P165
            {
                // same concepts in C/C++, Python, VB/VBA, R, Swift langs
                IfElseExample();
                // each case(including default) have a terminating return, break, or goto to avoid falling through to next statement
                // this differs with C/C++
                SwitchCaseExample();

                Console.ReadLine();
            }

            // using pattern matching in switch statement, P165
            {
                /*
                
                + mechanism:
                    - case statements can evaluate the type of the variable being checked
                    - case expressions are no longer limited to const values

                    - note: the rule that each case statement MUST be terminated with a return or break still applies; however, goto statments are not supported using the type pattern

                */
                ExecutePatternMatchingSwitch();

                Console.ReadLine();
            }











            return 0;
        }

        static void showEnvironmentInfo()
        {
            foreach(string driver in Environment.GetLogicalDrivers())
            { Console.WriteLine("Drive: {0}", driver); }

            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
        }

        private static void getUserData()
        {
            // get name and age
            System.Console.WriteLine("please enter your name: ");
            string userName = System.Console.ReadLine();
            System.Console.WriteLine("please enter your age: ");
            string userAge = System.Console.ReadLine();

            // get echo color
            ConsoleColor prevColor = Console.Foregroundcolor;
            Console.Foregroundcolor = ConsoleColor.Yellow;

            // echo to the console
            System.Console.WriteLine("hello {0}! You are {1} yo.", userName, userAge);

            // restore previous color
            Console.Foregroundcolor = prevColor;

        }

        private static void formatNumericData()
        {
            // formatting numeric charactors
            int x = 99999;
            System.Console.WriteLine($"The value {x} in various formats:");
            System.Console.WriteLine("c format: {0: c}", x);
            System.Console.WriteLine("d format: {0: d9}", x);
            System.Console.WriteLine("f format: {0: f3}", x);
            System.Console.WriteLine("n format: {0: n}", x);

            // note the difference between uppercase vs lowercase
            System.Console.WriteLine("E format: {0: E}", x);
            System.Console.WriteLine("e format: {0: e}", x);
            System.Console.WriteLine("X format: {0: X}", x);
            System.Console.WriteLine("x format: {0: x}", x);

        }

        private static void displayMessage()
        {
            // using string.Format()
            string msg = string.Format("100000 in hex is {0:x}", 100000);
            // u need to reference PresentationFramework.dll
            // in order to compile this line of code
            System.Windows.MessageBox.Show(msg);
        }

        private static void localVarDeclaration()
        {
            System.Console.WriteLine("=> Data Declaration");

            // T N V
            int myInt = 42;
            string myString = "Hello world";
            System.Boolean b1 = true,
                           b2 = false,
                           b3 = b1;
            bool b4 = false;


            // default
            long myLong = default;

            System.Console.WriteLine("your data: {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);

        }

        private static void NewingDataType()
        {
            System.Console.WriteLine("=> Using new to create var:");

            bool b = new bool();
            int  i = new int();
            double d = new double();
            DateTime dt = new DateTime();

            System.Console.WriteLine($"{b} {i} {d} {dt}");
            System.Console.WriteLine();
        }

        private static void objectFunctionality()
        {
            System.Console.WriteLine("=> System.Object Functionality:");

            System.Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            System.Console.WriteLine("12.Equals() = {0}", 12.Equals(42));
            System.Console.WriteLine("12.ToString() = {0}", 12.ToString());
            System.Console.WriteLine("12.GetType() = {0}", 12.GetType());

            System.Console.WriteLine();
        }

        private static void dataTypeFunctionality()
        {
            System.Console.WriteLine("=>Data Type Functionality:");

            System.Console.WriteLine("Max of int: {0}", int.MaxValue);
            System.Console.WriteLine("Min of int: {0}", int.MinValue);
            System.Console.WriteLine("Max of double: {0}", double.MaxValue);
            System.Console.WriteLine("Min of double: {0}", double.MinValue);
            System.Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            System.Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            System.Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);

            System.Console.ReadLine();
        }

        private static void boolFalseTrueString()
        {
            System.Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            System.Console.WriteLine("bool.TrueString: {0}", bool.TrueString);

        }

        private static void charFunctionality()
        {
            System.Console.WriteLine("=> char type functionality:");
            char myChar = 'a';
            System.Console.WriteLine($"char.IsDigit({myChar}): {char.isDigit(myChar)}");
            System.Console.WriteLine($"char.IsLetter({myChar}): {char.IsLetter(myChar)}");
            
            myChar = "hello world";
            System.Console.WriteLine($"char.IsWhiteSpace({myChar}, 5): {char.IsWhiteSpace(myChar, 5)}");
            System.Console.WriteLine($"char.IsWhiteSpace({myChar}, 6): {char.IsWhiteSpace(myChar, 6)}");
            System.Console.WriteLine($"char.isPunctuation({'?'}): {char.isPunctuation('?')}");

            System.Console.WriteLine();

        }

        private static void parseFromString()
        {
            System.Console.WriteLine("=> Data Type parsing:");
            bool b = bool.Parse("True");
            System.Console.WriteLine($"value of b: {b}");

            double d = double.Parse("99.84");
            System.Console.WriteLine($"value of d: {d}");

            int i = int.Parse("8");
            System.Console.WriteLine($"value of i: {i}");


            // note the uppercase of Char
            char c = Char.Parse("w");
            System.Console.WriteLine($"value of c: {c}");

        }

        private static void parseFromStringsWithTryParse()
        {
            System.Console.WriteLine("=> Data Type Parsing with TryParse:");
            
            if(boo.TryParse("True", out bool b))
            {
                System.Console.WriteLine($"value of b: {b}");
            }

            string s = "hello";
            if(double.TryParse(s, out double d))
            {
                System.Console.WriteLine($"value of d: {d}");
            }
            else
            {
                System.Console.WriteLine($"Failed to convert the input ({s}) to a double");
            }
        }

        private static void userDatesAndTimes()
        {
            System.Console.WriteLine("=> Dates and Times:");

            // datetime constructor
            DateTime dt = new DateTime(2021, 10, 17);

            // day?
            System.Console.WriteLine($"the day of {dt.Date} is {dt.DayOfWeek}");

            // month?
            dt = dt.AddMonth(2);
            System.Console.WriteLine($"Daylight savings: {dt.isDayLightSavingTime()}");

            // time constructor
            TimeSpan ts = new TimeSpan(4, 30, 0);
            System.Console.WriteLine(ts);

            // time difference: t1 - t2
            System.Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));

        }


        private static void useBigIntegerDemo()
        {
            System.Console.WriteLine("=> Use BigInteger:");
            BigInteger biggy = BigInteger.Parse("99999999999999999999999999999999999999999999999999999");

            System.Console.WriteLine($"value of biggy is {biggy}");
            System.Console.WriteLine($"is biggy an even value?: {biggy.IsEven}");
            System.Console.WriteLine($"is biggy a power of two?: {biggy.IsPowerOfTwo}");

            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("8888888888888888888888888888888888888888888888888"));

            System.Console.WriteLine($"value of reallyBig is {reallyBig}");
        }

        private static void useDigitSeparators()
        {

            System.Console.WriteLine("=> use digit separators:");

            // int
            System.Console.Write("Integer:");
            System.Console.WriteLine(123_456);

            // long
            System.Console.Write("Long:");
            System.Console.WriteLine(123_456_789L);

            // float
            System.Console.Write("Float:");
            System.Console.WriteLine(123_456.12f);

            // double
            System.Console.Write("Double:");
            System.Console.WriteLine(123_456_789.12);

            // decimal
            System.Console.Write("Decimal");
            System.Console.WriteLine(123_456.12M);
        }

        private static void useBinaryLiterals()
        {
            // same concept in Python
            System.Console.WriteLine("=> use binary literals:");

            System.Console.WriteLine($"Sixteen: {0b0001_0000}");
            System.Console.WriteLine($"Thirty Two: {0b0010_0000}");
            System.Console.WriteLine($"Sixty Four: {0b0100_0000}");
        }

        private static void usebasicStringManipulation()
        {
            System.Console.WriteLine("=> Basic String functionality:");

            string firstName = "Zhang";
            System.Console.WriteLine($"value of firstName: {firstName}");
            System.Console.WriteLine($"firstName has {firstName.Length} charaters");
            System.Console.WriteLine($"firstName in uppercase: {firstName.ToUpper()}");
            System.Console.WriteLine($"firstName in lowercase: {firstName.ToLower()}");
            System.Console.WriteLine($"firstName contains the letter Z?: {firstName.Contains()}");
            System.Console.WriteLine($"firstName after replace: {firstName.Replace("Z", "S")}");

            // concat
            string s1 = "Zhang",
                   s2 = "Liang",
                   s3 = s1 + " " + s2;
            // +
            System.Console.WriteLine($"string concatenation {s1} + \" \" + {s2} = {s3}");
            // String.Concat()
            s3 = String.Concat(s1, " ", s2);
            System.Console.WriteLine($"string concatenation {s1} + \" \" + {s2} = {s3}");
            
            // raw string or triple literal in c# using @

        }

        private static void StringEqualitySpecifyingCompareRules()
        {
            // strings and equality
            System.Console.WriteLine("=> String equality(Case Insensitive:)");
            string s1 = "hello",
                   s2 = "HELLO";
            
            System.Console.WriteLine($"s1 = {s1}, s2 = {s2}");
            System.Console.WriteLine();

            // default string cmp rule
            System.Console.WriteLine($"Default cmp rules: s1 = {s1}, s2 = {s2}, s1.Equals(s2): {s1.Equals(s2)}");

            // ignore case
            System.Console.WriteLine($"s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {s1.Equals(s2, StringComparison.OrdinalIgnoreCase)}");
            System.Console.WriteLine($"s1.Equals(s2, StringComparison.InvariantIgnoreCase): {s1.Equals(s2, StringComparison.InvariantIgnoreCase)}");
            System.Console.WriteLine($"s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {s1.Equals(s2, StringComparison.InvariantCulturenoreCase)}");

        }

        private static void fuckWithStringBuilder()
        {
            System.Console.WriteLine("=> using the StringBuilder:");

            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");

            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("MorrowWind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");

            System.Console.WriteLine(sb.ToString());            
            sb.Replace("2", " Invisible War");

            System.Console.WriteLine(sb.ToString());
            System.Console.WriteLine($"sb has {sb.Length} chars");

        }

        private static void fuckWithDataTypeConversion()
        {
            System.Console.WriteLine("**** fuck with type conversion ****");

            // add two shorts
            short a = 9, b = 11;
            System.Console.WriteLine($"{a} + {b} = {add(a, b)}");

            a = 30000; b = 30000; // short 2 bytes
            short res;
            // res = add(a, b); // ouch, implicit converts to int, but res is overflowing.
            res = (short)add(a, b);

            System.Console.WriteLine($"{a} + {b} = {res}");

            Console.ReadLine();
        }

        private static int add(int a, int b)
        {
            return (a + b);
        }

        private static void processBytes()
        {
            byte b1 = 100,
                 b2 = 250;
            
            try
            {
                byte sum = checked((byte)add(b1, b2));
                System.Console.WriteLine($"sum = {sum}");
            }
            catch (System.Exception ex)
            {
                 System.Console.WriteLine(ex.Message);
            }

            // or
            try
            {
                checked
                {
                    byte sum = (byte)add(b1, b2);
                    System.Console.WriteLine($"sum = {sum}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private static void declareImplicitVars()
        {
            // implicit vars
            var myInt = 42;
            var myBool = true;
            var myString = "hello ZL";

            // repr
            System.Console.WriteLine($"myInt is a : {myInt.GetType().Name} ");
            System.Console.WriteLine($"myBool is a : {myBool.GetType().Name} ");
            System.Console.WriteLine($"myString is a : {myString.GetType().Name} ");

        }

        class ThisWillNeverCompiler
        {
            private var myInt = 10; // not OK. var keyword can't be used in data members
            public var myMethod(var x, var y){} // not OK. var type can't be used in return_type or args
        }

        private static void LinqOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            
            // using var type in LINQ
            var subset = 
                from number in numbers
                where (number % 2) == 0
                orderby number
                select number;
            
            // display
            foreach(var n in subset)
            {
                System.Console.WriteLine($"{n}");
            }

            // hmm... what type is subset?
            System.Console.WriteLine($"subset is a : {subset.GetType().Name}");
            System.Console.WriteLine($"subset is defined in : {subset.GetType().Namespace}");
        }

        private static void ForLoopExample()
        {
            for(int i=0; i<4; ++i)
            {
                System.Console.WriteLine($"number is: {i}");
                // continue, break, goto(i dont like this goto keyword...)
            }

            // string[] carTypes = new string[4];
            // carTypes = new string[4] { "Ford", "BMW", "Yugo", "Honda" };

            // or
            string[] carTypes = new string[4]
            {
                "Ford",
                "BMW",
                "Yugo",
                "Honda",
            };

            foreach(string carType in carTypes)
            {
                System.Console.WriteLine(carType);
            }

        }

        private static void WhileLoopExample()
        {
            bool b = true;
            while(b)
            {
                // ...;
                b = false;
            }

            do
            {
                // ...;
                if(!false)
                    break;
            } while (true);
        }

        private static void IfElseExample()
        {
            string myStr = "hello world!";
            if(myStr.Length > 0)
            {
                System.Console.WriteLine("local string length is > 0");
            }
            else
            {
                System.Console.WriteLine("local string length is not > 0");
            }

            // or ternary op
            bool b = (myStr.Length > 0)? true: false;
            // ...;
            // or one-step further
            string b = (myStr.Length > 0)? "is" : "is not";
            System.Console.WriteLine($"local string length is {b} > 0");

        }

        private static void SwitchCaseExample()
        {
            int ye = 2021,
                mo = 1,
                da = 26;

            bool res = true;
            
            if(ye < 1) { res = false; }
            if(mo < 1 || mo > 12) { res = false; }
            if(da < 1 || da > 31) { res = false; }

            switch(mo)
            {
                case 2: if(isLeapYear(ye))
                        {
                            if(da > 29) { res = false; }
                        }
                        else
                        {
                            if(da > 28) { res = false; }
                        }
                        break;
                case 4:
                case 6:
                case 9:
                case 11: if(da > 32)
                         { return false; }
                         break;
            }

            if(res)
            { System.Console.WriteLine($"{ye}-{mo}-{da}"); }
            else
            { System.Console.WriteLine("no available year-month-day integers"); }

        }

        private static void SwitchWithGoto()
        {
            var foo = 5;
            switch(foo)
            {
                case 1:
                    // ...
                    goto case 2;
                case 2:
                    // ...
                    break;
                case 3:
                    // ...
                    goto default;
                default:
                    // ...
                    break;
            }
        }

        private static void ExecutePatternMatchingSwitch()
        {
            System.Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5m)]");
            System.Console.WriteLine("Please choose an option:");

            string userChoice = Console.ReadLine();
            object choice;

            // this is a standard const pattern switch statement to set up
            switch(userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5m;
                    break;
                default:
                    choice = 5;
                    break;
            }

            // this is pattern matching swith statement, chainning the previous switch statement
            switch(choice)
            {
                case int i:
                    System.Console.WriteLine("your choice is an integer.");
                    break;
                case string s:
                    System.Console.WriteLine("your choice is a string.");
                    break;
                case decimal d:
                    System.Console.WriteLine("your choice is a decimal.");
                    break;
                default:
                    System.Console.WriteLine("your choice is something else.");
                    break;
            }

        }

    }
}