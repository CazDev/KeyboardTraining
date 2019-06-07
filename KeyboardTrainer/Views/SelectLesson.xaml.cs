using KeyboardTrainer.ViewModels;
using KeyboardTrainer.Views.Training_.ViewModels;
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

            for (int i = 1; i <= 17; i++)
            {
                string ButtonSym = (UserProgressSaver.Config.LevelsPassed.Contains(i)) ? "✓ " : "X "; 
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
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int numOfLesson = Convert.ToInt32((sender as Button).Content.ToString().Split(' ').Last());//get num of lesson (written on button)

            MyResults lesson = new MyResults(numOfLesson);
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
                if (!UserProgressSaver.Config.LevelsPassed.Contains(numOfLesson))
                {
                    SilenceMessageBox.Show(Loc.Translate("You have passed the lesson"), "", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserProgressSaver.Config.LevelsPassed.Add(numOfLesson);
                    UpdateButtonsText();
                }
            }
            //else -> user closed the window
        }

        public void UpdateButtonsText()
        {
            foreach (var btn in buttons)
            {
                int numOfLesson = Convert.ToInt32(btn.Content.ToString().Split(' ').Last());

                if (UserProgressSaver.Config.LevelsPassed.Contains(numOfLesson))
                {
                    string ButtonSym = (UserProgressSaver.Config.LevelsPassed.Contains(numOfLesson)) ? "✓ " : "X ";
                    btn.Content = ButtonSym + Loc.Translate("Lesson") + " " + numOfLesson;
                }
            }
        }
    }
}
