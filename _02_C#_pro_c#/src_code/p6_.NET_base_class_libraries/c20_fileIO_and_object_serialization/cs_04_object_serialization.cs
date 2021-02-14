using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace ObjectSerialization
{

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XY-ZL522RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar: Car
    {
        public bool canFly;
        public bool canSubMerge;
    }


    class Program
    {
        static int Main(string[] args)
        {
            // manual serialization, P829
            {
                /*

                + note
                    - BinaryFormatter persists state data in a binary format;

                */

                WorkWithSerialization_UserPrefs();

            }

            // configure objects for serialization, P831
            {
                /*

                + how
                    >> all u need to do is decorate each related class(or struct) with [Serializable] attribute;

                    >> if u determine that a given type has some member data that should NOT(or can NOT) participate in the seriliaztion scheme, u can mark such fields with [NonSerialized] attribute;


                */

                // see class Radio, Car, JamesBondCar
            }

            // choose a Serialization Formatter, P834
            {
                /*

                + possibility is represented by the following
                    - BinaryFormatter;
                    - SoapFormatter;
                    - XmlSerializer

                + note
                    - all of them derive directly from System.Object;
                    - they do NOT share a common set of members from a serialization-centric base class;
                    - BinaryFormatter and SoapFormatter implement IFormatter and IRemotingFormatter interface;
                    - XmlSerializer implements neither;


                + System.Runtime.Serialization.IFormatter
                    - Serialize()
                    - Deserialize()

                    ```c#

                    public interface IFormatter
                    {
                        SerializationBinder Binder { get; set; }
                        StreamingContext Context { get; set; }
                        ISurrogateSelector SurrogateSelector { get; set; }
                        object Deserialize(Stream serializationStream);
                        void Serialize(Stream serilizationStream, object graph);
                    }


                    ```

                */
            }

            // using BinaryFormatter
            {
                FuckWithObjectSerialization_Serialize();
                FuckWithObjectSerialization_Deserialize(@"CarData.dat");
            }

            // using SoapFormatter
            {
                // see SaveAsSoapFormat();
            }

            // using XmlSerializer
            {
                // see SaveAsXmlFormat();
            }

            // serialize collections of obje
            {

            }


            // customize Soap/Binary Serialization Process
            {
                /*

                + core types of System.Runtime.Serialization

                    - ISerializable
                    - ObjectIDGenerator

                    - [OnDeserialized]
                    - [OnDeserializing]

                    - [OnSerialized]
                    - [OnSerializing]

                    - [OptionalField]

                    - [SerializationInfo]


                + a deeper look at object serialization
                    1> the fully qualified name of the objects in the graph(i.e., MyApp.JamesBondCar)
                    2> the name of the assembly defining the object graph(e.g., MyApp.exe)
                    3> an instance of the SerializationInfo class that contains all stateful data maintained by the members in the object graph;

                */

            }

            return 0;
        }

        private static void WorkWithSerialization_UserPrefs()
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;

            BinaryFormatter binFormat = new BinaryFormatter();

            using(Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }

            Console.ReadLine();

        }

        private static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using(Stream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fs, objGraph);
            }
            System.Console.WriteLine("=> Saved Car in binary format!");
        }

        private static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            SoapFormatter soapFmt = new SoapFormatter();

            using(Stream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFmt.Serialize(fs, objGraph);
            }
            System.Console.WriteLine("=> Save Car in SAOP format!");
        }

        private static void SaveAsXmlFormat(object objGraph, string filename)
        {
            XmlSerializer xmlFmt = new XmlSerializer(typeof(JamesBondCar));

            using(Stream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFmt.Serialize(fs, objGraph);
            }
            System.Console.WriteLine("=> Saved Car in XML format!");
        }

        static void FuckWithObjectSerialization_Serialize()
        {
            System.Console.WriteLine("***** fun with object serialization *****\n");

            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubMerge = false;
            jbc.theRadio.stationPresets = new double[]{ 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            SaveAsBinaryFormat(jbc, "CarData.dat");
            Console.ReadLine();
        }

        static void FuckWithObjectSerialization_Deserialize(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using(Stream fs = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fs);
                System.Console.WriteLine("Can this car fly? : {0}", carFromDisk.canFly);
            }

        }






    }
}
