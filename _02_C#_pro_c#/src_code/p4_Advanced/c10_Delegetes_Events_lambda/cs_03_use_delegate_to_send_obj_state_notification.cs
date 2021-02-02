using System;

namespace Use_Delegate_To_Send_Notification
{

    // public class Car    // version 0
    // {
    //     public int CurrentSpeed { get; set; }
    //     public int MaxSpeed { get; set; } = 100;
    //     public string PetName { get; set; }
        
    //     // is the car alive or dead?
    //     private bool carIsDead;

    //     // ctors
    //     public Car(){}
    //     public Car(string n, int maxSp, int currSp)
    //     {
    //         CurrentSpeed = currSp;
    //         MaxSpeed = maxSp;
    //         PetName = name;
    //     }
        
    // }

    // public class Car    // version 1
    // {
    //     public int CurrentSpeed { get; set; }
    //     public int MaxSpeed { get; set; } = 100;
    //     public string PetName { get; set; }
        
    //     // is the car alive or dead?
    //     private bool carIsDead;

    //     // ctors
    //     public Car(){}
    //     public Car(string n, int maxSp, int currSp)
    //     {
    //         CurrentSpeed = currSp;
    //         MaxSpeed = maxSp;
    //         PetName = name;
    //     }

    //     // 1) define a delegate type
    //     /*
    //     Notice in this example that you define the delegate types directly within the scope of the Car class,
    //     which is certainly not necessary 
    //     but does help enforce the idea that the delegate works naturally with this particular class
        
    //     */ 
    //     public delegate void CarEngineHandler(string msgForCaller);
    //     // 2) define a member var of this delegate
    //     private CarEngineHandler listOfHandler;
    //     // 3) add registration function for the caller
    //     public void RegisterWithCarEngine(CarEngineHandler methodToCall)
    //     {
    //         listOfHandler = methodToCall;
    //     }
    //     // 4) implement the Accelerate() method to invoke
    //     // the delegate's invocation list under the correct circumstances
    //     public void Accelerate(int delta)
    //     {
    //         // if this car is "dead", send dead msg
    //         if(carIsDead)
    //         {
    //             if(listOfHandler != null)
    //                 listOfHandler("sorry, this car is dead...");
    //         }
    //         else
    //         {
    //             CurrentSpeed += delta;
    //             // is this car almost "dead"?
    //             if(10 == (MaxSpeed - CurrentSpeed) && listOfHandler != null)
    //             { listOfHandler("careful buddy! gonna blow!"); }
    //             if(CurrentSpeed >= MaxSpeed)
    //                 carIsDead = true;
    //             else
    //                 System.Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
    //         }
    //     }   
    // }

    // public class Car    // version 2
    // {
    //     public int CurrentSpeed { get; set; }
    //     public int MaxSpeed { get; set; } = 100;
    //     public string PetName { get; set; }
        
    //     // is the car alive or dead?
    //     private bool carIsDead;

    //     // ctors
    //     public Car(){}
    //     public Car(string n, int maxSp, int currSp)
    //     {
    //         CurrentSpeed = currSp;
    //         MaxSpeed = maxSp;
    //         PetName = name;
    //     }

    //     // 1) define a delegate type
    //     /*
    //     Notice in this example that you define the delegate types directly within the scope of the Car class,
    //     which is certainly not necessary 
    //     but does help enforce the idea that the delegate works naturally with this particular class
        
    //     */ 
    //     public delegate void CarEngineHandler(string msgForCaller);
    //     // 2) define a member var of this delegate
    //     private CarEngineHandler listOfHandler;
    //     // 3) add registration function for the caller
    //     public void RegisterWithCarEngine(CarEngineHandler methodToCall)
    //     {
    //         listOfHandler += methodToCall;
    //     }
    //     // 4) implement the Accelerate() method to invoke
    //     // the delegate's invocation list under the correct circumstances
    //     public void Accelerate(int delta)
    //     {
    //         // if this car is "dead", send dead msg
    //         if(carIsDead)
    //         {
    //             if(listOfHandler != null)
    //                 listOfHandler("sorry, this car is dead...");
    //         }
    //         else
    //         {
    //             CurrentSpeed += delta;
    //             // is this car almost "dead"?
    //             if(10 == (MaxSpeed - CurrentSpeed) && listOfHandler != null)
    //             { listOfHandler("careful buddy! gonna blow!"); }
    //             if(CurrentSpeed >= MaxSpeed)
    //                 carIsDead = true;
    //             else
    //                 System.Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
    //         }
    //     }   
    // }
    public class Car    // version 3
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        
        // is the car alive or dead?
        private bool carIsDead;

