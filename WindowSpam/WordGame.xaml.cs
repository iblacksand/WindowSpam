using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for WordGame.xaml
    /// </summary>
    public partial class WordGame : Window
    {
        private int GameTime = 80;
        private int EndTime;
        public bool CanClose;
        public bool IsActive;
        public bool IsComplete;
        public bool IsGameOver;
        private String word;
        private List<String> words;
        private Random rand;
        public WordGame()
        {
            IsActive = false;
            IsGameOver = false;
            IsComplete = false;
            rand = new Random();
            InitializeComponent();
            Background = Brushes.Yellow;
            getList();
            AnswerBox.IsEnabled = false;
        }

        public void Update(int time)
        {
            if (!IsActive) return;
            if (time > EndTime) IsGameOver = true;
        }

        public void Start(int startTime)
        {
            if (IsActive) return;
            Background = Brushes.Purple;
            EndTime = GameTime + startTime;
            word = randomWord();
            GivenBlock.Text = word;
            IsActive = true;
            IsGameOver = false;
            AnswerBox.IsEnabled = true;
        }

        public void End()
        {
            CanClose = true;
        }

        public void Stop()
        {
            Background = Brushes.Yellow;
            IsComplete = false;
            IsActive = false;
            AnswerBox.Text = "";
            AnswerBox.IsEnabled = false;
            GivenBlock.Text = "";
        }

        private void getList()
        {
            StreamReader read = new StreamReader("dictionary.txt");
            words = new List<String>(read.ReadToEnd().Split('\n'));
            //System.Diagnostics.Debug.WriteLine(words[32055] +  " + " + words[32056] + " + " + words[32057]);
        }

        private string randomWord()
        {
            return words[rand.Next(words.Count)];
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CanClose;
        }

        public bool isWord()
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Trim().Equals(AnswerBox.Text)) return true;
            }
            return false;
            //if(!Regex.IsMatch(AnswerBox.Text, @"^[a-zA-Z]+$")) return false;
            //return AnswerBox.GetSpellingErrorLength(0) > 0;
        }

        public bool isWord(int charIndex)
        {
            if (charIndex >= AnswerBox.Text.Length) return false;
            return !(AnswerBox.GetSpellingErrorLength(charIndex) > 0 && isWord(charIndex + 1));
        }

        private void AnswerBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine("word is : " + AnswerBox.Text);
            if (AnswerBox.Text.Trim() == "")
            {
                IsGameOver = true;
                return;
            }
            if (isWord())
            {
                char lastChar = word.Trim().ToCharArray()[word.Trim().Length - 1];
                if (AnswerBox.Text.Trim().ToCharArray()[0] == lastChar)
                {
                    IsComplete = true;
                    return;
                }
            }
            IsGameOver = true;
        }
    }
}
