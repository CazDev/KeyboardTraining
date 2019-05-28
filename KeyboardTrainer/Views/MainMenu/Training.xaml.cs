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

            MLanguage = language;
            ViewModel = new ViewModel(language);
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();

            this.Title = ViewModel.Translate("Training");


            ViewModel.StatisticChanged += StatChanged;
            ViewModel.Mistaked += (s) => mistakes++;
            this.TextInput += Win_TextInput;

            System.Timers.Timer tmrUpdateTime = new System.Timers.Timer(100)
            {
                Enabled = true
            };
            tmrUpdateTime.Elapsed += UpdateTime;

            txtbx_Mistakes.Text = $"{ViewModel.Translate("Mistakes")}: ";
            txtbx_LettersTotalPrinted.Text = $"{ViewModel.Translate("Total work")}: ";
            txtbx_Time.Text = $"{ViewModel.Translate("Time")}: ";


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
                            txtbx_TextToType.Text = ViewModel.Translate("Please change keyboard layout");
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
                txtbx_Mistakes.Text = $"{ViewModel.Translate("Mistakes")}: " + mistakes.ToString();
            });
            txtbx_LettersTotalPrinted.Dispatcher.Invoke(() =>
            {
                txtbx_LettersTotalPrinted.Text = $"{ViewModel.Translate("Total work")}: " + totalLettersPrinted.ToString();
            });
        }

        private void UpdateTime(object sender, ElapsedEventArgs e)
        {
            txtbx_Time.Dispatcher.Invoke(new Action(() =>
            {
                if (AskingToChangeKeyboardLayout)
                {
                    txtbx_Time.Text = $"{ViewModel.Translate("Time")}: 0{ViewModel.Translate("sec")}";
                }
                else
                {
                    txtbx_Time.Text = $"{ViewModel.Translate("Time")}: " + (DateTime.Now - ViewModel.Begin).TotalSeconds.ToString("0.0") + $"{ViewModel.Translate("sec")}";
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
