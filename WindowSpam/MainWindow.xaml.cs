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
        List<Window> gameWindows = new List<Window>();
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
            for(int i = 0; i < windowCount; i++)
            {
                Window x = RandomWindow();
                x.Show();
                gameWindows.Add(x);
            }
        }

        private Window RandomWindow() {
            return new DragAndDrop();
            Random rand = new Random();
            int win = rand.Next(0, 3);
            switch (win)
            {
                case 0:
                    return new CutWire();
                    break;
                case 1:
                    return new MakeSandwich();
                    break;
                default:
                    return new DragAndDrop();
                    break;
            }
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
