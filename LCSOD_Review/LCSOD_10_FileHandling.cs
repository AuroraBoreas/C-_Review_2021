using System;
using System.IO;

// pattern: ncm?
namespace LCSOD_10_FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // read
            {
                /*

                */

                string path = @"myFile.txt";
                if(File.Exists(path))
                {
                    using(StreamReader sr = new StreamReader(path))
                    {
                        while(sr.EndOfStream != true)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }

                        sr.Close();
                    }
                }
                else
                { Console.WriteLine("File Not Found!"); }

            }

            // write
            {
                string path = @"myFile2.txt";
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(@"hello world");
                    sw.WriteLine(@"春燕さんを乗りたい");
                    sw.WriteLine(@"c'est quoi, ton nome?");
                    sw.WriteLine(@"想干你，LL");

                    sw.Close();
                }
            }
        }
    }
}