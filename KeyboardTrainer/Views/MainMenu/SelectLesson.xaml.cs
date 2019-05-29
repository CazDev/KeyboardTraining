using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer.Views.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для SelectLesson.xaml
    /// </summary>
    public partial class SelectLesson : Window
    {
        public MLanguage language { get; set; }
        ViewModel viewModel;

        public SelectLesson(MLanguage language)
        {
            InitializeComponent();
            viewModel = new ViewModel(language);
            this.language = language;
            this.Title = viewModel.Translate("Select lesson");

            for (int i = 1; i <= 17; i++)
            {
                Button btn = new Button()
                {
                    Content = viewModel.Translate("Lesson") + " " + i,
                    Height = this.Height * 0.061728,//height depends on window height
                    Width = this.Width * 0.625
                };
                btn.Click += Btn_Click;

                stackPanel.Children.Add(btn);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int numOfLesson = Convert.ToInt32((sender as Button).Content.ToString().Split(' ')[1]);//get num of lesson (written on button)

        startAgain:
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

            if (lesson.LastStatistics.Mistakes > 0 && (lesson.LastStatistics.CharsLeft.Length == 0 || string.IsNullOrWhiteSpace(lesson.LastStatistics.CharsLeft)))
            {
                MessageBoxResult retry = MessageBox.Show(viewModel.Translate("Retry") + "?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (retry == MessageBoxResult.Yes)
                {
                    goto startAgain;
                }
            }
            else if (lesson.LastStatistics.CharsLeft.Length == 0 || string.IsNullOrWhiteSpace(lesson.LastStatistics.CharsLeft))
            {
                MessageBox.Show(viewModel.Translate("You have passed the lesson"), "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //else -> user closed the window
        }
    }
}
