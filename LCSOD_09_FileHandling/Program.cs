using System;
using System.IO;

namespace LCSOD_09_FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read
            {
                /*
                 
                + namespace: System.IO;
                + class: StreamReader
                + methods: are similar with fstream in C++
                + raw: R"..." in C++
                       @"..." in C#
                + check if file exists:
                    - using try...catch...
                    - using File.Exists(path)
                
                + encoding?

                 */
                string path = @"C:\Users\Aurora_Boreas\source\repos\LCSOD_09_FileHandling\myFile.txt";
                
                if(File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                        sr.Close();
                    };
                }
                else
                { Console.WriteLine("File not found!"); }

            }

            // Write
            {
                string path = @"C:\Users\Aurora_Boreas\source\repos\LCSOD_09_FileHandling\myFile02.txt";
                using (StreamWriter sw = new StreamWriter(path))
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
