using System;

namespace Delegate_Type
{
    public delegate int BinaryOp(int x, int y);
    sealed class BinaryOp: System.MulticastDelegate
    {
        public int Invoke(int x, int y);    // <-- exactky match the definition of the BinaryOp delegate;
        public IAsyncResult BeginInvoke(int x, int y, AsyncCallback cb, object state);
        public int EndInvoke(IAsyncResult result);
    }
    
    public delegate string MyDelegate(bool a, bool b, bool c);
    sealed class MyDelegate: System.MulticastDelegate
    {
        public string Invoke(bool a, bool b, bool c);
        public IAsyncResult BeginInvoke(bool a, bool b, bool c, AsyncCallback callback, object state);
        public string EndInvoke(IAsyncResult result);
    }

    public delegate string MyOtherDelegate(out bool a, ref bool b, int c);
    sealed class MyOtherDelegate: System.MulticastDelegate
    {
        public string Invoke(out bool a, ref bool b, int c);
        public IAsyncResult BeginInvoke(out bool a, ref bool b, int c, AsyncCallback callback, object state);
        public string EndInvoke(out bool a, ref bool b, IAsyncResult result);
    }

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

                        def Add(a, b):
                            return a + b

                        def Mul(a, b):
                            return a * b

                        def Caller(func, base, seq):
                            for i in seq:
                                base = func(base, i)
                            return base

                        if __name__ == '__main__':
                            res = Caller(Add, 0, [1, 2, 3, 4])
                            print(res)
                            res = Caller(Mul, 1, [1, 2, 3, 4])
                            print(res)

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

                    + delegate(C-style pointer, but type-safe in C#)
                        it maintains 3 important pieces of info
                        - the "address" of the method on which it makes calls
                        - the "parameters" (if any) of this method
                        - the "return type" (if any) of this method

                      ```
                + 
                
                */ 
                // see python_callback.py
                // see c++_callback.cpp
            }

            // define a Delegate type
            {
                /*
                
                + syntax: `access_modifier delegate return_type func_name(T args)`;
                
                + mechanism
                    - c# compiler processes delegate types, it automatically generates a sealed class derived from System.MulticastDelegate;
                    - this class (in conjunction with its base class, System.Delegate) provides the necessary infrastructure for the delegate to 
                    hold onto a list of methods to be invoked at a later time;

                    - using ildasm.exe to analyze delegate; Invoke() is used to invoke each method maintained by the delegate obj in a synchronous manner;
                    meaning the caller MUST wait for the call to complete before continuing on its way;
                    - synchronous Invoke() method may not need to be called explicitly form u code;
                    - BeginInvoke() and EndInvoke() provide the ability to call the current method asynchronously on a separate thread of execution;

                    >> how exactly does the compiler know how to define the Invoke(), BeginInvoke(), and EndInvoke() methods?

                    ```c#
                    sealed class BinaryOp: System.MulticastDelegate
                    {
                        public int Invoke(int x, int y);    // <-- exactky match the definition of the BinaryOp delegate;
                        public IAsyncResult BeginInvoke(int x, int y, AsyncCallback cb, object state);
                        public int EndInvoke(IAsyncResult result);
                    }

                    ```
                
                + summary pattern

                    ```c#

                    public sealed class DelegateName: System.MulticastDelegate
                    {
                        public delegateReturnType Invoke(allDelegateInputRefAndOutParams);
                        public IAsyncResult BeginInvoke(allDelegateInputRefAndOutParams, AsyncCallback cb, object state);
                        public delegateReturnType EndInvoke(allDelegateRefAndOutParams, IAsyncResult result);
                    }

                    ```

                */ 

            }

            // System.MulticastDelegate and System.Delegate
            {
                /*

                + definition 
                    ```c#

                    namespace System
                    {
                        public abstract class Delegate: ICloneable, ISerializable
                        {
                            // methods to interact wit the list of functions
                            public static Delegate Combine(params Delegate[] delegates);    // <-- +=
                            public static Delegate Combine(Delegate a, Delegate b);
                            public static Delegate Remove(Delegate source, Delegate value); // <-- -=
                            public static Delegate RemoveAll(Delegate source, Delegate value);

                            // overloaded operators
                            public static bool operator==(MulticastDelegate d1, MulticastDelegate d2);
                            public static bool operator!=(MulticastDelegate d1, MulticastDelegate d2);

                            // props that expose the delegate target
                            public MethodInfo Method {get;}
                            public object Target { get; }
                        }

                        public abstract class MulticastDelegate: Delegate
                        {
                            // return the list of methods "point to"(function pointers)
                            public sealed override Delegate[] GetInvocationList();

                            // overloaded operators
                            public static bool operator==(MulticastDelegate d1, MulticastDelegate d2);
                            public static bool operator!=(MulticastDelegate d1, MulticastDelegate d2);

                            // used internally to manage the list of methods maintained by the delgate
                            private IntPtr _invocationCount;
                            private object _invocationList;
                        }
                    }

                    + note
                        - u can NEVER derive from these base classes in your code (compiler error)

                    ```
                
                */
            }

            return 0;
        }

    }
}