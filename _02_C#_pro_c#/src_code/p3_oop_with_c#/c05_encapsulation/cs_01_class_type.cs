using System;

namespace Encapsulation
{
    class Program
    {

        // class Car // version 0
        // {
        //     public string m_petName;
        //     public int    m_currSpeed;

        //     public void PrintSate()
        //     => System.Console.WriteLine($"{m_petName} is going {m_currSpeed} MPH.");

        //     public void SpeedUp(int delta)
        //     => m_currSpeed += delta;
        // };

        // class Car // version 1
        // {
        //     public string m_petName;
        //     public int    m_currSpeed;

        //     // default constructor
        //     public Car()
        //     {
        //         m_petName = "Chuck";
        //         m_currSpeed = 10;
        //     }

        //     public void PrintSate()
        //     => System.Console.WriteLine($"{m_petName} is going {m_currSpeed} MPH.");

        //     public void SpeedUp(int delta)
        //     => m_currSpeed += delta;
        // };

        // class Car // version 2
        // {
        //     public string m_petName;
        //     public int    m_currSpeed;

        //     // default constructor
        //     public Car()
        //     {
        //         m_petName = "Chuck";
        //         m_currSpeed = 10;
        //     }

        //     // parameterized constructor
        //     public Car(string name)
        //     {
        //         m_petName = name;
        //     }
        //     public Car(string name, int speed)
        //     {
        //         m_petName = name;
        //         m_currSpeed = speed;
        //     }

        //     public void PrintSate()
        //     => System.Console.WriteLine($"{m_petName} is going {m_currSpeed} MPH.");

        //     public void SpeedUp(int delta)
        //     => m_currSpeed += delta;
        // };

        class Car // version 3
        {
            public string m_petName;
            public int    m_currSpeed;

            // default constructor
            public Car()
            {
                m_petName = "Chuck";
                m_currSpeed = 10;
            }

            // parameterized constructor, lambda-expr
            public Car(string name)
            => m_petName = name;

            public Car(string name, int speed)
            {
                m_petName = name;
                m_currSpeed = speed;
            }

            public void PrintSate()
            => System.Console.WriteLine($"{m_petName} is going {m_currSpeed} MPH.");

            public void SpeedUp(int delta)
            => m_currSpeed += delta;
        };

        class Motorcycle
        {
            public int m_driverIntensity;
            public void PopAWheely()
            {
                for(int i=0; i<=m_driverIntensity; ++i)
                { System.Console.WriteLine("Yeeeeeeeee Haaaaaaaaaaaaawww!"); }
            }

            public Motorcycle(){}

            public Motorcycle(int driverIntensity)
            { m_driverIntensity = driverIntensity; }
        }

        public static int Main(string[] args)
        {
            // basis of class
            {
                /*

                + concept:

                        A   E   I   P
                    S
                    O
                    L
                    I
                    D
                
                + creation: (this differs with C++ thou, but it is same with VB/VBA)
                    - obj MUST be allocated into memory using new keyword
                    - if u dont do this, compiler will complain


                */ 
                FuckWithClassTypes();
            }

            // constructors
            {
                /*
                
                + concept:
                    - in c++ < 11, class has four auto-generated constructors by compiler:
                        > default constructor: constructor that programmers dont need to provide args
                        > copy constructor
                        > copy assignment constructor
                        > default destructor

                    - in c++ >= 11, additional constructors:
                        > move constructor
                        > move assignment constructor
                    
                    - to explicitly constrain constructors, c++ > 11 introduced
                            > default
                            > delete
                            > final
                            > override

                    - in c#, concept is similar
                
                */ 

                // see class Car definition version 0, 1, 2, 3
            }

            return 0;
        }

        static void FuckWithClassTypes()
        {
            System.Console.WriteLine("=> fuck with class types:");

            Car car1 = new Car();
            car1.m_petName = "ZL";
            car1.m_currSpeed = 10;

            for(int i=0; i<11; ++i)
            {
                car1.SpeedUp(5);
                car1.PrintSate();
            }

            Console.ReadLine();
        }



    }
}