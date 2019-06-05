using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer.Views.MainMenu
{
    /// <summary>
    /// Logic for SelectLesson.xaml
    /// </summary>
    public partial class SelectLesson : Window
    {
        public MLanguage language { get; set; }
        List<Button> buttons = new List<Button>();
        public SelectLesson(MLanguage language)
        {
            InitializeComponent();
            ViewModel.Current_Language = language;
            this.language = language;
            this.Title = ViewModel.Translate("Select lesson");

            for (int i = 1; i <= 17; i++)
            {
                string ButtonSym = (ViewModel.Config.LevelsPassed.Contains(i)) ? "✓ " : "X "; 
                Button btn = new Button()
                {
                    Content = ButtonSym + ViewModel.Translate("Lesson") + " " + i,
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
            int numOfLesson = Convert.ToInt32((sender as Button).Content.ToString().Split(' ')[2]);//get num of lesson (written on button)

            MyResults lesson = new MyResults(language, numOfLesson);
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

            if (lesson.LastStatistics.CharsLeft.Length == 0 || string.IsNullOrWhiteSpace(lesson.LastStatistics.CharsLeft))
            {
                if (!ViewModel.Config.LevelsPassed.Contains(numOfLesson))
                {
                    MessageBox.Show(ViewModel.Translate("You have passed the lesson"), "", MessageBoxButton.OK, MessageBoxImage.Information);
                    ViewModel.Config.LevelsPassed.Add(numOfLesson);
                    UpdateButtonsText();
                }
            }
            //else -> user closed the window
        }

        public void UpdateButtonsText()
        {
            foreach (var btn in buttons)
            {
                int numOfLesson = Convert.ToInt32(btn.Content.ToString().Split(' ')[2]);

                if (ViewModel.Config.LevelsPassed.Contains(numOfLesson))
                {
                    string ButtonSym = (ViewModel.Config.LevelsPassed.Contains(numOfLesson)) ? "✓ " : "X ";
                    btn.Content = ButtonSym + ViewModel.Translate("Lesson") + " " + numOfLesson;
                }
            }
        }
    }
}
