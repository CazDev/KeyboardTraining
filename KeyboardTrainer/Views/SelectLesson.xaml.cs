using KeyboardTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer.Views.MainMenu
{
    /// <summary>
    /// Logic for SelectLesson.xaml
    /// </summary>
    public partial class SelectLesson : Window
    {
        List<Button> buttons = new List<Button>();
        public SelectLesson(MLanguage language)
        {
            InitializeComponent();

            this.Title = Loc.Translate("Select lesson");

            stackPanel.MouseLeftButtonDown += (s, e) => this.DragMove();
            btn_back.MouseDown += (s, e) => { UserProgressSaver.SaveSizeForSelectLessonWindow(this); this.Close(); };
            btn_maximize.MouseDown += (s, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    ResizeMode = ResizeMode.NoResize;
                    WindowState = WindowState.Maximized;
                });
            };
            btn_normalize.MouseDown += (s, e) => 
            {
                Dispatcher.Invoke(() =>
                {
                    ResizeMode = ResizeMode.CanResize;
                    WindowState = WindowState.Normal;
                });
            };

            for (int i = 1; i <= 17; i++)
            {
                string ButtonSym;
                ButtonSym = GetLessonPrefix(i);

                Button btn = new Button()
                {
                    Content = ButtonSym + Loc.Translate("Lesson") + " " + i,
                    Height = this.Height * 0.061728,//height depends on window height
                    Width = this.Width * 0.625
                };
                btn.Click += Btn_Click;

                stackPanel.Children.Add(btn);
                buttons.Add(btn);
            }

            UserProgressSaver.ApplySizeForSelectLessonWindow(this);
            this.ChangeTheme(grid, UserProgressSaver.GetTheme);
            this.ChangeTheme(stackPanel, UserProgressSaver.GetTheme);
        }

        private static string GetLessonPrefix(int numOfLesson)
        {
            string ButtonSym;
            if (Loc.Curr_Language == MLanguage.RUSSIAN)
            {
                ButtonSym = (UserProgressSaver.Config.LevelsPassed_Rus.Contains(numOfLesson)) ? "✓ " : "X ";
            }
            else
            {
                ButtonSym = (UserProgressSaver.Config.LevelsPassed_Eng.Contains(numOfLesson)) ? "✓ " : "X ";
            }

            return ButtonSym;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int numOfLesson = Convert.ToInt32((sender as Button).Content.ToString().Split(' ').Last());//get num of lesson (written on button)

            Train lesson = new Train(numOfLesson);
            this.Hide();
            try
            {
                lesson.ShowDialog();
            }
            catch { }
            this.Show();

            if (lesson.LastStatistics == null)
            {
                return;
            }

            if (lesson.LastStatistics.Mistakes == 0 && (lesson.LastStatistics.CharsLeft.Length == 0 || string.IsNullOrWhiteSpace(lesson.LastStatistics.CharsLeft)))
            {
                if (Loc.Curr_Language == MLanguage.RUSSIAN)
                {
                    if (!UserProgressSaver.Config.LevelsPassed_Rus.Contains(numOfLesson))
                    {
                        SilenceMessageBox.Show(Loc.Translate("You have passed the lesson"), "", MessageBoxButton.OK, MessageBoxImage.Information);
                        UserProgressSaver.Config.LevelsPassed_Rus.Add(numOfLesson);
                        UpdateButtonsText();
                    }
                }
                else if (Loc.Curr_Language == MLanguage.ENGLISH)
                {
                    if (!UserProgressSaver.Config.LevelsPassed_Eng.Contains(numOfLesson))
                    {
                        SilenceMessageBox.Show(Loc.Translate("You have passed the lesson"), "", MessageBoxButton.OK, MessageBoxImage.Information);
                        UserProgressSaver.Config.LevelsPassed_Eng.Add(numOfLesson);
                        UpdateButtonsText();
                    }
                }
            }
            //else -> user closed the window
        }

        public void UpdateButtonsText()
        {
            foreach (Button btn in buttons)
            {
                int numOfLesson = Convert.ToInt32(btn.Content.ToString().Split(' ').Last());

                if (UserProgressSaver.Config.LevelsPassed_Rus.Contains(numOfLesson))
                {
                    string ButtonSym = GetLessonPrefix(numOfLesson);
                    btn.Content = ButtonSym + Loc.Translate("Lesson") + " " + numOfLesson;
                }
            }
        }
    }
}
