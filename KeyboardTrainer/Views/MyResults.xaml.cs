using KeyboardTrainer.ViewModels;
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
        Random rnd = new Random();
        readonly List<string> mostMistakeLetters = new List<string>();
        bool IsTimerTicking = false; //timer before game 
        bool LessonMode { get; set; }
        public Statistics LastStatistics { get; set; }
        bool FormIsClosed = false;
        string avaibleChrs;

        /// <summary>
        /// Get results
        /// </summary>
        /// <param name="language"></param>
        public MyResults()
        {
            InitializeComponent();

            this.Title = Loc.Translate("My results");            
            LessonMode = false;

            TranslateUIElements();
            InitEvents();
            StartGame();
            StartTimeCounter();
        }

        /// <summary>
        /// Lesson mode
        /// </summary>
        /// <param name="language"></param>
        /// <param name="numOfLesson"></param>
        public MyResults(int numOfLesson)
        {
            if (numOfLesson < 1 || numOfLesson > 18)
            {
                throw new ArgumentOutOfRangeException();
            }

            InitializeComponent();
            this.Title = Loc.Translate("Lesson") + " " + numOfLesson;
            LessonMode = true;

            avaibleChrs = GetAvaibleChrs(Loc.Curr_Language, numOfLesson);

            TranslateUIElements();
            InitEvents();
            StartGame();
            StartTimeCounter();
        }

        private void InitEvents()
        {
            this.Closing += (s, e) => FormIsClosed = true;
            TextType.StatisticChanged += StatisticChanged;
            TextType.Mistaked += Mistaked;
            this.TextInput += Win_TextInput;
            lbl_retry.MouseDown += (s, e) => StartGame();
            this.MouseLeftButtonDown += (s, e) => this.DragMove();
            this.btn_back.Click += (s, e) => this.Close();
        }

        private void TranslateUIElements()
        {
            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();
            lbl_retry.Text = Loc.Translate("Retry");
            textInfo.Text = Loc.Translate("Type text");
            lbl_retry.Text = Loc.Translate("Retry");
            textInfo.Text = Loc.Translate("Type text");

            lbl_left.Content = $"{Loc.Translate("Chars left")}: 0";
            lbl_mistakes.Content = $"{Loc.Translate("Mistakes")}: 0";
            lbl_time.Content = $"{Loc.Translate("Time")}: 0.0{Loc.Translate("sec")}";
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

            result = result.RemoveSpacesFromEnd();

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

        private void StartTimeCounter()
        {
            System.Timers.Timer updateTimeLabel = new System.Timers.Timer(100)
            {
                Enabled = true
            };
            updateTimeLabel.Elapsed += (s, e) =>
            {
                try
                {
                    if (FormIsClosed)
                    {
                        return;
                    }
                    Dispatcher.Invoke(() =>
                    {
                        if ((TextType.Begin.Year != 1) && (!IsTimerTicking))//not inited or stopped && timer is not counting
                    {
                            lbl_time.Content = $"{Loc.Translate("Time")}: {(DateTime.Now - TextType.Begin).TotalSeconds.ToString("0.0")}{Loc.Translate("sec")}";
                        }
                        else
                            lbl_time.Content = $"{Loc.Translate("Time")}: 0{Loc.Translate("sec")}";
                    });
                }
                catch { }
            };
        }

        private void Win_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length < 1)
            {
                return;
            }

            char keyChar = e.Text[0];

            if (IsTimerTicking)
            {
                return;
            }

            TextType.SendChar(keyChar.ToString());
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

            if (LessonMode)
            {
                customString = GetStringUsingChars(avaibleChrs, 100);
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
                    if (KeyBoardLayoutIsRight())
                    {
                        break;
                    }
                    else//if keyboard layout is wrong
                    {
                        Dispatcher.Invoke(() =>
                        {
                            textblockText.Text = Loc.Translate("Please change keyboard layout");
                        });
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }

                StartGameBeforeTimer(customString);
            });
            askToChangeLayout.Start();
        }
        bool KeyBoardLayoutIsRight()
        {
            ushort keybaordLayout = TextType.GetKeyboardLayout();
            if (Loc.Curr_Language == MLanguage.ENGLISH && keybaordLayout == 1033)
            {
                return true;
            }
            else if (Loc.Curr_Language == MLanguage.RUSSIAN && keybaordLayout == 1049)
            {
                return true;
            }
            return false;
        }

        private void StartGameBeforeTimer(string customString = "")
        {
            Task timerBeforeStart = new Task(() =>
            {
                ShowTimer(3);
                Dispatcher.Invoke(() =>
                {
                    textblockText.TextAlignment = TextAlignment.Left;
                });
                if (FormIsClosed)
                {
                    IsTimerTicking = false;
                    return;
                }
                if (customString == "")
                {
                    TextType.NewRound(TextType.GetString(Loc.Curr_Language, 100));
                }
                else
                {
                    TextType.NewRound(customString);
                }
                IsTimerTicking = false;
            });
            timerBeforeStart.Start();
        }

        private void ShowTimer(int timeSeconds)
        {
            for (int i = timeSeconds; i > 0; i--)
            {
                Dispatcher.Invoke(() =>
                {
                    if (FormIsClosed)
                    {
                        IsTimerTicking = false;
                        return;
                    }
                    textblockText.Text = i.ToString();
                });
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
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
                ShowStatisticsOnWindow(statistics);
            });
            if (statistics.CharsLeft.Length == 0)
            {
                ShowEndMessage(statistics);
                if (LessonMode)
                {
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            this.DialogResult = true;
                        });
                    }
                    catch { }
                }
                else
                {
                    StartGame();
                    mostMistakeLetters.Clear();
                }
            }
        }

        private void ShowStatisticsOnWindow(Statistics statistics)
        {
            lbl_left.Content = $"{Loc.Translate("Chars left")}: {statistics.CharsLeft.Length}";
            lbl_mistakes.Content = $"{Loc.Translate("Mistakes")}: {statistics.Mistakes}";

            lbl_time.Content = $"{Loc.Translate("Time")}: {statistics.Time.TotalSeconds.ToString("0.0")}{Loc.Translate("sec")}";
            textblockText.Text = statistics.CharsLeft;
        }

        private struct NumOfLetter
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
            if (FormIsClosed)
            {
                return;
            }

            string str_mistakeLetters = GetStringMistakesInEachLetter();
            TextType.Begin = new DateTime(1, 1, 1);//stop time counter (year = 1)
            ShowStatistics(statistics.Speed, str_mistakeLetters);
        }
        void ShowStatistics(double Speed, string str_mistakeLetters)
        {
            if (string.IsNullOrWhiteSpace(str_mistakeLetters))
            {
                SilenceMessageBox.Show($"{Loc.Translate("Your speed")} {Speed.ToString("0.00")} {Loc.Translate("keys per minute")}.", Loc.Translate("Statistics"), MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SilenceMessageBox.Show($"{Loc.Translate("Your speed")} {Speed.ToString("0.00")} {Loc.Translate("keys per minute")}.\n{Loc.Translate("You make most mistakes in")}:\n{str_mistakeLetters}", Loc.Translate("Statistics"), MessageBoxButton.OK, MessageBoxImage.Information);
            }
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