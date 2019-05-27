using KeyboardTrainer.Models;
using KeyboardTrainer.Views;
using KeyboardTrainer.Views.MainMenu.Learning_;
using KeyboardTrainer.Views.Manual_;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Updater updater = new Updater();
        public MainWindow()
        {
            InitializeComponent();
            Task checkNewVersion = new Task(() =>
            {
                Thread.Sleep(1000);
                try
                {
                    if (updater.NeedUpdate())
                    {
                        MessageBoxResult res = MessageBox.Show("New update found! Do you want to update it now?", "KeyboardTrainer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (res == MessageBoxResult.Yes)
                        {
                            updater.Update();
                        }
                    }
                }
                catch { }
            });
            checkNewVersion.Start();

            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();
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
            Manual manual = new Manual();
            this.Hide();
            if (manual.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void Btn_learning_Click(object sender, RoutedEventArgs e)
        {
            Training learning = new Training(GetSelectedLanguage());
            this.Hide();
            if (learning.ShowDialog() != null)
            {
                this.Show();
            }
        }
    }
}
