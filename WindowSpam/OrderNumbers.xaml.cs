using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace WindowSpam
{
    /// <summary>
    /// Interaction logic for OrderNumbers.xaml
    /// </summary>
    public partial class OrderNumbers : Window
    {
        public int GameTime = 500;
        public int EndTime;
        int firstNum, secondNum, thirdNum, fourthNum;
        private int[] nums;
        private String correct;
        public bool IsActive;
        public bool IsGameOver;
        public bool IsComplete;
        public bool CanClose;
        private Random rnd;
        public OrderNumbers()
        {
            CanClose = false;
            rnd = new Random();
            InitializeComponent();
            Background = Brushes.Yellow;
        }

        public void update(int time)
        {
            if (!IsActive) return;
            if (time > EndTime) IsGameOver = true;
        }

        public void start(int StartTime)
        {
            EndTime = StartTime + GameTime;
            IsActive = true;
            IsComplete = false;
            IsGameOver = false;
            generateAndFillRandomNumbers();
            Background = Brushes.Purple;
        }

        private void generateAndFillRandomNumbers()
        {
            firstNum = rnd.Next(1, 1000);
            secondNum = rnd.Next(1, 1000);
            thirdNum = rnd.Next(1, 1000);
            fourthNum = rnd.Next(1, 1000);
            nums = new int[] {firstNum, secondNum, thirdNum, fourthNum};
            Array.Sort(nums);
            correct = nums[0] + ", " + nums[1] + ", " + nums[2] + ", " + nums[3];
            InitialNumberTextBlock.Text = firstNum + ", " + secondNum + ", " + thirdNum + ", " + fourthNum ; 
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsActive)
            {
                AnswerTextBlock.Text = "";
                return;
            }
            if (AnswerTextBlock.Text == "") return;
            if (!AnswerTextBlock.Text.Equals(correct))
            {
                IsGameOver = true;
            }
            else
            {
                IsComplete = true;
            }
        }

        public void Stop()
        {
            IsActive = false;
            IsComplete = false;
            InitialNumberTextBlock.Text = "";
            Background = Brushes.Yellow;
            AnswerTextBlock.Text = "";
        }

        public void End()
        {
            CanClose = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CanClose;
        }

    }
}