        // ctors
        public Car(){}
        public Car(string n, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // 1) define a delegate type
        /*
        Notice in this example that you define the delegate types directly within the scope of the Car class,
        which is certainly not necessary 
        but does help enforce the idea that the delegate works naturally with this particular class
        
        */ 
        public delegate void CarEngineHandler(string msgForCaller);
        // 2) define a member var of this delegate
        private CarEngineHandler listOfHandler;
        // 3) add registration function for the caller
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandler += methodToCall;
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandler -= methodToCall;
        }
        // 4) implement the Accelerate() method to invoke
        // the delegate's invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            // if this car is "dead", send dead msg
            if(carIsDead)
            {
                if(listOfHandler != null)
                    listOfHandler("sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // is this car almost "dead"?
                if(10 == (MaxSpeed - CurrentSpeed) && listOfHandler != null)
                { listOfHandler("careful buddy! gonna blow!"); }
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
            // Send object state notification using Delegates, P426
            {
                DelegateAsEventEnables();
            }

            // enable multicasting
            {
                /*
                
                + mechanism
                    - as u know, a delegate obj has a list to store numerous approporiate methods(pointer);
                    - thus, u may use this ability to do multicast
                

                */ 
                DelegateMulticast();

            }

            // remove targets from a delegate's invocation list
            {
                DelegateAsEventEnables_remove();
            }

            // method group conversion
            {
                /*
                
                + why: directly allocating delegate obj, whose register statement is long and ugly
                    ```c#
                    
                    T FuncName(T... args) {...};

                    delegate T delegateTypeName<U, V, W..., T>;
                    delegateTypeName dtn = new delegateTypeName(FuncName);

                    ```
                + method group conversion: rather simply specifying method
                    ```c#
                   
                    T FuncName(T... args) {...};

                    delegate T delegateTypeName<U, V, W..., T>;
                    delegateTypeName dtn = FuncName;    // <-- C++ style

                    ```
                
                */ 

                MethodGroupConversion();
            }

            

            return 0;
        }

        private static void OnCarEngineEvent(string msg)
        {
            System.Console.WriteLine("\n***** message from Car object *****");
            System.Console.WriteLine("=> {0}", msg);
            System.Console.WriteLine("************************************\n");
        }
        static void DelegateAsEventEnables()
        {
            Car c1 = new Car("SlugBug", 100, 10);
            
            // now, tell the car which method to call when it wnats to send us msg
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            // speed up
            System.Console.WriteLine("***** speed up *****");
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            
            Console.ReadLine();
        }

        private static void OnCarEngineEvent2(string msg) 
        { System.Console.WriteLine(msg.ToUpper()); }
        
        static void DelegateMulticast()
        {
            System.Console.WriteLine("=> multicast:");

            Car c1 = new Car("XY", 100, 10);

            // register
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));
            
            // speed up
            System.Console.WriteLine("***** Speed Up*****");
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        static void DelegateAsEventEnables_remove()
        {
            System.Console.WriteLine("=> delegate as event enablers: remove");

            Car c1 = new Car("ZL", 100, 10);
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            Car.CarEngineHandler hanlder2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(hanlder2);

            // speed up
            System.Console.WriteLine("***** Speed Up*****");
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            Console.ReadLine();
            
            // unregister from the second handler
            c1.UnRegisterWithCarEngine(hanlder2);
            // speed up
            System.Console.WriteLine("***** Speed Up*****");
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);

            Console.ReadLine();
        }

        private static void CallMeHere(string msg)
        { System.Console.WriteLine("=> message from Car: {0}", msg); }

        static void MethodGroupConversion()
        {
            System.Console.WriteLine("=> Method Group Conversion:");

            Car c1 = new Car("XY", 100, 10);
            c1.RegisterWithCarEngine(CallMeHere);
            System.Console.WriteLine("*****Speed Up*****");            
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);
            c1.UnRegisterWithCarEngine(CallMeHere);
            // no more notification!
            for(int i=0; i<6; ++i)
                c1.Accelerate(20);

            Console.ReadLine();
        }

        
    }
}