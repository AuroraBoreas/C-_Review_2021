using System;
using System.Collections.Generic;

namespace LCSOD_02_arrays_strings_lists
{
    class Program
    {
        static void display(string s)
        { Console.WriteLine(s); }

        static void Main(string[] args)
        {
            // array
            {
                /*
                + array
                    - what: a container stores a group of homogeneous elements with known numbers
                    - why: group together, easy to control
                    - how: as follows
                
                    - array notations: AIP
                        address notation: possible
                        index notation: OK
                        pointer notation(pointer arithmetics): N/A

                    - in C++, syntax as follows
                        creat: T var_name[N] = {}; // it's optional to declare N
                               T var_name[N] = new T{}; // on heap
                        delete: delete[] var_name; // on heap
                        subscript op: var_name[index]; // read
                                      var_name[index] = x; // write
                        loop: for(int i=0; i<var_name.size(); ++i}{ ... };
                        other container operations: ICAMLOBP
                            iterator
                            const_iterator
                            capicity
                            access
                            modifies
                            list operation
                            observers
                            buckets
                            hash policy

                    - C#, syntax as follows
                        create: T[] var_name = {};          // stack
                                T[] var_name = new T[5];    // heap
                                var_name = new [] { ... };
                            
                */

                int[] arr1 = { 5, 4, 10, 3, 1, 2 }; // C# does not allow to declare N though...
                //int[3] arr2;  // not OK
                int index = 1;  // OK
                //index = -1;   // not OK. just ike C++, C# does not support this syntax like Python
                display($"arr1[{index}] = " + arr1[index].ToString());  // 4
                arr1[index] = 15; // write
                //arr1[3] = 4;     // compile time or run time? rt
                display($"arr1[{index}] = ; " + arr1[index].ToString());  // 5
                // Length
                display($"arr1 length is {arr1.Length}");
                // Copy
                int n = 10;
                int[] arr2 = new int[n];
                Array.Copy(arr1, arr2, 5);

                display("before sort, arr2 is as follows: ");
                for(int i = 0; i < n; ++i)
                { Console.WriteLine($"arr2[{i}] = {arr2[i]}"); };
                // Sort
                display("after sort, arr2 is as follows: ");
                Array.Sort(arr2);
                for (int i = 0; i < n; ++i) // not work? why? no it works
                { Console.WriteLine($"arr2[{i}] = {arr2[i]}"); };
                // IndexOf, membership
                display($"Array.IndexOf: {Array.IndexOf(arr2, 3)}");
            }

            // string
            {
                /*
                + string
                    - what: a series of chars combined together to represent natural languages
                    - why: simulation
                    - how: as follows

                + create:
                    - '' differs with "", just like C/C++
                    - string var_name;  // create an empty string implicitly

                + concatenate:
                    - using + op
                
                + interpolation:
                    - using $"{} ... "
                
                + formatting:
                    - using "{0:HH:mm} ...", date

                + membership

                + length

                + reverse?

                + copy



                    
                */
                string s1 = "Hello SCY";
                string s2 = "hello ZL";
                // string itself
                display(s1);
                // concatenation
                display(s1 + ", " + s2);
                // interpolation
                display($"hello {s1}");
                // formatting
                string s3 = string.Format("{0}!, Today is {1}, it's {2:HH:mm} now. ", s2, DateTime.Now.DayOfWeek, DateTime.Now);
                display(s3);
                // properties: Length, Substring(), Equals(), Split(), 
                display($"{s3.Length}");

                display($"{s2.Substring(6, 2)}");

                display($"{s1.Equals(s2)}");

                string[] separator = { ",", ";" };
                string names = "ZL, SYC; LL, , LM; XY";
                string[] substrs = names.Split(separator, StringSplitOptions.None); // so no mama
                substrs = names.Split(separator, StringSplitOptions.RemoveEmptyEntries); // remove ""
                
                
                for(int i = 0; i < substrs.Length; ++i)
                { display(string.Format(substrs[i].Trim())); }


            }


            // list
            {
                /*
                + what: a container stores unknown numbers of elements.
                + why: why not?
                + how: as follows

                it is much closer to array. but more flexible
                
                + header file: using System.Collections.Generic;
                */
                List<int> numbers = new List<int>(); // constructor
                numbers = new List<int> { 3, 4, 5, 7, 10 };
                for(int i=0; i < numbers.Count; ++i)
                { display($"{numbers[i]}"); }

                // add. O(1)
                numbers.Add(13);

                // length
                display(numbers.Count.ToString());

                // Insert. O(n)
                numbers.Insert(1, 15);

                // remove
                numbers.Remove(15);

                // removeat
                numbers.RemoveAt(0);

                // Contain
                numbers.Contains(100);

                // clear
                numbers.Clear();



            }
        }
    }
}
