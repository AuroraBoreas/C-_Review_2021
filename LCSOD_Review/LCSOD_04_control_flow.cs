using System;


// pattern: ncm?
namespace LCSOD_04_control_flow
{
    class Program
    {
        static bool isLeapYear(int year)
        { return (year%4 == 0 && year%100 != 0) || (year%400 == 0); }

        static int[] generateArray(int n)
        {
            if(n < 1)
            {
                throw new ArgumentException("n must be > 1");
            }

            Random rnd = new Random();
            int[] tmp = new int[n];

            int min = 0, max = 101;

            for(int i=0; i < n; ++i)
            {
                tmp[i] = rnd.Next(min, max);
            }

            return tmp;
        }

        static bool setDate(int ye, int mo, int da)
        {
            if(ye < 0) return false;
            if(mo < 1 || mo > 12) return false;
            if(da < 1 || da > 31) return false;
            switch(mo)
            {
                case 2: if(isLeapYear(ye))
                        {
                            if(da > 29)
                            { return false;}
                        }
                        else
                        {
                            if(da > 28)
                            { return false; }
                        }
                        break;
                
                case 4:
                case 6:
                case 9:
                case 11: if(da > 30){ return false; }
                         break;
            }

            return true;
        }

        static void Main(string[] args)
        {
            // if 
            {
                /*
                same concept in c++
                */
                int year = 2021;

                Console.Write("Leap Year? : ");
                if(isLeapYear(year))
                { Console.WriteLine("Yes"); }
                else
                { Console.Write("No"); }

                Console.ReadKey();
            }

            // ternary
            {
                string leapYear = (isLeapYear(year))? "Yes" : "No";
                Console.WriteLine($"is {year} leap year? : {leapYear}");

                Console.ReadKey();
            }

            // switch case
            {
                int year = 2021, month = 1, day = 25;
                Console.WriteLine($"setDate({year}, {month}, {day}) == {setDate(year, month, day)}");
            }

            // for loop
            {
                // same concept in c++
                int n = 10;
                int[] numbers = generateArray(n);
                
                for(int i=0; i < n; ++i)
                {
                    Console.WriteLine($"numbers[{i}] = {numbers[i]}");
                }
            }
            // foreach
            {
                int n = 10;
                int[] numbers = generateArray(n);
                
                foreach(int i in numbers)
                {
                    Console.WriteLine($"{i}");
                }
                
            }

            // while loop
            {
                // is equivalent to
                int n = 10;
                int[] numbers = generateArray(n);

                int i = 0;
                while(i < n)
                {
                    Console.WriteLine($"numbers[{i}] = {numbers[i]}");
                    ++i;
                }
            }

            // do while
            {
                // is equivalent to
                int n = 10;
                int[] numbers = generateArray(n);

                int i = 0;

                do
                {
                    Console.WriteLine($"numbers[{i}] = {numbers[i]}");
                    i++;
                } while(i < n);

            }
        }
    }
}