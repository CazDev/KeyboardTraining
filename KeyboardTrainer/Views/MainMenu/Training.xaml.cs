using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.Models;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace KeyboardTrainer.Views.MainMenu.Learning_
{
    /// <summary>
    /// Логика взаимодействия для FastLearn.xaml
    /// </summary>
    public partial class Training : Window
    {
        MLanguage MLanguage;
        Random rnd = new Random();
        ViewModel ViewModel;
        Model model = new Model();
        public Training(MLanguage language)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();
            this.Title = "Training";
            MLanguage = language;
            ViewModel = new ViewModel(language)
            {
                Begin = DateTime.Now
            };
            NewWord();
            ViewModel.StatisticChanged += StatChanged;
            ViewModel.Mistaked += () => mistakes++;
            this.KeyDown += window_KeyDown;

            Timer timer = new Timer(100)
            {
                Enabled = true
            };
            timer.Elapsed += Timer_Tick;
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter kc = new KeyConverter();
            string k = kc.ConvertToString(e.Key);
            bool? b = ViewModel.SendChar(k);
            if (b == true)// & != null
            {
                totalLettersPrinted++;
            }
        }
        int mistakes = 0;
        int totalLettersPrinted = 0;
        private void StatChanged(Statistics statistics)
        {
            if (statistics.CharsLeft.Length == 0)
            {
                NewWord();
                return;
            }

            txtbx_TextToType.Dispatcher.Invoke(() =>
            {
                txtbx_TextToType.Text = statistics.CharsLeft;
            });
            txtbx_Mistakes.Dispatcher.Invoke(() =>
            {
                txtbx_Mistakes.Text = "Mistakes: " + mistakes.ToString();
            });
            txtbx_LettersTotalPrinted.Dispatcher.Invoke(() =>
            {
                txtbx_LettersTotalPrinted.Text = "Total work: " + totalLettersPrinted.ToString();
            });
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            txtbx_Time.Dispatcher.Invoke(new Action(() =>
            {
                txtbx_Time.Text = "Time: " + (DateTime.Now - ViewModel.Begin).TotalSeconds.ToString("0.0") + "s";
            }));
        }

        void NewWord()
        {
            string rndWord = GetWord();
            ViewModel.NewRound(rndWord, false);
            txtbx_TextToType.Text = rndWord;
        }


        string GetWord()//depends on this.Language
        {
            if (this.MLanguage == MLanguage.ENGLISH)
            {
                return Database.english[rnd.Next(0, Database.english.Length)];
            }
            else if (this.MLanguage == MLanguage.RUSSIAN)
            {
                return Database.russian[rnd.Next(0, Database.russian.Length)];
            }
            else
            {
                return "";
            }
        }
    }
}
