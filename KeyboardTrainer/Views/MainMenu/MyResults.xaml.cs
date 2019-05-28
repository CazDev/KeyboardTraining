using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KeyboardTrainer.Views
{
    public partial class MyResults : Window
    {
        readonly ViewModel viewModel;
        readonly List<string> mostMistakeLetters = new List<string>();
        readonly MLanguage language;
        bool IsTimerTicking = false; //timer before game 
        public MyResults(MLanguage language)
        {
            InitializeComponent();
            viewModel = new ViewModel(language);
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();
            this.Title = "My results";
            this.language = language;

            StartGame();

            #region Register events
            viewModel.StatisticChanged += StatisticChanged;
            viewModel.Mistaked += Mistaked;
            this.TextInput += Win_TextInput;

            System.Timers.Timer updateTimeLabel = new System.Timers.Timer(100)
            {
                Enabled = true
            };
            updateTimeLabel.Elapsed += (s, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    if ((viewModel.Begin.Year != 1) && (!IsTimerTicking))//not inited or stopped && timer is not counting
                    {
                        lbl_time.Content = $"Time: {(DateTime.Now - viewModel.Begin).TotalSeconds.ToString("0.0")}s";
                    }
                    else
                        lbl_time.Content = $"Time: 0s";
                });
            };

            retry.MouseDown += (s, e) =>
            {
                StartGame();
            };
            #endregion
        }

        private void Win_TextInput(object sender, TextCompositionEventArgs e)
        {
            Char keyChar = e.Text[0];

            if (IsTimerTicking)
            {
                return;
            }
            //if (e.Key == Key.Enter)
            //{
            //    return;
            //}
            viewModel.SendChar(keyChar.ToString());
        }




        private void StartGame()
        {
            if (IsTimerTicking)
            {
                return; //timer is already started
            }
            Dispatcher.Invoke(() =>
            {
                textblockText.TextAlignment = TextAlignment.Center;
            });

            Task askToChangeLayout = new Task(() =>
            {
                IsTimerTicking = true;

                while (true)
                {
                    var keybaordLayout = viewModel.GetKeyboardLayout();
                    if (language == MLanguage.ENGLISH && keybaordLayout == 1033)
                    {
                        break;
                    }
                    else if (language == MLanguage.RUSSIAN && keybaordLayout == 1049)
                    {
                        break;
                    }
                    else//if keyboard layout is wrong
                    {
                        Dispatcher.Invoke(() =>
                        {
                            textblockText.Text = "Please change keyboard layout";
                        });
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }

                StartTimerBeforeGame();
            });
            askToChangeLayout.Start();

            
        }
        private void StartTimerBeforeGame()
        {
            Task timerBeforeStart = new Task(() =>
            {
                #region timer
                for (int i = 3; i > 0; i--)
                {
                    Dispatcher.Invoke(() =>
                    {
                        textblockText.Text = i.ToString();
                    });
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                Dispatcher.Invoke(() =>
                {
                    textblockText.TextAlignment = TextAlignment.Left;
                });
                #endregion
                viewModel.NewRound(viewModel.GetString(language, 100));// txt will change text using event StatisticChanged
                IsTimerTicking = false;
            });
            timerBeforeStart.Start();
        }


        private void Mistaked(string letter)
        {
            mostMistakeLetters.Add(letter);
        }

        private void StatisticChanged(Statistics statistics)
        {
            Dispatcher.Invoke(() =>
            {
                lbl_left.Content = $"Chars left: {statistics.CharsLeft.Length}";
                lbl_mistakes.Content = $"Mistakes: {statistics.Mistakes}";

                lbl_time.Content = $"Time: {(int)statistics.Time.TotalSeconds}s";
                textblockText.Text = statistics.CharsLeft;
            });
            if (statistics.CharsLeft.Length == 0)
            {
                ShowEndMessage(statistics);
                StartGame(); 
                mostMistakeLetters.Clear();
            }
        }

        struct NumOfLetter
        {
            public int Frequency { get; set; }//num
            public string Letter { get; set; }

            public NumOfLetter(int frequency, string letter)
            {
                Frequency = frequency;
                Letter = letter;
            }
            public override string ToString()
            {
                return $"{Letter} - {Frequency}";
            }
        }
        private void ShowEndMessage(Statistics statistics)
        {
            string str_mistakeLetters = GetStringMistakesInEachLetter();
            viewModel.Begin = new DateTime(1, 1, 1);//stop time counter (year = 1)
            MessageBox.Show($"Your speed {statistics.Speed.ToString("0.00")} keys per minute.\nYou make most mistakes in:\n{str_mistakeLetters}", "Statistics", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private string GetStringMistakesInEachLetter()
        {
            List<string> uniqueLetters = mostMistakeLetters.Distinct().ToList();
            List<NumOfLetter> mistakeLetters = new List<NumOfLetter>();
            for (int i = 0; i < uniqueLetters.Count; i++)
            {
                string curr = uniqueLetters[i];
                int frequency = 0;

                for (int j = 0; j < mostMistakeLetters.Count; j++)
                {
                    if (mostMistakeLetters[j] == curr)
                    {
                        frequency++;
                    }
                }
                mistakeLetters.Add(new NumOfLetter(frequency, curr));
            }

            //sort by Frequency
            int index; NumOfLetter temp;
            for (int i = 0; i < mistakeLetters.Count; ++i)
            {
                index = i;
                temp = mistakeLetters[i];
                for (int j = i + 1; j < mistakeLetters.Count; ++j)
                {
                    if (mistakeLetters[j].Frequency > temp.Frequency)
                    {
                        index = j;
                        temp = mistakeLetters[j];
                    }
                }
                mistakeLetters[index] = mistakeLetters[i];
                mistakeLetters[i] = temp;
            }
            //to string array, 10 most popular mistakes
            string str_mistakeLetters = "";
            for (int i = 0; i < mistakeLetters.Count && i < 10; i++)
            {
                str_mistakeLetters += mistakeLetters[i].ToString() + "\n";
            }

            return str_mistakeLetters;
        }
    }
}
