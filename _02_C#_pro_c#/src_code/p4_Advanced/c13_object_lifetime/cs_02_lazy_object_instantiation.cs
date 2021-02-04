using System;

namespace LazyObjectInstantiations
{

    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }

    class AllTracks
    {
        // very big src
        private Song[] allSongs = new Song[10000];

        public AllTracks()
        {
            // ...;
            // fill up the array
            System.Console.WriteLine("Filling up the songs!");
        }
    }

    // class MediaPlayer    // version 0
    // {
    //     public void Play() { /*Play a song*/ }
    //     public void Pause() { /*Pause a song*/ }
    //     public void Stop() { /*Stop a song*/ }
    //     private AllTracks allSongs = new AllTracks();

    //     public AllTracks GetAllTracks()
    //     {
    //         return allSongs;
    //     }
    // }

    // class MediaPlayer   // version 1
    // {
    //     public void Play() { /*Play a song*/ }
    //     public void Pause() { /*Pause a song*/ }
    //     public void Stop() { /*Stop a song*/ }
    //     private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();

    //     public AllTracks GetAllTracks()
    //     {
    //         return allSongs.Value;
    //     }
    // }

    class MediaPlayer   // version 2
    {
        public void Play() { /*Play a song*/ }
        public void Pause() { /*Pause a song*/ }
        public void Stop() { /*Stop a song*/ }
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(()=>{
            System.Console.WriteLine("Creating AllTracks object!");
            return new AllTracks(); // <-- this method MUST return a new instance of the type wrapped by Lazy() before exiting, and u can use any ctor u choose;
        });

        public AllTracks GetAllTracks()
        {
            return allSongs.Value;
        }
    }


    class Program
    {
        static int Main(string[] args)
        {
            // Lazy<>
            {
                /*
                
                + why?
                    - Lazy<> allows u to define data that will NOT be created unless your codebase actually use it;
                    >> it is similar with "singleton" concept in C++;
                
                
                */ 

                // see class MediaPlayer version 0
                // see class MediaPlayer version 1

            }

            // custom the creation of the Lazy<> data, P557
            {
                /*
                
                + Lazy() class can be really flexible
                    - allows u to specify a generic delegate as an optional params
                    >> which will specify a method to call during the creation of the warpped type;
                
                
                
                + essence of general class Lazy<>
                    - allows u to ensure expensive objects are allocated only when the object user requires them;
                
                */ 
                // see class MediaPlayer version 2

            }

            return 0;
        }

        static void FuckWithLazyInstantiation()
        {
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();

            System.Console.ReadLine();
        }
        
    }
}