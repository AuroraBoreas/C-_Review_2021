using System;

namespace WPF_XAML
{
    class Program
    {
        static int Main(string[] args)
        {
            // P1011
            {
                /*

                + definition
                    - XAML: extensible application markup language

                + why
                    - Windows Forms is rather asymmetrical
                    >> System.Windows.Forms.dll and System.Drawing.dll do NOT provide direct support for many additional technologies require to build a feature-rich desktop application;


                + pre-WPF solutions to desired functionalities, "symmetrical"

                    | desired functionality                 | Technology                             |
                    |---------------------------------------|----------------------------------------|
                    | build windows with controls           | Windows Forms                          |
                    | 2D graphics support                   | GDI+(System.Drawing.dll)               |
                    | 3D graphics support                   | DirectX APIs                           |
                    | support for streaming video           | Windows Media Player APIs              |
                    | support for flow-style documents      | Programmatic manipulation of PDF files |


                    >> demrit
                        >> each technology requires a radically different mind-set;
                        >> it is difficult for a Wondows Forms programmer to master the diverse nature of each API;


                + .NET3.0 solutions to desired functionalities, "symmetrical"

                    | desired functionality                 | Technology                             |
                    |---------------------------------------|----------------------------------------|
                    | build windows with controls           | WPF                                    |
                    | 2D graphics support                   | WPF                                    |
                    | 3D graphics support                   | WPF                                    |
                    | support for streaming video           | WPF                                    |
                    | support for flow-style documents      | WPF                                    |



                */

            }

            //
            {

            }

            return 0;
        }



    }
}
