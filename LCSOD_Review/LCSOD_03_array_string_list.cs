using System;
using System.Collections.Generic;

// pattern: ncm?
namespace LCSOD_03_array_string_list
{
    class Program
    {
        static void Main(string[] args)
        {
            // array
            {
                /*
                + in C++, array
                    - syntax pattern: T N V
                    - interpretion pattern: void (int* var[])(char*);
                    - precursor: known numbers of elements / capacity
                
                + in C#, array
                    - syntax pattern: T N V
                    - interpretion pattern:
                        T[] array_name = {};
                        or
                        T[] array_name = new T[N];
                        array_name = new T[N] { ... };

                    - precursor: known numbers of elements
                */

                // declaration
                int[] arr1 = { 3, 4, 5, 6, 10, 7 };
                // op: add, remove, removeat, [], contains, count, length, ...
                // container:

                // length
                arr1.Length;

                // sort, O(log n)
                Array.Sort(arr1);
                
                // access
                int index = 0;
                arr1[index];
                arr1[index]++;

                // count
                int element = 3;
                arr1.Count(element);

                // remove
                arr1.Remove(element);
                arr1.RemoveAt(element, 0);

                // copy
                int[] arr2 = {};
                Array.Copy(arr2, arr1, 3);

            }

            // string
            {
                /*
                same concepts in C++

                + creation: string s1; // empty string ""
                + concatenation: s1 + s2;
                + formatting: string.Format("{0:HH:mm} {1} {2}", date, name, age);
                + interpolation: $"{s1} {s2}";
                + operations: [], IndexOf, Length,

                + substring:

                + split:
                
                + triple literal?
                */
                
                // declare
                string s1 = "hello";
                string s2 = "world";

                Console.WriteLine(s1 + " " + s2);

                Console.WriteLine($"{s1} {s2}");

                s1.Length;
                s1.Count('s');

                // access
                s1[0];
                s1[1] = 'ss'; // mutalbe or immutable?

                // IndexOf
                s1.IndexOf(3);

                // split 
                string sepatrators = {",", ";"};
                string text = "Consequat, minim, labore, ex, pariatur.";
                string[] res = text.split(separators, StringOperation.None);
                

            }

            // list
            {
                // create
                List<decimal> arr2 = new List<decimal>();
                arr2 = new List<decimal> { 1.1m, 2.718m, 3.141m, 6.18m };

                // count
                arr2.Count;

                // contain
                arr2.Contain(3.141m);
                
                // []
                arr2[0];
                arr2[1] = 2.7182818m;

                // clear
                arr2.Clear();

                // add. push_back() in C++
                arr2.add(9.812m);

            }
        }
    }
}