// ancm?

using System;

namespace CS_Array
{
    class Program
    {
        public static void Main(string[] args)
        {
            // array
            {
                /*
                
                + concept: same with C/C++ array types

                + creation:
                    - declaration, then initialization at the different time
                    - declaration and initialization at the same time

                */
                FuckWithArray();
                
                Console.ReadLine();
            }

            // implicit type deduction
            {
                /*
                + implicit type deduction:
                    - same concept in C/C++
                */
                DeclareImplicitArrays();

                Console.ReadLine();
                
            }

            // object array stores anything at all
            {
                ObjectArray();

                Console.ReadLine();
            }

            // multi-dimensional arrays
            {
                // rectangular array
                RectMultidimensionalArray();

                // jagged array
                JaggedMDarray();

                Console.ReadLine();
            }

            // array works with function
            {
                PassAndReceiveArrays();

                Console.ReadLine();
            }

            // System.Array Base cls, P175
            {
                /*
                
                + select members of System.Array
                    - Clear()
                    - CopyTo()
                    - Length
                    - Rank
                    - Reverse()
                    - Sort()
                
                */ 
            }
        }

        private static void FuckWithArray()
        {
            System.Console.WriteLine("***** Fuck with array *****");
            System.Console.WriteLine("=> simple array creation.");

            // various versions: declare and initialize
            int[] numbers = new int[3]
            {
                0,
                1,
                2,
            };

            string[] books = new string[100]; // 100 is capacity. it is same with C/C++, but differs with VBA

            System.Console.WriteLine();
        }

        private static void DeclareImplicitArrays()
        {
            System.Console.WriteLine("=> Implicit array initialization:");

            // int array
            var a = new[] { 1, 2, 3, 4, 5 };
            System.Console.WriteLine($"a is a: {a.ToString()}");
            // double array: upcasting
            var b = new[] { 1, 2.5, 3, 4.5, 5 };
            System.Console.WriteLine($"b is b: {b.ToString()}");
            // string array: upcasting
            var c = new[] { "hello", null, "world" };
            System.Console.WriteLine($"c is c: {c.ToString()}");
            // mixed types which can't be unified-upcasting to a certain type are not allowed
            // always narrowing(downcasting) in C/C++
            var d = new[] { 1, "one", 2, "two", false };

            System.Console.WriteLine();

        }

        private static void ObjectArray()
        {
            object[] objects = new object[4]
            {
                10,
                false,
                new DateTime(2021, 1, 27),
                "hello world",
            };

            foreach(object obj in objects)
            {
                System.Console.WriteLine($"type: {obj.GetType()}, vale: {obj}");
            }

            System.Console.WriteLine();
        }

        private static void RectMultidimensionalArray()
        {
            System.Console.WriteLine("=> Rectangular multidimensional array:");
            // A rectangular MD array
            int[,] myMatrix;
            myMatrix = new int[3, 4];
            
            // populate(3 * 4) array
            for(int i=0; i < 3; ++i)
            {
                for(int j=0; j < 4; ++j)
                {
                    myMatrix[i, j] = i * j;
                }
            }

            // repr
            for(int i=0; i<3; ++i)
            {
                for(int j=0; j<4; ++j)
                {
                    System.Console.WriteLine(myMatrix[i, j] + "\t");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        private static void JaggedMDarray()
        {
            System.Console.WriteLine("=> Jagged md array:");

            // create
            int[][] myJagArray = new int[5][];

            // populate
            for(int i=0; i < myJagArray.Length; ++i)
            {
                myJagArray[i] = new int[i + 7];
            }

            // repr
            for(int i=0; i<5; ++i)
            {
                for(int j=0; j<myJagArray[i].Length; ++j)
                {
                    System.Console.WriteLine(myJagArray[i][j] + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();

        }

        private static void PrintArray(int[] numbers) // -> paramarray
        {
            // array as args
            for(int i=0; i<numbers.Length; ++i)
            {
                System.Console.WriteLine($"Item {i} is {numbers[i]}");
            }
        }

        private static string[] GetStringArray()
        {
            // array as return_value
            string[] tmp = new string[]
            {
                "hello",
                "from",
                "GetStringArray",
            };

            return tmp;
        }

        private static void PassAndReceiveArrays()
        {
            System.Console.WriteLine("=> Arrays as params and return values:");

            // pass array as arg
            int[] ages = { 20, 22, 23, 0 };
            PrintArray(ages);

            // return array as return_value
            string[] strs = GetStringArray();
            foreach(string str in strs)
            {
                System.Console.WriteLine(str);
            }
            System.Console.WriteLine();

        }

        private static void SystemArrayFunctionality()
        {
            System.Console.WriteLine("=> working with System.Array:");

            // create
            string[] bands = new string[]
            {
                "Tones on Tail",
                "Bauhaus",
                "Sisters of Mercy",
            };

            // print out names in original order
            foreach(string band in bands)
            {
                System.Console.WriteLine(band + " ");
            }
            System.Console.WriteLine();

            // reverse
            Array.Reverse(bands);
            System.Console.WriteLine("-> reversed array:");
            foreach(string band in bands)
            {
                System.Console.WriteLine(band + ", ");
            }
            System.Console.WriteLine();

            // clear
            System.Console.WriteLine("-> cleared out all but one...");
            Array.Clear(bands, 1, 2);

            // repr again
            foreach(string band in bands)
            {
                System.Console.WriteLine(band + ", ");
            }
            System.Console.WriteLine();
        }






    }
}