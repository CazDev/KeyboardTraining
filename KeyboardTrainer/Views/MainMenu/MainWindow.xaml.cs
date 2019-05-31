using KeyboardTrainer.Models;
using KeyboardTrainer.Views;
using KeyboardTrainer.Views.MainMenu;
using KeyboardTrainer.Views.Manual_;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    public partial class MainWindow : Window
    {
        ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new ViewModel(GetSelectedLanguage());

            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();

            this.image_githubLink.Source = Properties.Resources.githubIcon.ToImageSource();
            this.image_Info.Source = Properties.Resources.infoIcon.ToImageSource();
            this.image_Update.Source = Properties.Resources.updateIcon.ToImageSource();


            image_githubLink.MouseLeave += ImageSmaller;
            image_githubLink.MouseEnter += ImageBigger;

            image_Update.MouseLeave += ImageSmaller;
            image_Update.MouseEnter += ImageBigger;

            image_Info.MouseLeave += ImageSmaller;
            image_Info.MouseEnter += ImageBigger;

            image_githubLink.MouseDown += (s, e) => Process.Start("https://github.com/tavvi1337/KeyboardTraining");
            image_Info.MouseDown += (s, e) => MessageBox.Show($"Product version - {Updater.ThisVersion}\nDeveloped by tavvi", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            image_Update.MouseDown += (s, e) =>
            {
                try
                {
                    if (!Updater.NeedUpdate())
                    {
                        MessageBox.Show(viewModel.Translate("Updates not found"), "Updater", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        viewModel.Update();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(viewModel.Translate("Update error") + ex.ToString(), "Updater", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            };

            viewModel.Update();//check updates
            cb_language.SelectedIndex = 0;
        }

        int resizeValue = 3;
        private void ImageSmaller(object s, System.Windows.Input.MouseEventArgs e)
        {
            (s as Image).Width = (s as Image).ActualWidth + resizeValue;
            (s as Image).Height = (s as Image).ActualHeight + resizeValue;
        }
        private void ImageBigger(object s, System.Windows.Input.MouseEventArgs e)
        {
            (s as Image).Width = (s as Image).ActualWidth - resizeValue;
            (s as Image).Height = (s as Image).ActualHeight - resizeValue;
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
            image_githubLink.ToolTip = viewModel.Translate("Visit github.com");
            image_Update.ToolTip = viewModel.Translate("Check for updates");
            image_Info.ToolTip = viewModel.Translate("Show information");
        }
    }
}
