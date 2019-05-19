using KeyboardTrainer.Views;
using KeyboardTrainer.Views.Learning_;
using KeyboardTrainer.Views.Manual_;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb_language.SelectedIndex = 0;
        }

        private void Btn_training_Click(object sender, RoutedEventArgs e)
        {
            TextBlock item = (TextBlock)cb_language.SelectedItem;
            MLanguage language = MLanguage.ENGLISH;

            if (item?.Text == "Russian")
            {
                language = MLanguage.RUSSIAN;
            }
            else if (item?.Text == "English")
            {
                language = MLanguage.ENGLISH;
            }
            Training trainingWindow = new Training(language);
            this.Hide();
            if (trainingWindow.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void Btn_manual_Click(object sender, RoutedEventArgs e)
        {
            Manual manual = new Manual();
            this.Hide();
            if (manual.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void Btn_learning_Click(object sender, RoutedEventArgs e)
        {
            Learning learning = new Learning();
            this.Hide();
            if (learning.ShowDialog() != null)
            {
                this.Show();
            }
        }
    }
}
