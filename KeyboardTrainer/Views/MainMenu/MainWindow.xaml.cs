using KeyboardTrainer.Models;
using KeyboardTrainer.Views;
using KeyboardTrainer.Views.MainMenu;
using KeyboardTrainer.Views.Manual_;
using KeyboardTrainer.Views.Training_.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    public partial class MainWindow : Window
    {
        ViewModel viewModel;
        public MainWindow()
        {
            viewModel = new ViewModel(MLanguage.ENGLISH);

            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();

            viewModel.Update();//check updates
            InitializeComponent();
            cb_language.SelectedIndex = 0;
        }

        private void Btn_myResults_Click(object sender, RoutedEventArgs e)
        {
            MLanguage language = GetSelectedLanguage();
            MyResults results = new MyResults(language);
            this.Hide();
            if (results.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private MLanguage GetSelectedLanguage()
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

            return language;
        }

        private void Btn_manual_Click(object sender, RoutedEventArgs e)
        {
            Manual manual = new Manual(GetSelectedLanguage());
            this.Hide();
            if (manual.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void Btn_learning_Click(object sender, RoutedEventArgs e)
        {
            SelectLesson selectLesson = new SelectLesson(GetSelectedLanguage());
            this.Hide();
            selectLesson.Show();
            selectLesson.Closed += (_s, _e) => this.Show();
            
        }

        private void cb_SelectedLangugeChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.ChangeLanguageTo(GetSelectedLanguage());
            this.Title = viewModel.Translate("MainWindow");
            btn_learning.Content = viewModel.Translate("Lessons");
            btn_training.Content = viewModel.Translate("My results");
            btn_manual.Content = viewModel.Translate("Manual");
        }
    }
}
