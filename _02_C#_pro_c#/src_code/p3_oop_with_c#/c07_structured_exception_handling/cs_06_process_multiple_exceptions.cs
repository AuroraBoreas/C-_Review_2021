using System;

namespace Multiple_Exceptions
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            System.Console.WriteLine(on? "Jamming...": "Quiet time...");
        }
    }

    class CarIsDeadException: ApplicationException  // version 2
    {
        // private string messageDetails = string.Empty;
        public DateTime ErrorTimeStamp{get; set;}
        public string CauseOfError { get; set; }
        
        public CarIsDeadException(){}
        public CarIsDeadException(string msg): base(msg){}
        public CarIsDeadException(string msg, System.Exception inner): base(msg, inner){}


        public CarIsDeadException(string msg, string cause, DateTime time)
        : base(msg)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // to make [Serializable]
        protected CarIsDeadException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        : base(info, context){}

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
            // test arg before processing
            if(delta < 0)
            { throw new ArgumentException("delta", "Speed MUST be > 0!"); }

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

    class Program
    {

        static int Main(string[] args)
        {
            // Multiple Exception Processing, P332
            {
                /*
                
                + the rule of thumb, always keep in mind
                    - make sure your catch blocks are structured such that the first catch is the most specific excpetion;
                    - leaving the final catch for the most general;
                      just like: .oO0O

                
                */ 
                HandleMultipleException();
            }

            // General catch statement
            {
                HandleMultipleException2();

            }

            // rethrow Exceptions, P334
            {
                // same concept in c++
                HandleMultipleException3();
            }

            // inner Exception
            {

            }

            return 0;
        }

        static void HandleMultipleException()
        {
            System.Console.WriteLine("=> Creating a car and stepping on it!");

            Car myCar = new Car("ZL", 20);
            myCar.CrankTunes(true);
            
            try
            {
                // for(int i=0; i<10; ++i)
                // {
                //     myCar.Accelerate(10);
                // }
                myCar.Accelerate(-10);
                Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                System.Console.WriteLine(ex.Message);
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
                //  System.Console.WriteLine($"-> {de.Key}: {de.Value}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }

        static void HandleMultipleException2()
        {
            System.Console.WriteLine("=> handling multiple exceptions:");
            Car myCar = new Car("xy", 90);

            try
            {
                myCar.Accelerate(90);
            }
            catch
            {
                System.Console.WriteLine("Something wrong happened...");
            }

            Console.ReadLine();
            
        }
        static void HandleMultipleException3()
        {
            System.Console.WriteLine("=> handling multiple exceptions:");
            Car myCar = new Car("xy", 90);

            try
            {
                myCar.Accelerate(90);
            }
            catch
            {
                System.Console.WriteLine("Something wrong happened...");
                throw;
            }

            Console.ReadLine();
            
        }

    }
}