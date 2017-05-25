using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Security.Permissions;
using System.Security.Policy;
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
    /// Interaction logic for CutWire.xaml
    /// </summary>
    public partial class CutWire : Window
    {
        public static readonly int GameTime = 20;
        private int ToCut;
        public bool IsActive;
        public bool IsComplete;
        public bool IsGameOver;
        public bool CanClose;
        public int EndTime;
        private Random random;
        public CutWire()
        {
            IsActive = false;
            random = new Random();
            IsComplete = false;
            InitializeComponent();
            Background = Brushes.Yellow;
            wireMessage.Text = "";
            RedWire.IsEnabled = false;
            blueWire.IsEnabled = false;
            greenWire.IsEnabled = false;
        }

        public void Update(int time)
        {
            if (!IsActive) return;
            if (time > EndTime + 1) IsGameOver = true;
        }

        public void Start(int startTime)
        {
            EndTime = GameTime + startTime;
            IsActive = true;
            PopulateBoxes();
            IsComplete = false;
            Background = Brushes.Purple;
            SoundPlayer player = new SoundPlayer(@"Sounds\ding.wav");
            player.PlaySync();
            RedWire.IsEnabled = true;
            blueWire.IsEnabled = true;
            greenWire.IsEnabled = true;
        }

        public void PopulateBoxes()
        {
            object syncLock = new object();
            lock (syncLock)
            {
                ToCut = random.Next() % 3;
            }
            System.Diagnostics.Debug.WriteLine("To cut is:" + ToCut);
            String text = "";
            if (ToCut == 0)
            {
                text = "Cut the Blue Wire!";
            }
            else if (ToCut == 2) { 
                text = "Cut the Red Wire!";
            }
            else if(ToCut == 1) {

            text = "Cut the Green Wire";
            }

            else {
                text = "ERROR: RANDOM NUMBER IS OUT OF BOUNDS";
            }
            wireMessage.Text = text;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CanClose; 
        }

        private void blueWire_Click(object sender, RoutedEventArgs e)
        {
            if (ToCut == 0)
            {
                IsComplete = true;
            }
            else
            {
                IsGameOver = true;
                IsComplete = true;
                End();
            }
        }

        private void greenWire_Click(object sender, RoutedEventArgs e)
        {
            if (ToCut == 1)
            {
                IsComplete = true;
            }
            else
            {
                IsGameOver = true;
                IsComplete = true;
                End();
            }
        }

        private void RedWire_Click(object sender, RoutedEventArgs e)
        {
            if (ToCut == 2)
            {
                IsComplete = true;
            }
            else
            {
                IsGameOver = true;
                IsComplete = true;
                End();
            }
        }

        public void End()
        {
            Background = Brushes.Yellow;
            CanClose = true;
        }

        public void Stop()
        {
            IsActive = false;
            Background = Brushes.Yellow;
            RedWire.IsEnabled = false;
            blueWire.IsEnabled = false;
            greenWire.IsEnabled = false;
            wireMessage.Text = "";
        }
    }
}
