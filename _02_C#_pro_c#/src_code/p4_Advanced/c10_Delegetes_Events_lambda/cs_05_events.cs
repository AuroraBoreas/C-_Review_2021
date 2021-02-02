using System;

namespace Events_Type
{
    // class Car   // version 0
    // {
    //     public string PetName { get; set; }
    //     public int MaxSpeed { get; set; } = 0;
    //     public int CurrentSpeed { get; set; } = 0;

    //     public Car(){}
    //     public Car(string n, int mSp, int cSp)
    //     { PetName = n; MaxSpeed = mSp; CurrentSpeed = cSp; }

    //     public override string ToString()
    //     => $"Name: {PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

    //     public delegate void carEngineHandler(string message);

    //     public carEngineHandler myCarEngineHandler;

    //     // public void RegisterCarEngineHandler(carEngineHandler h)
    //     // {
    //     //     myCarEngineHandler += h;
    //     // }
    //     // public void UnRegisterCarEngineHandler(carEngineHandler h)
    //     // {
    //     //     myCarEngineHandler -= h;
    //     // }
    //     public void Accelerate(int delta)
    //     {
    //         int currentSpeed = CurrentSpeed + delta;

    //         if(myCarEngineHandler != null)
    //         {
    //             myCarEngineHandler("sorry this car is dead...");
    //         }
    //         else
    //         { throw new InvalidCastException("callback is null!"); }
            
    //     }
    // }

    // class Car   // version 1
    // {
    //     public string PetName { get; set; }
    //     public int MaxSpeed { get; set; } = 0;
    //     public int CurrentSpeed { get; set; } = 0;
    //     private bool carIsDead = false;

    //     public Car(){}
    //     public Car(string n, int mSp, int cSp)
    //     { PetName = n; MaxSpeed = mSp; CurrentSpeed = cSp; }

    //     public override string ToString()
    //     => $"Name: {PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

    //     public delegate void carEngineHandler(string message);

    //     // this car can send these events
    //     public event carEngineHandler Exploded;
    //     public event carEngineHandler AboutToBlow;

    //     public void Accelerate(int delta)
    //     {
    //         if(carIsDead)
    //         {
    //             if(Exploded != null)
    //             { Exploded("sorry, this car is dead..."); }
    //         }
    //         else
    //         {
    //             CurrentSpeed += delta;

    //             if(10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null)
    //             { AboutToBlow("Careful buddy! gonna blow!"); }
                
    //             if(CurrentSpeed >= MaxSpeed)
    //                 carIsDead = true;
    //             else
    //                 System.Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
    //         }
    //     }
    // }

    // class Car   // version 2
    // {
    //     public string PetName { get; set; }
    //     public int MaxSpeed { get; set; } = 0;
    //     public int CurrentSpeed { get; set; } = 0;
    //     private bool carIsDead = false;

    //     public Car(){}
    //     public Car(string n, int mSp, int cSp)
    //     { PetName = n; MaxSpeed = mSp; CurrentSpeed = cSp; }

    //     public override string ToString()
    //     => $"Name: {PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

    //     public delegate void carEngineHandler(string message);

    //     // this car can send these events
    //     public event carEngineHandler Exploded;
    //     public event carEngineHandler AboutToBlow;

    //     public void Accelerate(int delta)
    //     {
    //         if(carIsDead)
    //         {
    //             Exploded?.Invoke("sorry, this car is dead...");
    //         }
    //         else
    //         {
    //             CurrentSpeed += delta;

    //             if(10 == (MaxSpeed - CurrentSpeed))
    //             { AboutToBlow?.Invoke("Careful buddy! gonna blow!"); }
                
    //             if(CurrentSpeed >= MaxSpeed)
    //                 carIsDead = true;
    //             else
    //                 System.Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
    //         }
    //     }
    // }

