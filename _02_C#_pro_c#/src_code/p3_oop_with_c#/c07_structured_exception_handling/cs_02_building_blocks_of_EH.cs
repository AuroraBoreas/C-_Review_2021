using System;

namespace EH_Blocks
{

    class Radio
    {
        public void TurnOn(bool on)
        {
            System.Console.WriteLine(on? "Jamming...": "Quiet time...");
        }
    }

    // class Car   // version 0
    // {
    //     public const int MaxSpeed = 100;
    //     public int CurrentSpeed { get; set; } = 0;
    //     public string PetName { get; set; } = "";
    //     private bool carIsDead;
    //     private Radio theMusicBox = new Radio();
    //     public Car(){}
    //     public Car(string name, int speed)
    //     { 
    //         CurrentSpeed = speed; 
    //         PetName = name;
    //     }

    //     public void CrankTunes(bool state)
    //     {
    //         theMusicBox.TurnOn(state);
    //     }

    //     public void Accelerate(int delta)
    //     {
    //         if(carIsDead)
    //         { System.Console.WriteLine($"{PetName} is out of order.."); }
    //         else
    //         {
    //             CurrentSpeed += delta;
    //             if(CurrentSpeed > MaxSpeed)
    //             {
    //                 System.Console.WriteLine($"{PetName} has overheated!");
    //                 CurrentSpeed = 0;
    //                 carIsDead = true;
    //             }
    //             else
    //             {
    //                 System.Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
    //             }
    //         }
    //     }

    // }
    class Car   // version 1
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        private bool carIsDead;
        private Radio theMusicBox = new Radio();
        public Car(){}
        public Car(string name, int speed)
        { 
            CurrentSpeed = speed; 
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if(carIsDead)
            { System.Console.WriteLine($"{PetName} is out of order.."); }
            else
            {
                CurrentSpeed += delta;
                if(CurrentSpeed >= MaxSpeed)
                {
                    // System.Console.WriteLine($"{PetName} has overheated!");
                    CurrentSpeed = 0;
                    carIsDead = true;
                    throw new Exception($"{PetName} has overheated!");
                }
                else
                {
                    System.Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
                }
            }
        }

    }


    class Program
    {
        static int Main(string[] args)
        {

            // .NET Exception cls
            {
                /*
                
                + definition

                    ```c#
                    namespace System
                    {
                        public class Exception
                        {
                            public Exception(string message, Exception innerException);
                            public Exception(string message);
                            public Exception();

                            public virtual Exception GetBaseException();
                            public virtual void GotObjectData(SerializationInfo info,
                                                                StreamingContext context);

                            public virtual IDictionary Data { get; }
                            public virtual string HelpLink {get; set; }
                            public Exception InnerException{get;}
                            public virtual string Message{get;}
                            public virtual string Source{get; set;}
                            public virtual string StackTrace{get; set;}
                            public MethodBase TargetSite{get;}
                        } 
                    }
                    ```
                
                + core members
                    - Data             retrieve IDictionary key-value pairs that provide 
                                    additional, programmer-defined info about exeption;
                                    by default, it is empty

                    - HelpLink         get or set a helpful URL describing error in full detail

                    - InnerException   obtain info about previous exception that caused 
                                    current exception

                    - Message          return textual description of a given error

                    - Source           get or set who(assembly? object?) throws the current
                                    exception

                    - StackTrace       contains a string that identifies the seq of calls that 
                                    triggered the exception

                    - TargetSite       return a MethodBase obj, which describes numerous details
                                    about  the method that threw the exception     

                */
                // throw new Exceptions("msg");
                SimpleExceptionExample();
            }

            // try...catch...
            {
                SimpleExceptionExample_try_catch();
            }


            return 0;
        }

        static void SimpleExceptionExample()
        {
            System.Console.WriteLine("=> Creating a car and stepping on it!");

            Car myCar = new Car("XY", 20);
            myCar.CrankTunes(true);
            
            for(int i=0; i<10; ++i)
            {
                myCar.Accelerate(10);
            }
            Console.ReadLine();
        }

        static void SimpleExceptionExample_try_catch()
        {
            System.Console.WriteLine("=> Creating a car and stepping on it!");

            Car myCar = new Car("ZL", 20);
            myCar.CrankTunes(true);
            
            try
            {
                for(int i=0; i<10; ++i)
                {
                    myCar.Accelerate(10);
                }
                Console.ReadLine();
            }
            catch (System.Exception ex)
            {
                 System.Console.WriteLine("\n*** Error! ***");
                 System.Console.WriteLine($"Method: {ex.TargetSite}");
                 System.Console.WriteLine($"Method: {ex.Message}");
                 System.Console.WriteLine($"Method: {ex.Source}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }

    }
}