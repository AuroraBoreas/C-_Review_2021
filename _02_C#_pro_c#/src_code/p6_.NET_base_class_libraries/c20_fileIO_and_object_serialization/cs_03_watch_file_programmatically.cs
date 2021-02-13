using System;
using System.IO;

namespace FileWatcher
{
    class Program
    {
        static int Main(string[] args)
        {
            // P827
            {
                /*

                + System.IO.NotifyFilters
                    ```c#

                    public enum NotifyFilter
                    {
                        Attributes,
                        CreationTime,
                        DirectoryName,
                        FileName,
                        LastAccess,
                        LastWrite,
                        Security,
                        Size
                    }

                    ```

                + FileSystemEventHandler delegate type MUST point to methods matching the following signature
                    ```c#

                    void MyNotificationHandler(object source, FileSystemEventArgs e);

                    ```

                */

                FileWatcherApp();

            }



            return 0;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        { System.Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType); }

        private static void OnRenamed(object source, RenamedEventArgs e)
        { System.Console.WriteLine("File: {0} renamed to {1}", e.oldFullPath, e.FullPath); }


        static void FileWatcherApp()
        {
            System.Console.WriteLine("***** The Amazing File Watcher App *****\n");

            FileSystemWatcher watcher = new FileSystemWatcher();

            try
            {
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            watcher.NotifyFilter = NotifyFilers.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new FileSystemEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            System.Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.ReadLine().Equals('q', StringComparer.OrdinalIgnoreCase))
            {

            }
        }

    }
}
