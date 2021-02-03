using System;
using System.Collections.Generic;

namespace Anonymous_Methods
{
    class CarEventArgs: EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        { msg = message; }
    }

    class Car
    {
        public string PetName { get; set; }
        public int MaxSpeed { get; set; } = 0;
        public int CurrentSpeed { get; set; } = 0;
        private bool carIsDead = false;

        // ctors
        public Car(){}
        public Car(string n, int mSp, int cSp)
        { PetName = n; MaxSpeed = mSp; CurrentSpeed = cSp; }

        // override
        public override string ToString()
        => $"Name:{PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

        // mirrors MS recommended EventHandler pattern
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public void Accelerate(int delta)
        {
            if(carIsDead)
            {
                Exploded?.Invoke(this, new CarEventArgs("Car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                if(10 >= (MaxSpeed - CurrentSpeed))
                { AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Car is gonna blow...")); }
                if(CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                    Exploded?.Invoke(this, new CarEventArgs("Car is dead..."));
                }
                else
                {
                    System.Console.WriteLine("CurrentSpeed is : {0}", CurrentSpeed);
                }
            }
        }
        
    }
    class Program
    {
        static int Main(string[] args)
        {
            // anonymous methods, P447
            {
                /*
                
                + sytanx pattern:
                    ```c#

                    SomeType t = new SomeType();
                    t += delegate(optionallySpecifiedDelegateArgs)
                    { statement; };

                    ```
                
                */ 

                AnonymousMethodsDemo();
            }

            // accessing local variables
            {
                /*
                
                + note
                    - lambda expression can NOT access ref or out params of the definition method;
                    - lambda expression can NOT have a loal var with the same name as a local var in the outer method;
                    - lambda expression can access instance var(or static var) in the outer class scope;
                    - lambda expression can declare local vars with the same name as outer class member var, <-- hide the outer class member var;
                
                
                */ 

            }

            // lambda expr, P451
            {
                
            }

            return 0;
        }

        static void AnonymousMethodsDemo()
        {
            System.Console.WriteLine("=> Anonymous Methods demo:");

            Car c1 = new Car("ZL", 100, 10);
            // register event handlers as anonymous methods
            c1.AboutToBlow += delegate
            {
                System.Console.WriteLine("Eek! going too fast!");
            };
            
            c1.AboutToBlow += delegate(object sender, CarEventArgs e)
            {
                System.Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate(object sender, CarEventArgs e)
            {
                System.Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };

            // trigger events
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            
            Console.ReadLine();
        }
        
    }
}