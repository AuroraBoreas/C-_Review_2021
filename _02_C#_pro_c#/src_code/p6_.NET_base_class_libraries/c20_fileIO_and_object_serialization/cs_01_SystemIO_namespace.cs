using System;
using System.IO;

namespace SystenmIONamespace
{
    class Program
    {
        static int Main(string[] args)
        {
            // explore, P803
            {
                /*

                + key members of System.IO namespace
                    - BinaryReader
                    - BinaryWriter
                    - BufferedStream

                    - Directory             // exposes functionality using "static members" which typically return string data; class-level;
                    - DirectoryInfo         // exposes similar functionality from a "valid object reference"; instance-level

                    - DriveInfo

                    - File
                    - FileInfo

                    - FileStream            //  random file access with data represented as a stream of bytes;

                    - FileSystemWatcher     // allows u to monitor the modification of external files in a specific directory;

                    - MemoryStream         // random access to streamed data stored in memory rather in a physical file;

                    - Path

                    - StreamWriter         // store or retrieve textual info to or from a file; but do NOT support random-file-access
                    - StreamReader

                    - StringWriter         // like StreamWriter/StreamReader, work with textual info; but underlying storage is a stringbuffer;
                    - StringReader

                + abstract classes
                    - Stream

                    - TextReader
                    - TextWriter

                */

            }

            // Directory(Info) and File(Info) types, P805
            {
                /*

                + FileSystemInfo props
                    - Attributes

                    - CreationTime
                    - LastAccessTime
                    - LastWriteTime

                    - Exists
                    - Extension
                    - FullName
                    - Name



                + key members of DirectoryInfo type
                    - Create()
                    - CreateSubdirectory()      // u should know that a DirectoryInfo obj representing the newly created ietm is passed back on successful execution;

                    - Delete()
                    - GetDirectories()

                    - GetFile()

                    - MoveTo()
                    - Parent
                    - Root

                */

                ShowWindowsDirectoryInfo();

                DisplayImageFiles();

            }

            // create subdir
            {
                CreateSubDirectory();
                ModifyAppDirectory();
            }

            // Directory Type, P809
            {

                FuckWithDirectoryType();

            }

            // DriveInfo class type
            {
                FuckWithDriveInfoType();
            }

            // FileInfo class
            {
                /*

                + FileInfo core members
                    - AppendText()      // creates a StreamWrite obj that appends text to a file;
                    - CopyTo()
                    - Create()
                    - CreateText()

                    - Delete()
                    - Directory
                    - DirectoryName

                    - Length            // size of the current file

                    - MoveTo()

                    - Name
                    - Open()
                    - OpenRead()
                    - OpenText()
                    - OpenWrite()

                */
            }



            return 0;
        }


        private static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            System.Console.WriteLine("***** Directory Info *****");

            System.Console.WriteLine("FullName: {0}", dir.FullName);
            System.Console.WriteLine("Name: {0}", dir.Name);
            System.Console.WriteLine("Parent: {0}", dir.Parent);
            System.Console.WriteLine("Creation: {0}", dir.CreationTime);
            System.Console.WriteLine("Attributes: {0}", dir.Attributes);
            System.Console.WriteLine("Root: {0}", dir.Root);

            System.Console.WriteLine("**************************\n");
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            // how many were found
            System.Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            foreach(FileInfo f in imageFiles)
            {
                System.Console.WriteLine("*************************");

                System.Console.WriteLine("File Name: {0}", f.Name);
                System.Console.WriteLine("Full Name: {0}", f.FullName);
                System.Console.WriteLine("Fill size: {0}", f.Length);
                System.Console.WriteLine("Creation : {0}", f.CreationTime);
                System.Console.WriteLine("Attributes: {0}", f.Attributes);

                System.Console.WriteLine("*************************\n");
            }
        }

        static void CreateSubDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            dir.CreateSubdirectory("MyFolder");
            dir.CreateSubdirectory(@"MyFolder2\Data");
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(". ");

            dir.CreateSubdirectory("MyFolder");

            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

            System.Console.WriteLine("New Folder is : {0}", myDataFolder);
        }

        static void FuckWithDirectoryType()
        {
            string[] drives = Directory.GetLogicalDrives();
            System.Console.WriteLine("Here are your drives:");
            foreach(string dr in drives)
                System.Console.WriteLine("--> {0}", dr);

            System.Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete(@"C:\MyFolder");
                Directory.Delete(@"C:\MyFolder2", true);
            }
            catch (IOException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        static void FuckWithDriveInfoType()
        {
            System.Console.WriteLine("***** fun with DriveInfo *****\n");

            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach(DriveInfo d in myDrives)
            {
                System.Console.WriteLine("Name: {0}", d.Name);
                System.Console.WriteLine("Name: {0}", d.DriveType);

                if(d.IsReady)   // check to see whether the drive is mounted
                {
                    System.Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    System.Console.WriteLine("Format: {0}", d.DriveFormat);
                    System.Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                System.Console.WriteLine();
            }

            Console.ReadLine();

        }

        static void FileInfo_Create()
        {
            FileInfo f = new FileInfo(@"C:\Test.dat");  // return a specific I/O-centric obj that allows u to begin reading and writing data to the associated file in a variety of formats;
            FileStream fs = f.Create();
            // ...;
            fs.Close();
        }




    }
}
