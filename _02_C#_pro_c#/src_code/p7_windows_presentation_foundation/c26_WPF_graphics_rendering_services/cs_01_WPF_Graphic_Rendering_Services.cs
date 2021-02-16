using System;

namespace WPF_Graphics_Rendering_Services
{
    class Program
    {
        static int Main(string[] args)
        {
            // P1105
            {
                /*

                + term: retained-mode graphics
                    - what is it?
                    >> since u are using XAML or procedural code to generate graphical rendering, it is the responsibility of WPF to persist these visual items and ensure that they are correctly redrawn and refreshed in an optimal manner;

                */

            }

            // WPF Graphical Rendering Options
            {
                /*

                + shapes
                    - WPF provides System.Windows.Shapes namespace;

                    - this ns has a small number of classes for rendering 2D geometic objects(rectangle, ellipses, polygons, etc.);

                    - they are simple but they come with a fair amount of memory overhead if used with reckless abandon;

                + drawing and geometries
                    - WPF provides a second way to render graphical data, using descendants from System.Windows.Media.Drawing abstract class;

                    - using classes such as GeometryDrawing or imageDrawing(in addition to various geometry objects), u can render graphical data in a more lightweight(but less feature-rich) manner;

                + visuals
                    - the fastest and most lightweight way to render graphical data under WPF is using Visual layer,

                    - it is only accessible through C# code;

                    - using descendats of System.Windows.Media.Visual;


                + why?
                    - Application performance

                + choice?
                    - as a rule of thumb, if u need a modest amount of interactive graphical data that can be manipulated by the user (receive mouse input, display tooltips, etc.), u want to use members in the System.Windows.Shapes ns;


                + structure
                    ```c#

                    namespace System.Windows
                    {
                        public class Shapes
                        {}

                        public class Media
                        {
                            public abstract class Drawing
                            {}

                            public class Visual
                            {}
                        }

                    }


                    ```

                + key properties of the Shape Base Class
                    - DefiningGeometry

                    - Fill

                    - GeometryTransform

                    - Stretch

                    - Stroke

                    - StrokeDashArray

                    - StrokeEnddLineCap

                    - StrokeStartLineCap

                    - StrokeThickness

                    >> note: if u forget to set "Fill" and "Stroke" properties, WPF will give u "invisible" brushes and, therefore, the shape will not be visible on the screen;

                */

            }

            return 0;
        }



    }
}
