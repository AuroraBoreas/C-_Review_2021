using System;

namespace Configure_Exception
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            System.Console.WriteLine(on? "Jamming...": "Quiet time...");
        }
    }

    // class Car   // version 1
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
    //             if(CurrentSpeed >= MaxSpeed)
    //             {
    //                 // System.Console.WriteLine($"{PetName} has overheated!");
    //                 CurrentSpeed = 0;
    //                 carIsDead = true;
    //                 throw new Exception($"{PetName} has overheated!");
    //             }
    //             else
    //             {
    //                 System.Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
    //             }
    //         }
    //     }

    // }
    // class Car   // version 2
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
    //             if(CurrentSpeed >= MaxSpeed)
    //             {
    //                 // System.Console.WriteLine($"{PetName} has overheated!");
    //                 CurrentSpeed = 0;
    //                 carIsDead = true;
    //                 Exception e = new Exception($"{PetName} has overheated!");
    //                 e.HelpLink = "https://github.com/AuroraBoreas";
    //                 throw e;
    //             }
    //             else
    //             {
    //                 System.Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
    //             }
    //         }
    //     }

    // }
    class Car   // version 3
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
                    Exception e = new Exception($"{PetName} has overheated!");
                    e.HelpLink = "https://github.com/AuroraBoreas";

                    // custom data regarding the error
                    e.Data.Add("TimeStamp", $"The car exploded  at {DateTime.Now}");
                    e.Data.Add("Cause", "You have a lead foot");

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
            // Exception.TargetSite props
            {
                SimpleExceptionExample_TargetSite();
            }

            // Exception.StackTrace prop
            {
                SimpleExceptionExample_StackTrace();
            }

            // Exception.HelpLink prop
            {
                SimpleExceptionExample_HelpLink();
            }

            // Exception.Data prop
            {
                SimpleExceptionExample_Data();
            }

            return 0;
        }

        static void SimpleExceptionExample_TargetSite()
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
                 System.Console.WriteLine($"Method: {ex.TargetSite.DeclaringType}");
                 System.Console.WriteLine($"Method: {ex.TargetSite.MemberType}");
                 System.Console.WriteLine($"Method: {ex.Message}");
                 System.Console.WriteLine($"Method: {ex.Source}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }
        static void SimpleExceptionExample_StackTrace()
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
                 System.Console.WriteLine($"Stack: {ex.StackTrace}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }
        static void SimpleExceptionExample_HelpLink()
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
                 System.Console.WriteLine($"HelpLink: {ex.HelpLink}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }
        static void SimpleExceptionExample_Data()
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
                 System.Console.WriteLine($"HelpLink: {ex.HelpLink}\n");

                 // display Exception.Data
                 System.Console.WriteLine("\n=> custom Data:");
                 foreach(System.Collections.DictionaryEntry de in ex.Data)
                    System.Console.WriteLine($"-> {de.Key}: {de.Value}");
            }

            System.Console.WriteLine("*** Out of Exceptions logic");
            Console.ReadLine();
        }
    }
}