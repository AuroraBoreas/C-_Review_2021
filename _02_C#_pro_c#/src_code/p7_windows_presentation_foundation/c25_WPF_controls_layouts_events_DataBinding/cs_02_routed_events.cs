using System;

namespace RoutedEvents
{
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

            //
            {

            }

            return 0;
        }

        public void btnClickMe_Clicked(object sender, RoutedEvents e)
        {
            System.Windows.Forms.MessageBox.Show("Clicked the button");
        }

    }
}
