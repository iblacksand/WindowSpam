using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace WindowSpam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private List<CutWire> cutList;
        private List<MakeSandwich> sandList;
        //private List<>
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 5, 0);
            timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) { }

        private void SpawnWindows()
        {
            int totalWindows = Int32.Parse(WindowCounter.Text);
            int cut = totalWindows/3;
            int sand = totalWindows/3;
            int nums = totalWindows / 3;
            if (totalWindows % 3 == 1) cut++;
            else if (totalWindows % 3 == 2)
            {
                cut++;
                sand++;
            }
            PopulateMakeSandwich(sand);
            PopulateCutWires(cut);
        }

        private void PopulateCutWires(int amount)
        {
            cutList = new List<CutWire>();
            for (int i = 0; i < amount; i++)
            {
                CutWire x = new CutWire();
                x.Show();
                cutList.Add(x);
            }
        }

        private void PopulateMakeSandwich(int amount)
        {
            sandList = new List<MakeSandwich>();
            for (int i = 0; i < amount; i++)
            {
                MakeSandwich x = new MakeSandwich();
                x.Show();
                sandList.Add(x);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SpawnWindows();
            MakeSandwich x = new MakeSandwich();
            x.Show();
            x.Start(); 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

    }
}
