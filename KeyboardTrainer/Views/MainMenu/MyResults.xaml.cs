using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace KeyboardTrainer.Views
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class MyResults : Window
    {
        ViewModel viewModel;
        List<string> mostMistakeLetters = new List<string>();
        MLanguage language;
        public MyResults(MLanguage language)
        {
            InitializeComponent();
            viewModel = new ViewModel(language);
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();
            this.Title = "My results";
            this.language = language;

            viewModel.StatisticChanged += StatisticChanged;
            viewModel.Mistaked += Mistaked;
            this.KeyDown += Training_KeyDown;

            Timer updateTimeLabel = new Timer(100)
            {
                Enabled = true
            };
            updateTimeLabel.Elapsed += (s, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    lbl_time.Content = $"Time: {(DateTime.Now - viewModel.Begin).TotalSeconds.ToString("0.0")}s";
                });
            };

            viewModel.NewRound(viewModel.GetString(language, 100));
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
                viewModel.NewRound(viewModel.GetString(language, 100)); // txt will change text using event StatisticChanged
            }
        }

        private void Training_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                return;
            }

            KeyConverter kc = new KeyConverter();
            string str = kc.ConvertToString(e.Key);
            viewModel.SendChar(str);
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

            MessageBox.Show($"Your speed {statistics.Speed.ToString("G")} keys per minute.\nYou make most mistakes in:\n{str_mistakeLetters}", "Statistics", MessageBoxButton.OK, MessageBoxImage.Information);

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
