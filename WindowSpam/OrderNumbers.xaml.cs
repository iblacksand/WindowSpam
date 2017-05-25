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
        public int GameTime;
        public int EndTime;
        int firstNum, secondNum, thirdNum, fourthNum, fifthNum, sixthNum, seventhNum;
        private int[] nums;
        public bool IsActive;
        public bool IsGameOver;
        public bool IsComplete;

        private Random rnd;
        public OrderNumbers()
        {
            rnd = new Random();
            InitializeComponent();
        }

        public void update(int time)
        {
            if (!IsActive) return;
            if (time > EndTime) IsGameOver = true;
        }

        public void start(int StartTime)
        {
            EndTime = StartTime + EndTime;
            IsActive = false;
            IsComplete = false;
            generateAndFillRandomNumbers();
        }

        private void generateAndFillRandomNumbers()
        {
            firstNum = rnd.Next(1, 100000);
            secondNum = rnd.Next(1, 100000);
            thirdNum = rnd.Next(1, 100000);
            fourthNum = rnd.Next(1, 100000);
            fifthNum = rnd.Next(1, 100000);
            sixthNum = rnd.Next(1, 100000);
            seventhNum = rnd.Next(1, 100000);
            nums = new int[] {firstNum, secondNum, thirdNum, fourthNum, fifthNum, sixthNum, seventhNum};
            Array.Sort(nums);
            InitialNumberTextBlock.Text = firstNum + ", " + secondNum + ", " + thirdNum + ", " + fourthNum + ", " + fifthNum + ", " + sixthNum + ", " + seventhNum; 
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            String[] numsAsStrings = AnswerTextBlock.Text.Split(' ');
            int[] givenInts = new int[numsAsStrings.Length];
            int c = 0;
            foreach (String str in numsAsStrings)
            {
                givenInts[c] = Int32.Parse(str.Substring(0, str.Length - 1));
                c++;
            }
            if (givenInts.Length != nums.Length)
            {
                IsGameOver = true;
            }
            bool isEqual = true;
            for (int i = 0; i < givenInts.Length; i++)
            {
                isEqual = isEqual && (givenInts[i] == nums[i]);
            }
            if (!isEqual) IsGameOver = true;
            else
            {
                IsComplete = true;
            }
        }

        public void Stop()
        {
            IsActive = false;
            InitialNumberTextBlock.Text = "";
        }

    }
}
