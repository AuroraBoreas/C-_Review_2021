using System;

namespace Multiple_Exceptions
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            System.Console.WriteLine(on ? "Jamming..." : "Quiet time...");
        }
    }

    class CarIsDeadException : ApplicationException  // version 2
    {
        // private string messageDetails = string.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string msg) : base(msg) { }
        public CarIsDeadException(string msg, System.Exception inner) : base(msg, inner) { }


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
        : base(info, context) { }

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
        public Car() { }
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
            if (delta < 0)
            { throw new ArgumentException("delta", "Speed MUST be > 0!"); }

            if (carIsDead)
            { System.Console.WriteLine($"{PetName} is out of order.."); }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
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
                /*
                
                pre-condition: when u encounter an exception while processing another exception
                
                + bast practice
                    - u should record the new exception obj as an "inner exception" wthin a new obj of the same type as the initial exception;
                
                + reason
                    - u need to allocate a new obj of the exception bing handled is that the only way to document an inner exception is via a constructor parameter;
                
                */
                HandleMultipleException4_inner_exception();
                HandleMultipleException5_inner_exception();
            }

            // finally block
            {
                // same concept in Python
                HandleMultipleException5_finally_block();
            }

            // exception filter, when kw
            {
                /*

                + mechanism
                    - when keyword gives u the ability to ensure that the statements within a catch block are executed only if some condition in your code holds true;
                
                */
                HandleMultipleException6_when_kw();
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
            catch (ArgumentException ex)
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
        static void HandleMultipleException4_inner_exception()
        {
            System.Console.WriteLine("=> handling multiple exceptions:");
            Car myCar = new Car("xy", 90);

            try
            {
                myCar.Accelerate(90);
            }
            catch (CarIsDeadException e)
            {
                // if FileNotFound Error; this statement gonna throw exception
                System.IO.FileStream fs = System.IO.File.Open(@"C:\carError.txt", System.IO.FileMode.Open);
            }
            catch
            {
                System.Console.WriteLine("Something wrong happened...");
                throw;
            }

            Console.ReadLine();

        }

        static void HandleMultipleException5_inner_exception()
        {
            System.Console.WriteLine("=> handling multiple exceptions:");
            Car myCar = new Car("xy", 90);

            try
            {
                myCar.Accelerate(90);
            }
            catch (CarIsDeadException e)
            {
                try
                {
                    // if FileNotFound Error; this statement gonna throw exception
                    System.IO.FileStream fs = System.IO.File.Open(@"C:\carError.txt", System.IO.FileMode.Open);
                }
                catch (Exception e2)
                {
                    // throw an exception that records the new exception
                    // as well as the message of the first exception
                    throw new CarIsDeadException(e.Message, e2);
                }
            }
            catch
            {
                System.Console.WriteLine("Something wrong happened...");
                throw;
            }

            Console.ReadLine();

        }

        static void HandleMultipleException5_finally_block()
        {
            System.Console.WriteLine("=> handling multiple exceptions:");
            Car myCar = new Car("xy", 90);

            try
            {
                myCar.Accelerate(90);
            }
            catch (CarIsDeadException e)
            {
                try
                {
                    // if FileNotFound Error; this statement gonna throw exception
                    System.IO.FileStream fs = System.IO.File.Open(@"C:\carError.txt", System.IO.FileMode.Open);
                }
                catch (Exception e2)
                {
                    // throw an exception that records the new exception
                    // as well as the message of the first exception
                    throw new CarIsDeadException(e.Message, e2);
                }
            }
            catch (ArgumentException e)
            {
                // ...;
                throw;
            }
            catch
            {
                System.Console.WriteLine("Something wrong happened...");
                throw;
            }
            finally
            {
                // this will always occur no matter exception or not
                myCar.CrankTunes(false);

            }

            Console.ReadLine();

        }

        static void HandleMultipleException6_when_kw()
        {
            System.Console.WriteLine("=> handling multiple exceptions:");
            Car myCar = new Car("xy", 90);

            try
            {
                myCar.Accelerate(90);
            }
            catch (CarIsDeadException e) when (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                try
                {
                    // if FileNotFound Error; this statement gonna throw exception
                    System.IO.FileStream fs = System.IO.File.Open(@"C:\carError.txt", System.IO.FileMode.Open);
                }
                catch (Exception e2)
                {
                    // throw an exception that records the new exception
                    // as well as the message of the first exception
                    throw new CarIsDeadException(e.Message, e2);
                }
            }
            catch (ArgumentException e)
            {
                // ...;
                throw;
            }
            catch
            {
                System.Console.WriteLine("Something wrong happened...");
                throw;
            }
            finally
            {
                // this will always occur no matter exception or not
                myCar.CrankTunes(false);

            }

            Console.ReadLine();

        }

    }
}