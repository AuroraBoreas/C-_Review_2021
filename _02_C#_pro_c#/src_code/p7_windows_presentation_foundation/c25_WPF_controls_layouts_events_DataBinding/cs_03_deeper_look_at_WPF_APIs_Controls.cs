using System;
using System.Windows;

namespace WPF_APIs_And_Controls
{
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void RadioButtonClicked(object sender, RoutedEvents e)
        {
            // TODO: Add event handler implementation here;
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: add event handler implementation here;
        }



    }

    class Program
    {
        static int Main(string[] args)
        {
            // P1080,
            {
                /*

                + important notes
                    ```xaml

                    <Button x:Name="myButton" Height="100" .../>

                    ```

                    >> runtime will completely bypass the set block of the Height property and "directly" call SetValue();

                    >> thus, u should NEVER put validation logic in the set block;

                    >> for this matter, the CLR wrapper of a dependency property should NEVER do anything other than call GetValue() or SetValue();

                */

            }

            //
            {

            }

            return 0;
        }



    }
}
