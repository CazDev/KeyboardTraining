using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KeyboardTrainer.Views
{
    public partial class MyResults : Window
    {
        readonly ViewModel viewModel;
        Random rnd = new Random();
        readonly List<string> mostMistakeLetters = new List<string>();
        readonly MLanguage language;
        bool IsTimerTicking = false; //timer before game 
        bool LessonMode { get; set; }
        public Statistics LastStatistics { get; set; }

        /// <summary>
        /// Get results
        /// </summary>
        /// <param name="language"></param>
        public MyResults(MLanguage language)
        {
            InitializeComponent();

            viewModel = new ViewModel(language);
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();

            this.Title = viewModel.Translate("My results");
            retry.Text = viewModel.Translate("Retry");
            textInfo.Text = viewModel.Translate("Type text");

            this.language = language;

            StatisticChanged(new Statistics(new string('*', 100), 0));//to update labels

            StartGame();

            #region Register events

            viewModel.StatisticChanged += StatisticChanged;
            viewModel.Mistaked += Mistaked;
            this.TextInput += Win_TextInput;
            StartTimeTimer();
            retry.MouseDown += (s, e) =>
            {
                StartGame();
            };

            #endregion
        }

        /// <summary>
        /// Lesson mode
        /// </summary>
        /// <param name="language"></param>
        /// <param name="numOfLesson"></param>
        public MyResults(MLanguage language, int numOfLesson)
        {
            if (numOfLesson < 1 || numOfLesson > 18)
            {
                throw new ArgumentOutOfRangeException();
            }

            InitializeComponent();

            LessonMode = true;
            string avaibleChrs = GetAvaibleChrs(language, numOfLesson);
            viewModel = new ViewModel(language);
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();

            this.language = language;
            this.Title = viewModel.Translate("Lesson") + " " + numOfLesson;
            retry.Text = viewModel.Translate("Retry");
            textInfo.Text = viewModel.Translate("Type text");
            lbl_left.Content = viewModel.Translate("Chars left") + ":";
            lbl_mistakes.Content = viewModel.Translate("Mistakes") + ":";
            retry.Opacity = 0;

            viewModel.StatisticChanged += StatisticChanged;
            viewModel.Mistaked += Mistaked;
            this.TextInput += Win_TextInput;

            StartGame(GetStringUsingChars(avaibleChrs, 100));


            StartTimeTimer();
        }
        private string GetStringUsingChars(string chrs, int length)
        {
            string result = "";
            int counterofTextWithoutSpaces = 0;
            for (int i = 0; result.Length < length; i++)
            {
                result += chrs[rnd.Next(0, chrs.Length)];
                counterofTextWithoutSpaces++;
                if ((i != 0) && (counterofTextWithoutSpaces >= 4)) //add sperator
                {
                    if (rnd.Next() % 3 == 0)
                    {
                        result += " ";
                    }
                    counterofTextWithoutSpaces = 0;
                }
            }
            return result;
        }

        private string GetAvaibleChrs(MLanguage language, int numOfLesson)
        {
            string avaibleChrs = "";
            if (language == MLanguage.RUSSIAN)
            {
                if (numOfLesson == 1) avaibleChrs = "ао";
                if (numOfLesson == 2) avaibleChrs = "аопр";
                if (numOfLesson == 3) avaibleChrs = "аопрвл";
                if (numOfLesson == 4) avaibleChrs = "аопрвлыд";
                if (numOfLesson == 5) avaibleChrs = "аопрвлыдфж";
                if (numOfLesson == 6) avaibleChrs = "аопрвлыдфжэ"; //middle line

                if (numOfLesson == 7) avaibleChrs = "аопрвлыдфжэен";
                if (numOfLesson == 8) avaibleChrs = "аопрвлыдфжэенкг";
                if (numOfLesson == 9) avaibleChrs = "аопрвлыдфжэенкгуш";
                if (numOfLesson == 10) avaibleChrs = "аопрвлыдфжэенкгушцщ";
                if (numOfLesson == 11) avaibleChrs = "аопрвлыдфжэенкгушцщйз";
                if (numOfLesson == 12) avaibleChrs = "аопрвлыдфжэенкгушцщйзъ"; //up line

                if (numOfLesson == 13) avaibleChrs = "аопрвлыдфжэенкгушцщйзъми";
                if (numOfLesson == 14) avaibleChrs = "аопрвлыдфжэенкгушцщйзъмист";
                if (numOfLesson == 15) avaibleChrs = "аопрвлыдфжэенкгушцщйзъмистчь";
                if (numOfLesson == 16) avaibleChrs = "аопрвлыдфжэенкгушцщйзъмистчьяб";
                if (numOfLesson == 17) avaibleChrs = "аопрвлыдфжэенкгушцщйзъмистчьябю";//all lines
            }
            else if (language == MLanguage.ENGLISH)
            {
                if (numOfLesson == 1) avaibleChrs = "fj";
                if (numOfLesson == 2) avaibleChrs = "fjgh";
                if (numOfLesson == 3) avaibleChrs = "fjghdk";
                if (numOfLesson == 4) avaibleChrs = "fjghdksl";
                if (numOfLesson == 5) avaibleChrs = "fjghdksla";
                if (numOfLesson == 6) avaibleChrs = "fjghdksla"; //middle line

                if (numOfLesson == 7) avaibleChrs = "fjghdkslty";
                if (numOfLesson == 8) avaibleChrs = "fjghdksltyru";
                if (numOfLesson == 9) avaibleChrs = "fjghdksltyruei";
                if (numOfLesson == 10) avaibleChrs = "fjghdksltyrueiwo";
                if (numOfLesson == 11) avaibleChrs = "fjghdksltyrueiwoqp";
                if (numOfLesson == 12) avaibleChrs = "fjghdksltyrueiwoqp"; //up line
                if (numOfLesson == 13) avaibleChrs = "fjghdksltyrueiwoqpvb";
                if (numOfLesson == 14) avaibleChrs = "fjghdksltyrueiwoqpvbcn";
                if (numOfLesson == 15) avaibleChrs = "fjghdksltyrueiwoqpvbcnxm";
                if (numOfLesson == 16) avaibleChrs = "fjghdksltyrueiwoqpvbcnxmz";
                if (numOfLesson == 17) avaibleChrs = "fjghdksltyrueiwoqpvbcnxmz";//all lines
            }

            return avaibleChrs;
        }

        private void StartTimeTimer()
        {
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
                        lbl_time.Content = $"{viewModel.Translate("Time")}: {(DateTime.Now - viewModel.Begin).TotalSeconds.ToString("0.0")}{viewModel.Translate("sec")}";
                    }
                    else
                        lbl_time.Content = $"{viewModel.Translate("Time")}: 0{viewModel.Translate("sec")}";
                });
            };
        }

        private void Win_TextInput(object sender, TextCompositionEventArgs e)
        {
            Char keyChar = e.Text[0];

            if (IsTimerTicking)
            {
                return;
            }
            viewModel.SendChar(keyChar.ToString());
        }

        /// <summary>
        /// asks to change keyboard layout, starts timer, runs method StartGameBeforeTimer
        /// </summary>
        /// <param name="customString"></param>
        private void StartGame(string customString = "")
        {
            if (IsTimerTicking)
            {
                return; //if timer is already started
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
                            textblockText.Text = viewModel.Translate("Please change keyboard layout");
                        });
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }
                if (customString == "")
                {
                    StartGameBeforeTimer();
                }
                else
                {
                    StartGameBeforeTimer(customString);
                }
            });
            askToChangeLayout.Start();
        }
        private void StartGameBeforeTimer(string customString = "")
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
                if (customString == "")
                {
                    viewModel.NewRound(viewModel.GetString(language, 100));// txt will change text using event StatisticChanged
                }
                else
                {
                    viewModel.NewRound(customString);
                }
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
            LastStatistics = statistics;
            Dispatcher.Invoke(() =>
            {
                lbl_left.Content = $"{viewModel.Translate("Chars left")}: {statistics.CharsLeft.Length}";
                lbl_mistakes.Content = $"{viewModel.Translate("Mistakes")}: {statistics.Mistakes}";

                lbl_time.Content = $"{viewModel.Translate("Time")}: {statistics.Time.TotalSeconds.ToString("0.0")}{viewModel.Translate("sec")}";
                textblockText.Text = statistics.CharsLeft;
            });
            if (statistics.CharsLeft.Length == 0)
            {
                ShowEndMessage(statistics);
                if (LessonMode)
                {
                    Dispatcher.Invoke(() =>
                    {
                        this.DialogResult = true;
                    });
                }
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
            ShowStatistics(statistics.Speed, str_mistakeLetters);
        }
        void ShowStatistics(double Speed, string str_mistakeLetters)
        {
            MessageBox.Show($"{viewModel.Translate("Your speed")} {Speed.ToString("0.00")} {viewModel.Translate("keys per minute")}.\n{viewModel.Translate("You make most mistakes in")}:\n{str_mistakeLetters}", viewModel.Translate("Statistics"), MessageBoxButton.OK, MessageBoxImage.Information);
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
