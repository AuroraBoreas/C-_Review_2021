using System;
using System.IO;
using System.Text;

namespace AbstractStreamClass
{
    class Program
    {
        static int Main(string[] args)
        {
            // P818
            {
                /*

                + concept of stream

                + definition: a stream represents a chunk of data flowing btwn a source and a destination;


                + why
                >> Streams provide a common way to interact with a "sequence of bytes", regardless of what kind of devices


                + note
                >> the concept of stream is NOT limited to file I/O,
                >> to be sure, the .NET libraries provide stream access in network, memory locations, and other stream-centric abstractions;


                + Abstract Stream members
                    - CanRead
                    - CanWrite
                    - CanSeek

                    - Close()
                    - Flush()

                    - Length
                    - Position

                    - Read()
                    - ReadByte()
                    - ReadAsync()

                    - Seek()

                    - SetLength()

                    - Write()
                    - WriteByte()
                    - WriteAsync()


                */
            }

            //
            {

            }

            return 0;
        }

        static void FuckWithFileStreams()
        {
            System.Console.WriteLine("***** fun with FileStream *****\n");

            using(FileStream fs = File.Open(@"myMessage.dat", FileMode.Create))
            {
                string msg = "hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                fs.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                fs.Position = 0;

                System.Console.WriteLine("Your message as an array of bytes:");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];

                for(int i=0; i<msgAsByteArray.Length; ++i)
                {
                    bytesFromFile[i] = (byte)fs.ReadByte();
                    System.Console.WriteLine(bytesFromFile[i]);
                }

                System.Console.WriteLine("\nDecoded Message: ");
                System.Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadLine();

        }


    }
}
