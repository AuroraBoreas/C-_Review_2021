using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{
    class MMath
    {
        public static int Factorial(int n)
        {
            return (n < 2) ? 1 : n * Factorial(n - 1);
        }
        public static int Fibonacci(int n)
        {
            return (n < 2) ? 1 : Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        
    }
}
