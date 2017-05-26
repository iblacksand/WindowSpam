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
        public static readonly int GameTime = 100;
        int counter;
        bool canClose;
        public bool IsGameOver;
        public bool IsComplete;
        public int EndTime;
        public bool IsActive;
        public void Start(int startTime)
        {
            Background = Brushes.Purple;
            EndTime = GameTime + startTime;
            counter = 0;
            IsGameOver = false;
            IsComplete = false;
            IsActive = true;
            topBunButton.Visibility = Visibility.Visible;
            baconButton.Visibility = Visibility.Visible;
            lettuceButton.Visibility = Visibility.Visible;
            tomatoButton.Visibility = Visibility.Visible;
            bottomBunButton.Visibility = Visibility.Visible;
            topBunPicture.Visibility = Visibility.Hidden;
            baconPicture.Visibility = Visibility.Hidden;
            lettucePicture.Visibility = Visibility.Hidden;
            tomatoPicture.Visibility = Visibility.Hidden;
            bottomBunPicture.Visibility = Visibility.Hidden;


            GameOverText.Visibility = Visibility.Hidden;

            topBunButton.IsEnabled = true; 
            baconButton.IsEnabled = true;
            lettuceButton.IsEnabled = true;
            tomatoButton.IsEnabled = true;
            bottomBunButton.IsEnabled = true; 

        }

        public MakeSandwich()
        {
            Background = Brushes.Yellow;
            IsGameOver = false;
            IsComplete = false;
            canClose = false;
            IsActive = false;
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

            GameOverText.Visibility = Visibility.Hidden; 
        }

        public void Update(int time)
        {
            if (!IsActive) return;
            if (time > EndTime) IsGameOver = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !canClose;
        }

        public void End()
        {
            canClose = true; 
        }

        public void Stop()
        {
            topBunButton.IsEnabled = false;
            baconButton.IsEnabled = false;
            lettuceButton.IsEnabled = false;
            tomatoButton.IsEnabled = false;
            bottomBunButton.IsEnabled = false;
            IsActive = false;
            IsComplete = false;
            topBunPicture.Visibility = Visibility.Hidden;
            baconPicture.Visibility = Visibility.Hidden;
            lettucePicture.Visibility = Visibility.Hidden;
            tomatoPicture.Visibility = Visibility.Hidden;
            bottomBunPicture.Visibility = Visibility.Hidden;
            Background = Brushes.Yellow;
            GameOverText.Visibility = Visibility.Hidden;
        }

        public void GameOver()
        {
            topBunPicture.Visibility = Visibility.Hidden;
            baconPicture.Visibility = Visibility.Hidden;
            lettucePicture.Visibility = Visibility.Hidden;
            tomatoPicture.Visibility = Visibility.Hidden;
            bottomBunPicture.Visibility = Visibility.Hidden;

            topBunButton.Visibility = Visibility.Hidden;
            baconButton.Visibility = Visibility.Hidden;
            lettuceButton.Visibility = Visibility.Hidden;
            tomatoButton.Visibility = Visibility.Hidden;
            bottomBunButton.Visibility = Visibility.Hidden;

            topBunButton.IsEnabled = false;
            baconButton.IsEnabled = false;
            lettuceButton.IsEnabled = false;
            tomatoButton.IsEnabled = false;
            bottomBunButton.IsEnabled = false;

            RulesText.Visibility = Visibility.Hidden; 
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
                IsGameOver = true;
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
                IsGameOver = true;
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
                IsGameOver = true;
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
                IsGameOver = true;
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
                IsComplete = true;
            }
            else
            {
                IsGameOver = true;
                
                SystemSounds.Beep.Play();
            }
        }
    }
}
