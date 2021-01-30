using System;

namespace Application_Level_Exception
{

    class Radio
    {
        public void TurnOn(bool on)
        {
            System.Console.WriteLine(on? "Jamming...": "Quiet time...");
        }
    }

    // class CarIsDeadException: ApplicationException  // version 0
    // {
    //     private string messageDetails = string.Empty;
    //     public DateTime ErrorTimeStamp{get; set;}
    //     public string CauseOfError { get; set; }
        
    //     public CarIsDeadException(){}
    //     public CarIsDeadException(string msg, string cause, DateTime time)
    //     {
    //         messageDetails = msg;
    //         CauseOfError = cause;
    //         ErrorTimeStamp = time;
    //     }

    //     // override Exception.Message props
    //     public override string Message => $"Car Error Message: {messageDetails}";
        
    // }
    class CarIsDeadException: ApplicationException  // version 1
    {
        // private string messageDetails = string.Empty;
        public DateTime ErrorTimeStamp{get; set;}
        public string CauseOfError { get; set; }
        
        public CarIsDeadException(){}
        public CarIsDeadException(string msg, string cause, DateTime time)
        : base(msg)
        {
            messageDetails = msg;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // override Exception.Message props
        // public override string Message => $"Car Error Message: {messageDetails}";
        
    }

    class Car   // version 4
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
                    Exception e = new CarIsDeadException($"{PetName} has overheated!", "U have a lead foot", DateTime.Now);
                    e.HelpLink = "https://github.com/AuroraBoreas";

                    // custom data regarding the errorAA
                    // e.Data.Add("TimeStamp", $"The car exploded  at {DateTime.Now}");
                    // e.Data.Add("Cause", "You have a lead foot");

                    throw e;
                }
                else
                {
                    System.Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
                }
            }
        }

    }

    class Porgram
    {

        static int Main(string[] args)
        {
            // System.ApplicationException, Take 1, P325
            {
                /*
                
                + custom your own Exception
                    - derive from System.Exception; OK
                    - derive from System.ApplicationException; YES
                
                + purpose
                    - functionally, the only purpose of System.AppliationException is to 
                      identify the source of the error;
                    - u can assume the exception was raised by the codebase of the executing application, rather than by the .NET base class libraries runtime engine
                
                */

                SimpleExceptionExample_custom_exception();
            }

            // System.ApplicationException, Take 2, P328
            {
                // irl, u don't override Message prop
                // rather than passing it to base class: ApplicationException

                /*
                + why?

                  - many times, cutom Exception class is NOT necessarily to provide additional functionality beyond what is inherited from the   
                    base classes, BUT to supply a "strongly named type" that crystal-clearly identifies the nature of the error;

                  - then client can provide different handler logic for different types of exceptions;
                
                */                

            }

            // System.ApplicationException, Take 3, P329
            {
                /*
                
                
                
                */ 

            }

            return 0;
        }

        static void SimpleExceptionExample_custom_exception()
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
            catch (CarIsDeadException ex)
            {
                 System.Console.WriteLine("\n*** Error! ***");
                 System.Console.WriteLine($"Message: {ex.Message}\n");
                 System.Console.WriteLine($"Time: {ex.ErrorTimeStamp}\n");
                 System.Console.WriteLine($"Cause: {ex.CauseOfError}\n");

                 // display Exception.Data
                //  System.Console.WriteLine("\n=> custom Data:");
                //  foreach(System.Collections.DictionaryEntry de in ex.Data)
                //     System.Console.WriteLine($"-> {de.Key}: {de.Value}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }





    }
}