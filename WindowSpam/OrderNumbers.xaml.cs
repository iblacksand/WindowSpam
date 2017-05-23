using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WindowSpam
{
    /// <summary>
    /// Interaction logic for OrderNumbers.xaml
    /// </summary>
    public partial class OrderNumbers : Window
    {
        int firstNum, secondNum, thirdNum, fourthNum, fifthNum, sixthNum, seventhNum; 

        public OrderNumbers()
        {
            InitializeComponent();
            generateAndFillRandomNumbers(); 
        }

        private void generateAndFillRandomNumbers()
        {
            Random rnd = new Random();
            firstNum = rnd.Next(1, 100000);
            secondNum = rnd.Next(1, 100000);
            thirdNum = rnd.Next(1, 100000);
            fourthNum = rnd.Next(1, 100000);
            fifthNum = rnd.Next(1, 100000);
            sixthNum = rnd.Next(1, 100000);
            seventhNum = rnd.Next(1, 100000);

            InitialNumberTextBlock.Text = firstNum + ", " + secondNum + ", " + thirdNum + ", " + fourthNum + ", " + fifthNum + ", " + sixthNum + ", " + seventhNum; 

        }

    }
}