    class CarEventArgs: EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        { msg = message; }
    }

    // class Car   // version 3
    // {
    //     public string PetName { get; set; }
    //     public int MaxSpeed { get; set; } = 0;
    //     public int CurrentSpeed { get; set; } = 0;
    //     private bool carIsDead = false;

    //     public Car(){}
    //     public Car(string n, int mSp, int cSp)
    //     { PetName = n; MaxSpeed = mSp; CurrentSpeed = cSp; }

    //     public override string ToString()
    //     => $"Name: {PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

    //     // public delegate void carEngineHandler(string message);
    //     public delegate void CarEngineHandler(object sender, CarEventArgs e);

    //     // this car can send these events
    //     public event carEngineHandler Exploded;
    //     public event carEngineHandler AboutToBlow;

    //     public void Accelerate(int delta)
    //     {
    //         if(carIsDead)
    //         {
    //             Exploded?.Invoke(this, new CarEventArgs("sorry, this car is dead..."));
    //         }
    //         else
    //         {
    //             CurrentSpeed += delta;

    //             if(10 == (MaxSpeed - CurrentSpeed))
    //             { AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! gonna blow!")); }
                
    //             if(CurrentSpeed >= MaxSpeed)
    //                 carIsDead = true;
    //             else
    //                 System.Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
    //         }
    //     }
    // }

    class Car   // version 4
    {
        public string PetName { get; set; }
        public int MaxSpeed { get; set; } = 0;
        public int CurrentSpeed { get; set; } = 0;
        private bool carIsDead = false;

        public Car(){}
        public Car(string n, int mSp, int cSp)
        { PetName = n; MaxSpeed = mSp; CurrentSpeed = cSp; }

        public override string ToString()
        => $"Name: {PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

        // public delegate void carEngineHandler(string message);
        // public delegate void CarEngineHandler(object sender, CarEventArgs e);

        // this car can send these events
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public void Accelerate(int delta)
        {
            if(carIsDead)
            {
                Exploded?.Invoke(this, new CarEventArgs("sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;

                if(10 == (MaxSpeed - CurrentSpeed))
                { AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! gonna blow!")); }
                
                if(CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    System.Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }

    class Program
    {
        static int Main(string[] args)
        {
            // Event
            {
                /*
                
                + situation
                    - using delegate, means working with delegates in the raw can entail the creation of some boilerplate code
                        - declare delegate type;
                        - define var with the delegate type;
                        - create custom register
                        - create custom unregister

                + note
                    - obviously, u would not want to give other applications the power to change what a delegate is pointing to
                    or to invoke the members w/o your permission;
                    - given this,it is common practice to declare "private" delegate member vars;

                + "event" kw
                    - as a shortcut, u don't have to build a custome methods to add or remove methods to a delegate's invocation list;
                
                + mechanism
                    - when compiler processes the "event" kw, u are automatically provided with "registration" and "unregistration" methods
                    - as well as any necessary member vars for your delegate types;

                    - these delegate member variables are ALWAYS declared private, therefore, they are NOT directly exposed from the object firing the evet;

                    >> to be sure, the "event" kw can be used to simplify how a custom class sends out notification to external objects;

                */

                // bad example by declare class delegate-type member var as "public"
                DelegateObjNoEncapsulation();
                // <-- see class Car version 1
            }

            // Events under the hood
            {
                /*
                
                + mechanism

                    - when compiler preccess "event" kw, it generates two hidden methods
                        -- add_prefix followed by the name of the "event", like add_XXX;
                        -- remove_prefix followed by the name of the "event", like remove_XXX;
                    
                            ```c# CIL code

                            .method public hidebysig specialname instance void
                            add_AboutToBlow(class CarEvent.Car/CarEngineHandler 'value') cil managed
                            {
                                ...
                                call class [mscorlib]System.Delegate
                                [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate, class [mscorlib]System.Delegate)

                                ...
                            }
                            remove_AboutToBlow(class CarEvent.Car/CarEngineHandler 'value') cil managed
                            {
                                ...
                                call class [mscorlib]System.Delegate
                                [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate, class [mscorlib]System.Delegate)
                                ...
                            }
                            ```

                        -- finally, the CIL code representing the event itself makes use of the .addon and .removeon directives to map the name of the correct
                        add_XXX() and remove_XXX() methods invoke;

                            ```c#
                            .event CarEvent.Car/EngineHandler AboutToBlow
                            {
                                .addon instance void CarEvents.Car::add_AboutToBlow
                                (class CarEvens.Car/CarEngineHandler)

                                .removeon instance void CarEvents.Car::remove_AboutToBlow
                                (class CarEvents.Car/CarEngineHandler)
                            }
                            ```
                    - Q: how to register or un register callback methods to listen to incoming events?
                        >> A: using += or -= operator;

                */ 
                FuckWithEvents();   
            }

            // using null-conditional member-access operator(?.)
            {
                /*
                
                + note
                    - h/e, it is still perfectly acceptable to manually do null checks
                
                */

                // see class Car version 2

            }

            // custom event args
            {
                /*
                
                + mirror MS recommended event patter
                    - what is it thou? `event delegateTypeName varName(object o, descendantOfSystem.EventArgs e);`
                    
                    >> object o, 1st arg, represents a reference to the obj that sent the event --> sender;
                    >> descendantOfSystem.EventArgs, 2nd arg, represents information regarding the event at hand;

                + System.EventArgs breakdown

                    ```c#

                    public class EventArgs
                    {
                        public static readonly EventArgs Empty;
                        public EventArgs();
                    }

                    ```

                + custom Event class derived from System.EventArgs
                    ```c#
                    
                    public class CarEventArgs: System.EventArgs
                    {
                        public readonly string msg;
                        public CarEventArgs(string message)
                        { msg = message; }
                    }
                    ```
                + update delegate type declaration and definition
            
                    ```c#

                    class Car
                    {
                        ...;

                        public delegate void CarEngineHandler(object sender, CarEventArgs e);


                        ...;
                    }

                    ``` 
                + update the corresponding methods of the delegate type;

                */ 

                // see class Car version 3
            }

            // generic EventHandler<T> delegate
            {
                /*
                
                + why
                    - given that so many custom delegates like the follow line, would u like to write event N times?
                        `access_modifier delegate returnType dTName(object sender, descendantOfSystem.EventArgs e);`
                    - no, just like function template, class template, meta-programming technique
                        using System.EventHandler<T> template;

                        >> <T> is your custom EventArgs descendant type;

                    - by using Event template, u no longer need to define custom delegate type at all;
                
                + example
                    ```c#

                    class Car
                    {
                        public event EventHandler<CarEventArgs> Exploded;
                        public event EventHandler<CarEventArgs> AboutToBlow;
                    }

                    ```
                */ 
                
                // see class Car version 4
                PrimAndProperEventHanderTemplate();
            }

            return 0;
        }

        private static void CallWhenExploded(string msg)
        { System.Console.WriteLine("CallWhenExploded: {0}", msg.ToUpper()); }

        private static void CallHereToo(string msg)
        { System.Console.WriteLine("CallHereToo: {0}", msg.ToUpper()); }
        static void DelegateObjNoEncapsulation()
        {
            System.Console.WriteLine("=> OOPS! No Encapsulation:");

            Car c1 = new Car();
            c1.myCarEngineHandler = new Car.carEngineHandler(CallWhenExploded);
            c1.Accelerate(10);

            // now assign to a whole new object...
            // confusing at best
            c1.myCarEngineHandler = new Car.carEngineHandler(CallHereToo);
            c1.Accelerate(10);

            // the caller can also directly invoke the delegate
            c1.myCarEngineHandler.Invoke("hee, heee, heeeee...");
            Console.ReadLine();
        }

        private static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        { 
            if(sender is Car c)
            { System.Console.WriteLine("{0} says: {1}", c, e.msg); }
        }
        private static void CarAboutToBlow(object sender, CarEventArgs e)
        { 
            if(sender is Car c)
            { System.Console.WriteLine("=>{0} says: {1}", c, e.msg); }
        }

        private static void CarExploded(string msg)
        {
            if(sender is Car c)
            { System.Console.WriteLine("=>{0} says: {1}", c.PetName, e.msg); }
        }

        static void FuckWithEvents()
        {
            System.Console.WriteLine("=> fuck with events:");

            Car c1 = new Car("ZL", 100, 10);

            // register event handlers
            c1.AboutToBlow += new Car.carEngineHandler(CarIsAlmostDoomed);
            c1.AboutToBlow += CarAboutToBlow;   // <-- using method group conversion to simplify register

            Car.carEngineHandler d = new Car.carEngineHandler(CarExploded);
            c1.Exploded += d;

            System.Console.WriteLine("\n***** Speeding Up *****");
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            Console.ReadLine();

            // remove or unregister
            c1.Exploded -= d;

            System.Console.WriteLine("\n***** Speeding Up *****");
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            Console.ReadLine();
        }
        
        static void PrimAndProperEventHanderTemplate()
        {
            System.Console.WriteLine("=> prim-and-proper System.EventHanlder<T>:");

            Car c1 = new Car("ZL", 100, 10);

            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploded);
            c1.Exploded += d;

            // ...;
        }
    }
}