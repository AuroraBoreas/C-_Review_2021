using System;

namespace Access_Modifiers
{
    class Program
    {

        class Person
        {
            private string m_name;
            private int m_age;

            Public Person(string name)
            : this(name, 1)         // why the fuck are u complaining? me nothing wrong
            {}

            public Person(int age)
            : this("", age)
            {}

            public Person(string name, int age)
            {
                m_name = name;
                m_age = age;
            }

            // getter, setter
            public int Age
            {
                get => m_age;
                set => m_age = value;
            }

        }


        public static int Main(string[] args)
        {
            // access modifiers
            {
                /*
                
                private

                public

                protect

                internal

                private internal

                
                */ 

                // skip

            }

            // properties using lambda
            {

            }

            return 0;
        }
    }
}