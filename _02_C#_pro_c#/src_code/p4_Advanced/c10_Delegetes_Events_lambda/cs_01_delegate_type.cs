using System;

namespace Delegate_Type
{
    class Program
    {
        static int Main(string[] args)
        {
            // Delegate type, P418
            {
                /*
                
                + concept
                    - callback mechanism: any application requires that an obj be able to communicate BACK to the entity that created it;
                      
                      ```python

                        >>> def add(a, b):
                        ...     return a + b
                        ...
                        >>> add(1, 2)
                        3
                        >>> def sum(add, seq):  // function "sum" calls function "add"    
                        ...     ttl = 0
                        ...     for i in seq:
                        ...             ttl = add(ttl, i)   // function "add" calls parts of function "sum"
                        ...     return ttl
                        ...
                        >>> sum(add, [1, 2, 3])
                        6
                        >>> def mul(a, b):
                        ...     return a * b
                        ...
                        >>> sum(mul, [1, 2, 3, 4])
                        0

                      ```

                      ```c++
                      
                        void message(char* s)
                        { std::cout << s << std::endl; }

                        typedef void (*funcPtr)(char*);

                        int Add(int x, int y, funcPtr p)
                        {
                            char s[] = "hello world";
                            p(s);
                            return x + y;
                        }

                        int main()
                        {
                            char s[] = "hello";
                            funcPtr p = message;
                            p(s);

                            int res = Add(3, 4, message);
                            std::cout << res << std::endl;

                            return 0;
                        }

                      ```
                + 
                
                */ 

            }

            //
            {

            }

            return 0;
        }

        
    }
}