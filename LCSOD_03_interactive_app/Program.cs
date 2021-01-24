using System;

namespace LCSOD_03_interactive_app
{
    class Program
    {
        static void Main(string[] args)
        {
            // interactive app
            {
                /*
                + what: interact with user
                + why: why not?
                + how: io
                    - Console.Read();
                    - Console.ReadLine();
                    - Console.ReadKey();
                    
                    - Console.Write();
                    - Console.WriteLine();

                */

                Console.WriteLine("\nLet's play a guess game");
                int cnt = 0;
                int user_input;

                // initialize a Random obj
                int min = 1, max = 100;
                Random rnd = new Random();
                int secret = rnd.Next(min, max+1);

                do
                {
                    Console.Write("\nEnter your guess number(1-100): ");
                    //user_input = Int32.Parse(Console.ReadLine());
                    // or
                    user_input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(user_input);
                    cnt++;

                    Console.WriteLine();
                    if(user_input < secret)
                    { Console.WriteLine("too low"); }
                    else if(user_input > secret)
                    { Console.WriteLine("too high");  }
                    else
                    { break; }

                } while (user_input != secret);

                Console.WriteLine($"You guessed {cnt} times; secret is {secret}.");

            }
        }
    }
}
