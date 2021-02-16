using System;
using System.Windows;

namespace RoutedEvents
{
    public partial class MainWindow: Window
    {
        string _mouseActivity = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnClickMe_Clicked(object sender, RoutedEvents e)
        {
            AddEventInfo(sender, e);
            System.Windows.Forms.MessageBox.Show(_mouseActivity, "Your event info");

            // clear string for next round;
            _mouseActivity = "";
        }

        private void AddEventInfo(object sender, RoutedEvents e)
        {
            _mouseActivity += string.Format(
                "{0} sent a {1} event named {2}.\n", sender,
                e.RoutedEvents.RoutingStrategy,
                e.RoutedEvents.Name
            );
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEventInfo(sender, e);
        }

        private void outerEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEventInfo(sender, e);
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            // Routed Events, 1076
            {
                /*

                + concept
                    - it is similar with route(MVC) in Django web development


                */



            }

            // routed bubbling events, P1077
            {
                /*

                + concept
                    - it is similar with iceberg mechanism in html;
                    - given this bubbling routed event pattern, u have no need to worry about registration specific Click event handlers for all members of a composite control;

                    >> however, u can if u wanna custom clicking logic;

                    - thus, routed bubbling events always move from the point of origin to the "next defining scope";
                */

            }

            // routed tunneling events, 1078
            {
                /*

                + concept

                    - counterpart against routed bubbling event;

                    - routed tunneling events drill down from the Topmost element into the inner scopes of the object tree;

                + note
                    - tunneling events all begin with the "Preview"-suffix;

                    - each bubbling event in the WPF base class libraries is paired with a related tunneling event that fires "Before" the bubbling counterpart;

                    >> Tunneling first, bubbling second;

                + why tunneling events and bubbling events come in paris?
                    >> by previewing events, u have the power to perform any special logic(data validation, disable bubbling action, etc.) before the bubbling counterpart fires;

                */
            }

            return 0;
        }

        public void btnClickMe_Clicked(object sender, RoutedEvents e)
        {
            System.Windows.Forms.MessageBox.Show("Clicked the button");
        }

        public void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("You clicked the outer ellipse!");
        }
        public void outerEllipse_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            this.Title = "You clicked the outer ellipse!";
            e.Handled = true;
        }



    }
}
