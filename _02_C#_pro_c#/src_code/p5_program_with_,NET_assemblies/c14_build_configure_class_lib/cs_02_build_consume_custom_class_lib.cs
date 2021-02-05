using System;
using CarLibrary;

namespace BuildConsumeCustomClassLib
{
    class Program
    {
        static int Main(string[] args)
        {
            // build and consume Custom Class Library, P573
            {
                SportsCar sc1 = new SportsCar {PetName="ZL", MaxSpeed=200, CurrentSpeed=10};
                MiniVan mv1 = new MiniVan {PetName="XY", MaxSpeed=100, CurrentSpeed=20};
                sc1.TurboBoost();
                mv1.TurboBoost();

                System.Console.WriteLine(sc1.ToString());
                System.Console.WriteLine(mv1.ToString());

                Console.ReadLine();

            }

            // configure private assemblies, P586
            {
                /*
                
                + note in "*.config" file
                    - <probing> element simply instructs the CLR to investigate all specified subdirectories for the requested assembly until the first match is encountered;
                    - <probing privatePath="subdir_libraries_folder_name"> attribute can NOT be used to specify an absolute or relative path!
                    - using <codeBase> element to do it instead;
                
                + note about the name of "*.config" files
                    - file names MUST be prefixed with the same name as the related client application;
                    
                    ```c#

                    <probing privatePath="MyLibraries;MyLibraries\Tests"/>
                    ```
                
                */ 

            }

            return 0;
        }

        
    }
}