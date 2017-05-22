using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowSpam
{
    /// <summary>
    /// Interaction logic for MakeSandwich.xaml
    /// </summary>
    public partial class MakeSandwich : Window
    {
        int counter;
        bool canClose; 
        
        
        public void Start()
        {
            counter = 0;


            topBunPicture.Visibility = Visibility.Hidden;
            baconPicture.Visibility = Visibility.Hidden;
            lettucePicture.Visibility = Visibility.Hidden;
            tomatoPicture.Visibility = Visibility.Hidden;
            bottomBunPicture.Visibility = Visibility.Hidden;

            topBunButton.IsEnabled = true; 
            baconButton.IsEnabled = true;
            lettuceButton.IsEnabled = true;
            tomatoButton.IsEnabled = true;
            bottomBunButton.IsEnabled = true; 

        }

        public MakeSandwich()
        {
            canClose = false; 

            InitializeComponent();
            topBunButton.IsEnabled = false; 
            baconButton.IsEnabled = false;
            lettuceButton.IsEnabled = false;
            tomatoButton.IsEnabled = false;
            bottomBunButton.IsEnabled = false;

            topBunPicture.Visibility = Visibility.Hidden;
            baconPicture.Visibility = Visibility.Hidden;
            lettucePicture.Visibility = Visibility.Hidden;
            tomatoPicture.Visibility = Visibility.Hidden;
            bottomBunPicture.Visibility = Visibility.Hidden;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !canClose;
        }

        private void End()
        {
            canClose = true; 
        }

        private void topBunButton_Click(object sender, RoutedEventArgs e)
        {
            int topBunNumber = 0;
            if (counter == topBunNumber)
            {
                counter++;
                topBunButton.Visibility = Visibility.Hidden;
                topBunPicture.Visibility = Visibility.Visible;
            }
            else
            {
                SystemSounds.Beep.Play();
            }

        }

        private void baconButton_Click(object sender, RoutedEventArgs e)
        {
            int baconNumber = 1; 
            if(counter == baconNumber)
            {
                counter++;
                baconButton.Visibility = Visibility.Hidden;
                baconPicture.Visibility = Visibility.Visible; 
            }
            else
            {
                SystemSounds.Beep.Play();
            }

        }

        private void lettuceButton_Click(object sender, RoutedEventArgs e)
        {
            int lettuceNumber = 2;
            if (counter == lettuceNumber)
            {
                counter++;
                lettuceButton.Visibility = Visibility.Hidden;
                lettucePicture.Visibility = Visibility.Visible;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void tomatoButton_Click(object sender, RoutedEventArgs e)
        {
            int tomatoNumber = 3;
            if (counter == tomatoNumber)
            {
                counter++;
                tomatoButton.Visibility = Visibility.Hidden;
                tomatoPicture.Visibility = Visibility.Visible;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void bottomBunButton_Click_1(object sender, RoutedEventArgs e)
        {
            int bottomBunNumber = 4;
            if (counter == bottomBunNumber)
            {
                counter++;
                bottomBunButton.Visibility = Visibility.Hidden;
                bottomBunPicture.Visibility = Visibility.Visible;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }
    }
}
