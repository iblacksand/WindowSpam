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

        private void spawnWindows()
        {
            int windowCount = Int16.Parse(WindowCounter.Text);
            for(int i = 0; i < 3; i++)
            {
                
            }
            CutWire x = new CutWire();
            x.Show();
            x.Start();
            x.End();
            x.Close();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spawnWindows();
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
