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


                + note
                >> the major downfall of working directly with the FileStream type: it demands to operate o raw bytes;

                */
            }

            // StreamWriter, StreamReader
            {
                /*

                + when to use:
                StreamWrite and StreamReader classes are useful whenever u need to read or write character-based data(e.g., string);

                + note:
                both of them work by default with Unicode characters; u may change it;


                */
                FuckWithFileStreams();

            }

            // Reading from a Text file
            {
                /*

                + TextReader core members
                    - Peak()

                    - Read()
                    - ReadAsync()

                    - ReadBlock()
                    - ReadBlockAsync()

                    - ReadLine()
                    - ReadLineAsync()

                    - ReadToEnd()
                    - ReadToEndAsync()



                */
                // using File.Open()
                FuckWithStreamWriter();
                // using File.Open()
                FuckWithStreamWriter2();
                // using Directly creating StreamWriter/StreamReader types
                DirectlyCreatingStreamWriter_StreamReader();

                // confusing?
                /*

                + keep in mind that the end result is greater flexibility;

                */

            }

            // StringWriter, StringReader
            {
                /*

                + why
                >> u can use StringWriter and StringReader types to treat textual info as a stream of in-memory characters;
                >> this can prove helpful when u would like to append character-based info to an underlying buffer;

                */
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

        static void FuckWithStreamWriter()
        {
            System.Console.WriteLine("***** Fun with StreamWrite / StreamReader *****\n");

            using(StreamWriter sw = File.CreateText("reminders.txt"))
            {
                sw.WriteLine("Dont forget Mother's Day this year...");
                sw.WriteLine("Dont forget Father's Day this year...");
                sw.WriteLine("Dont forget these numbers: ");

                for(int i=0; i<10; ++i)
                    sw.WriteLine(i + " ");

                sw.WriteLine(sw.NewLine);
            }
            System.Console.WriteLine("Created file and wrote some thoughts....");
            Console.ReadLine();
        }

        static void FuckWithStreamWriter2()
        {
            System.Console.WriteLine("***** fun with StreamWrite / StreamReader *****\n");

            System.Console.WriteLine("here are your thoughts: \n");
            using(StreamReader sr = File.OpenText("reminders.txt"))
            {
                string input = null;
                while((input = sr.ReadLine()) != null)
                {
                    System.Console.WriteLine(input);
                }
            }
            Console.ReadLine();

        }

        static void DirectlyCreatingStreamWriter_StreamReader()
        {
            System.Console.WriteLine("***** fun with StreamWriter / StreamReader *****\n");

            using(StreamWriter sw = new StreamWriter(@"reminders.txt"))
            {}

            using(StreamReader sr = new StreamReader(@"reminders.txt"))
            {}
        }

    }
}
