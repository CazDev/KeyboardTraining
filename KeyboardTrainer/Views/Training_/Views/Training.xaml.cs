using KeyboardTrainer.Views.Training_.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace KeyboardTrainer.Views
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class Training : Window
    {
        ViewModel viewModel;
        public Training(MLanguage language)
        {
            InitializeComponent();
            viewModel = new ViewModel(language);

            viewModel.StatisticChanged += StatisticChanged;
            this.KeyDown += Training_KeyDown;

            viewModel.NewRound();
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
                MessageBox.Show($"Your speed {statistics.Speed.ToString("G")} keys per minute", "Statistics", MessageBoxButton.OK, MessageBoxImage.Information);
                viewModel.NewRound(); // txt will change text using event StatisticChanged
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
    }
}
