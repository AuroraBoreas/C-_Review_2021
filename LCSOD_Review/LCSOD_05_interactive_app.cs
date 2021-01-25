using System;


// pattern: ncm?
namespace LCSOD_05_interactive_app
{
    class Program
    {
        static void Main(string[] args)
        {
            // guess game
            {
                /*
                + parsers:
                    - using Int32.Parse(obj);
                    - using Convert.ToInt32(obj);

                */
                Random rnd = new Random();
                int secret = rnd.Next(1, 101);

                int cnt = 0;
                int user_integer;
                string msg = "\nWelcome to guess game!",
                       prompt = "\nEnter an integer btwn(1, 100) : ";
                
                string tmp;

                do
                {
                    tmp = Console.ReadLine();
                    user_integer = Convert.ToInt32(tmp);
                    if(user_integer < secret)
                    { Console.WriteLine("too low"); }
                    else if(user_integer > secret)
                    { Console.WriteLine("too high"); }
                    else
                    { break; }
                    cnt++;

                } while (user_integer != secret);

                Console.WriteLine($"You successed! you guessed {cnt} times, the number is {secret}");

            }
        }
    }
}