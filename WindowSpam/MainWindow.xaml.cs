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
        private int gameDelay;
        private int pauseTime;
        private int lastCut;
        private int lastNum;
        private int lastWire;
        private int score;
        private int tick;

        private int lastGame;
        //private List<>
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            tick++;
	        bool endAll = false;
            for (int i = 0; i < cutList.Count(); i++) cutList[i].Update(tick);
            for (int i = 0; i < sandList.Count(); i++) sandList[i].Update(tick);
            for (int i = 0; i < cutList.Count(); i++) if(cutList[i].IsGameOver) endAll = true;
	        for(int i = 0; i < sandList.Count(); i++) if(sandList[i].IsGameOver) endAll = true;
            if (endAll){
		        EndAll();
		        return;
	        }
            for (int i = 0; i < cutList.Count(); i++)
            {
                if (cutList[i].IsComplete)
                {
                    cutList[i].Stop();
                    score++;
                }
            }
            for(int i = 0; i < sandList.Count(); i++)
            {
                if (sandList[i].IsComplete)
                {
                    sandList[i].Stop();
                    score++;
                }
            }
            if (gameDelay > 0)
            {
                gameDelay--;
                return;
            }
            if (AllActive()) return;
            
            DecideGame:
            Random rand = new Random();
            int nextGame = rand.Next(3);
            if (lastGame == nextGame)
            {
                
            }
            if (nextGame == 0)
            {
                int nextWindow;
                if (cutList.Count == 1)
                {
                    if(cutList[0].IsActive) goto DecideGame;
                    nextWindow = 0;
                }
                else
                {
                    DecideWindow1:
                    nextWindow = rand.Next(cutList.Count);
                    if (nextWindow == lastCut) return;
                }
                CutWire x = cutList[nextWindow];
                x.Start(tick);
            }
            pauseTime--;
            gameDelay = pauseTime;
        }

        private bool AllActive()
        {
            bool res = true;
            foreach(CutWire x in cutList) res = res && x.IsActive;
            foreach (MakeSandwich x in sandList) res = res && x.IsActive;
            return res;
        }

	private void EndAll(){
		for(int i = 0; i < cutList.Count(); i++){
			cutList[i].End();
			cutList[i].Close();
		}
		for(int i = 0; i < sandList.Count(); i++){
			sandList[i].End();
			sandList[i].Close();
		}
	}

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

        private void End()
        {
            timer.Stop();
            for (int i = 0; i < cutList.Count; i++)
            {
                cutList[i].End();
                cutList[i].Close();
            }

            for (int i = 0; i < sandList.Count; i++)
            {
                sandList[i].End();
                sandList[i].Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            start();
        }

        public void start()
        {
            SpawnWindows();
            timer.Start();
            score = 0;
            pauseTime = 15;
            gameDelay = pauseTime;
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
