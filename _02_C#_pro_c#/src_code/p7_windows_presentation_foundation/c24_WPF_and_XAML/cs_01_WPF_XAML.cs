using System;
using System.Windows;

namespace WPF_XAML
{
    class MyApp: Applicaton
    {
        [STAThraed]
        static void Main(string[] args)
        {
            MyApp app = new MyApp();

            app.Startup += (s, e) => { };
            app.Exit += (s, e) => { };
        }

        static void MinimizeAllWindows()
        {
            foreach(Window wnd in Application.Current.Windows)
            {
                wnd.WindowState = WindowState.Minimize;
            }
        }
    }

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

                    | desired functionality                 | Technology       |
                    |---------------------------------------|------------------|
                    | build windows with controls           | WPF              |
                    | 2D graphics support                   | WPF              |
                    | 3D graphics support                   | WPF              |
                    | support for streaming video           | WPF              |
                    | support for flow-style documents      | WPF              |


                */

            }

            // WPF assemblies
            {
                /*

                + core WPF assemblies

                    - PresentationCore.dll        // <-- contributes the foundation of WPF GUI layer;

                    - PresentationFramework.dll   // <-- contains a majority of the WPF controls, the Application and Window classes, support for interactive 2D graphics and numerous types used inn data binding;

                    - System.Xaml.dll            // <-- allows u to program against a XAML document at runtime;

                    - WindowsBase.dll           // <-- constitutes the infrastructure of the WPF API, including those representing WPF threading types, security types, various type converters, and support for dependency properties and routed events;

                */

            }

            // WPF namespace
            {
                /*

                + System.WIndows

                + System.Windows.Controls

                + System.Windows.Data

                + System.Windows.Documents

                + System.Windows.Ink

                + System.Windows.Markup

                + System.Windows.Media

                + System.Windows.Navigation

                + System.Windows.Shapes


                */
            }

            // System.Windows.Application
            {
                /*

                + Current

                + MainWindow

                + Properties

                + StartupUri

                + Windows

                */
            }

            // XAML
            {
                // kaxaml, skip
            }

            // XAML XML namespace and XAML "keywords"
            {
                /*

                + what
                    - the root element of a WPF XAML document(such as <Window>, <Page>, <UserControl>, or <Application> definition)

                + rules of well-formed XML document(remember, XAML is an XML-based grammer)
                    - the opening root element designates one XML ns as the primary namespace, which typically is the namespace that contains the most commonly used item;

                    - if a root element requires the inclusion of additional secondary ns, they MUST be defined using a unique tag prefix(to resolve any possible name clashes);

                    - as a convention, the prefix is simply x;

                    - but this can be any unique token u require, such as XamlSpecificStuff;

                    >> downside of defining wordy XML ns prefixes is u are required to type XamlSpecificStuff each time your XAML file needs to refer to one of the items defined within this XAML-centric XML ns;

                */
            }




            return 0;
        }



    }
}
