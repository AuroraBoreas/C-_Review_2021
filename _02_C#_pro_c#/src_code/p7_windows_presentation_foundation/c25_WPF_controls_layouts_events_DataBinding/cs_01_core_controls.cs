using System;

namespace CoreControls
{
    class Program
    {
        static int Main(string[] args)
        {
            // P1048
            {
                /*

                + core WPF controls
                    - core user input controls
                        > Button, RadioButton, ToggleButton, RepeatButton,
                        > ComboBox, CheckBox, ListBox, RichTextBox
                        > Calendar, DatePicker
                        > Expander
                        > DataGrid
                        > ListView, TreeView
                        > ContextMenu
                        > ScrollBar, Slider, TabControl
                        > TextBlock
                        > Label

                    - window and control adornments
                        > Menu
                        > ToolBar
                        > StatusBar
                        > ToolTip
                        > ProgressBar

                    - media controls
                        > Image
                        > MediaElement
                        > SoundPlayerAction


                    - Layout controls
                        > Border
                        > Canvas
                        > DockPanel
                        > Grid
                        > GridView
                        > GridSplitter
                        > GroupBox
                        > Panel
                        > TabControl
                        > StackPanel
                        > ViewBox
                        > WrapPanel


                */

            }

            // content layout using panels
            {
                /*

                + note
                    - when u declare a control directly inside a window that does NOT use panels, the control is positioned dead-center in the container;


                + core WPF panel controls
                    - Canvas

                    - DockPanel

                    - Grid

                    - StackPanel

                    - WrapPanel


                */

            }

            // Canvas Panels
            {
                /*

                + Canvas Panel
                    - allows absolute positioning of UI content

                + note
                    - limitation
                    >> items within a Canvas do NOT dynamically resize themselves when applying styles or templates;

                    >> the Canvas will NOT attempt to keep elements visible when the end user resizes the window to a smaller surface;


                */
            }

            // Wrap Panels
            {
                /*

                + WrapPanel
                    - allows u to define content that will flow across the panel as the window is resized;

                + note
                    >> when positioning elements in a WrapPanel, u do NOT specify top, bottom, left and right docking values as u typically do with Canvas;

                    >> each subelement is free to define a Height and Width value(among other property values) to control its overall size in the container;

                    >> content within a WrapPanel is rendered from the first element to the last;

                    >> content within a WrapPanel does NOT dock to a given side of the panel, the order in which u declare the elements is important;

                    >> by default, content within a WrapPanel flows from left to right;

                + the most common usage
                    >> a WrapPanel will a subelement to another panel type, allowing a small area of the window to wrap its content when resize (e.g., ToolBar control);


                */
            }

            // StackPanel
            {
                /*

                + StackPanel
                    - arranges content into a single line that can be oriented horizontally or vertically(the default), based on the value assigned to the "Orientation" property;

                    - the items in the StackPanel will simply stretch(based on their orientation) to accommodate the size of the StackPanel itself;

                + usage
                    - u will seldom wanna use a StackPanel to arrange content directly within a window;

                    - instead, u should use StackPanel as a subpanel to a master panel;


                */
            }

            // Grid panel
            {
                /*

                + Grid
                    - Grid can be carved up into a set of cells, each one of which provides content;

                + how
                    >step1, define and configure each column, using "Grid.ColumnDefinitions";

                    >step2, define and configure each row, using "Grid.RowDefinition";

                    >step3, assign content to each cell of the grid using attached property syntax;


                + size Grid Columns and Rows
                    - absolte sizing(e.g., 100)
                    - autosizinng
                    - relative sizing(e.g., 3x)


                + GridSplitter, P1059
                    - why?
                    >> splitters allow the ender user to resize rows or columns of a grid type; as this is done, the content within each resizable cell will reshape itself based on how the items have been contained;

                    - how?
                    >> using Grid.GridSplitter control, attached property syntax to establish which row or column it affects;

                */
            }

            // DockPanel
            {
                /*

                + DockPanel
                    - is used as a container that holds any number of additional panels for grouping related content;

                    >> DockPanel uses attached property syntax to control where each item docks itself within the DockPanel;

                */
            }

            // scrolling for panel types
            {
                /*

                + ScrollViewer
                    - provides automatic scrolling behaviors for data within panel objects;

                */
            }

            return 0;
        }



    }
}
