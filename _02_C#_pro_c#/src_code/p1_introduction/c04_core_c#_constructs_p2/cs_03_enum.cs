using System;

namespace Enum_Type
{

    class Program
    {
        public static void Main(string[] args)
        {
            // enum type
            {
                /*
                
                + notes:
                    - it is not necessary to start from 0
                    - it is not necessary to be sequential
                    - it is not necessary to be int32 type, it can be byte, short, int or long

                + name-value pairs
                    - to get name is easy 
                    - to get value, just needs to cast name againts its underlying storage type

                + System.Enum defines a static method GetValues()
                    - it returns an instance of System.Array
                    - each item in the array corresponding to a member of the specified enumeration

                + side note:
                    - when u make use of any enum, always remember that u are able to interact with the name-value pairs using the members of System.Enum
                    - but how?
                    - upcasting your enum to System.Enum
                      i.e, System.Enum e = EmpType.Manager;


                */ 

                FuckWithEnum();
                Console.ReadLine();

                // get enum name-value pair
                FuckWithEnum_pair();

                // System.Enum provides a finer Format() methods
                EvaluateEnumDemo();

                Console.ReadLine();
                
            }
        }


        enum EmpType
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 101,
            VicePresident = 9
        }

        enum EmpBType: byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }

        private static void AskForBonus(EmpType e)
        {
            switch(e)
            {
                case EmpType.Manager:
                    System.Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    System.Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    System.Console.WriteLine("You alrdy have enough cash...");
                    break;
                case EmpType.VicePresident:
                    System.Console.WriteLine("very good, sir!");
                    break;
            }
        }

        private static void FuckWithEnum()
        {
            System.Console.WriteLine("***** Fuck With Enums *****");

            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            System.Console.WriteLine($"EmpType uses a {emp.GetType()} for storage");
        }

        private static void FuckWithEnum_pair()
        {
            System.Console.WriteLine("***** Fuck With Enums *****");

            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            System.Console.WriteLine($"{emp.ToString()} = {(int)emp}");
        }

        enum DaysOfWeek
        {
            Mon,
            Tue,
            Wed,
            Thu,
            Fri,
            Sat,
            Sun,
        }

        private static void EvaluateEnum(System.Enum e)
        {
            // GetType().Name
            System.Console.WriteLine("=> Information about {0}", e.GetType().Name);
            // GetUnderlyingType()
            System.Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));
            // get all name-value pairs
            Array enumData = Enum.GetValues(e.GetType());
            System.Console.WriteLine("This enum has {0} members.", enumData.Length);

            // repr
            for(int i=0; i<enumData.Length; ++i)
            {
                System.Console.WriteLine("name: {0}, value: {0:D}", enumData.GetValue(i));
            }
            System.Console.WriteLine();
        }

        private static void EvaluateEnumDemo()
        {
            EmpType e2 = EmpType.Contractor;
            DaysOfWeek day = DaysOfWeek.Mon;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);
        }


    }
}