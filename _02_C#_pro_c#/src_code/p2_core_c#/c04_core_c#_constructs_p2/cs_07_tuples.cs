using System;

namespace Tuples_Types
{
    class Program
    {

        struct Point
        {
            public int m_x;
            public int m_y;

            public Point(int x, int y)
            {
                m_x = x;
                m_y = y;
            }

            public (int x, int y) Deconstruct() => (m_x, m_y);
        }

        public static int Main(string[] args)
        {

            // tuples
            {
                /*
                
                + concept: similar with pair<> cls and tuple<> cls in C++
                
                + mechanism:
                    - lightweight data structure contains multiple fields
                    - the fields are NOT validated
                    - u can NOT define your own methods
                    - each property is a reference type, which may be potentially causing memory and performance issues

                + definition:
                    - tuples use the new ValueTuple data type instead of reference types, potentially saving significant memory
                    - ValueType data type creates different structs based on the number of properties for a tuple
                    - each property in a tuple can be assigned a specific name

                    ```c++

                    namespace std
                    {
                        template<typename T, typename...Types>
                        class tuple<T, Types...>
                        {
                            public:
                                tuple(const T&, const Types&...);

                                ...;
                        }
                    }

                    ```

                + example:

                        ```c++
                        // pair<>, tuple<>
                        {
                            std::pair<int, float> t1{42, 3.14};
                            std::cout << t1.first << ", " << t1.second << std::endl;
                            // or
                            int a; float b;

                            std::make_pair(std::ref(a), std::ref(b)) = t1;
                            std::cout << a << ", " << b << std::endl;

                            std::tuple<char, short, int, long, float, double, std::string> tp1{'a', 6, 42, 123L, 3.14f, 2.718, "hello"};
                            char c; short s; int i;
                            long l; float f; double d;
                            std::string str;

                            std::tie(c, s, i, l, f, d, str) = tp1;

                            std::cout << c << ", "
                                    << s << ", "
                                    << i << ", "
                                    << l << ", "
                                    << f << ", "
                                    << d << ", "
                                    << str << std::endl;
                        }
                        ```
                */ 

                StartWithTuples();

                InferredVarNames();

                Console.ReadLine();
                
            }

            // using tuple as return_type
            {
                ReturnValueIsTuple();

                Console.ReadLine();
            }

            // deconstructing tuples
            {
                FuckWithTuple();

                Console.ReadLine();
            }
            
            return 0;
        }

        private static void StartWithTuples()
        {
            // declare
            (int, long, string) t1 = (3, 10L, "hello");
            var t2 = (3.14f, 2.718m, 99L);

            // access: ItemX notation, 
            System.Console.WriteLine($"first item: {t1.Item1}");
            System.Console.WriteLine($"second item: {t1.Item2}");
            System.Console.WriteLine($"third item: {t1.Item3}");

            // access: named tuple
            var t3 = (firstLetter: "a", secondName: 5, thirdLetter: "c");
            System.Console.WriteLine($"first item: {t3.firstLetter}");
            System.Console.WriteLine($"second item: {t3.secondName}");
            System.Console.WriteLine($"third item: {t3.thirdLetter}");

        }

        private static void InferredVarNames()
        {
            System.Console.WriteLine("=> Inferred Tuple Names:");
            var foo = new { prop1 = "first", prop2 = "second" };
            var bar = (foo.prop1, foo.prop2);
            System.Console.WriteLine($"{bar.prop1}, {bar.prop2}");
        }

        private static (int a, string b, bool c) FillTheseValue()
        {
            return (9, "Hello world!", true);
        }

        private static void ReturnValueIsTuple()
        {
            var v = FillTheseValue();
            System.Console.WriteLine($"first item:  {v.Item1}");
            System.Console.WriteLine($"second item: {v.Item2}");
            System.Console.WriteLine($"third item:  {v.Item3}");
        }

        private static void FuckWithTuple()
        {
            Point p = new Point(7, 5);
            var PointValues = p.Deconstruct();
            System.Console.WriteLine($"x is : {PointValues.x}");
            System.Console.WriteLine($"y is : {PointValues.y}");
        }








    }
}