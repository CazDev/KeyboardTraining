using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.Models;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace KeyboardTrainer.Views.MainMenu.Learning_
{
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
            ViewModel = new ViewModel(language);

            ViewModel.StatisticChanged += StatChanged;
            ViewModel.Mistaked += (s) => mistakes++;
            this.KeyDown += window_KeyDown;
            this.TextInput += Win_TextInput;

            System.Timers.Timer tmrUpdateTime = new System.Timers.Timer(100)
            {
                Enabled = true
            };
            tmrUpdateTime.Elapsed += UpdateTime;
            AskToChangeKeyboard();
        }
        bool AskingToChangeKeyboardLayout = false;
        void AskToChangeKeyboard()
        {
            Task askToChangeLayout = new Task(() =>
            {
                AskingToChangeKeyboardLayout = true;

                while (true)
                {
                    var keybaordLayout = ViewModel.GetKeyboardLayout();
                    if (MLanguage == MLanguage.ENGLISH && keybaordLayout == 1033)
                    {
                        break;//done
                    }
                    else if (MLanguage == MLanguage.RUSSIAN && keybaordLayout == 1049)
                    {
                        break;//done
                    }
                    else//if keyboard layout is wrong
                    {
                        Dispatcher.Invoke(() =>
                        {
                            txtbx_TextToType.Text = "Please change keyboard layout";
                        });
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }
                AskingToChangeKeyboardLayout = false;
                ViewModel.Begin = DateTime.Now;
                NewWord();
            });
            askToChangeLayout.Start();
        }

        private void Win_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (AskingToChangeKeyboardLayout)
            {
                return;
            }

            if (e.Text == " " || e.Text == "\r" ||
                e.Text == "\b" || e.Text == "\t")
            {
                return;
            } 

            string k = e.Text[0].ToString();
            bool? b = ViewModel.SendChar(k);

            if (b == true)// & != null
            {
                totalLettersPrinted++;
            }
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void UpdateTime(object sender, ElapsedEventArgs e)
        {
            txtbx_Time.Dispatcher.Invoke(new Action(() =>
            {
                if (AskingToChangeKeyboardLayout)
                {
                    txtbx_Time.Text = "Time: 0s";
                }
                else
                {
                    txtbx_Time.Text = "Time: " + (DateTime.Now - ViewModel.Begin).TotalSeconds.ToString("0.0") + "s";
                }
            }));
        }

        void NewWord()
        {
            string rndWord = ViewModel.GetWord(this.MLanguage);
            ViewModel.NewRound(rndWord, false);
            Dispatcher.Invoke(() =>
            {
                txtbx_TextToType.Text = rndWord;
            });
        }
    }
}
