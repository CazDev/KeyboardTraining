using KeyboardTrainer.ViewModels;
using KeyboardTrainer.Views;
using KeyboardTrainer.Views.MainMenu;
using KeyboardTrainer.Views.Manual_;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    public partial class MainWindow : Window//TODO: add back btn to my results window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loc.Curr_Language = GetSelectedLanguage();
            UserProgressSaver.LoadProgress();

            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();
            this.image_githubLink.Source = Properties.Resources.githubIcon.ToImageSource();
            this.image_Info.Source = Properties.Resources.infoIcon.ToImageSource();
            this.image_Update.Source = Properties.Resources.updateIcon.ToImageSource();

            InitEvents();

            AppUpdater.Update(false);//check updates
            cb_language.SelectedIndex = 0;
        }

        private void InitEvents()
        {
            this.Closing += (s, e) => UserProgressSaver.SaveProgress();

            image_githubLink.MouseLeave += ImageSmaller;
            image_githubLink.MouseEnter += ImageBigger;

            image_Update.MouseLeave += ImageSmaller;
            image_Update.MouseEnter += ImageBigger;

            image_Info.MouseLeave += ImageSmaller;
            image_Info.MouseEnter += ImageBigger;

            image_githubLink.MouseDown += (s, e) => Process.Start("https://github.com/tavvi1337/KeyboardTraining");
            image_Info.MouseDown += (s, e) => SilenceMessageBox.Show($"{Loc.Translate("Product version")} - {GitUpdater.ThisVersion}\n{Loc.Translate("Developed by tavvi")}", Loc.Translate("Information"), MessageBoxButton.OK, MessageBoxImage.Information);
            image_Update.MouseDown += (s, e) => UpdateMessage();
        }

        static void UpdateMessage()
        {
            try
            {
                if (!AppUpdater.NeedUpdate)
                {
                    SilenceMessageBox.Show(Loc.Translate("Updates not found"), Loc.Translate("Updater"), MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    AppUpdater.Update(true);
            }
            catch (Exception ex)
            {
                SilenceMessageBox.Show(Loc.Translate("Update error") + ex.ToString(), Loc.Translate("Updater"), MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
            MyResults results = new MyResults();
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
            this.Hide();
            Manual manual = new Manual();
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
            Loc.Curr_Language = GetSelectedLanguage();
            this.Title = Loc.Translate("MainWindow");

            btn_learning.Content = Loc.Translate("Lessons");
            btn_training.Content = Loc.Translate("My results");
            btn_manual.Content = Loc.Translate("Manual");
            image_githubLink.ToolTip = Loc.Translate("Visit github.com");
            image_Update.ToolTip = Loc.Translate("Check for updates");
            image_Info.ToolTip = Loc.Translate("Show information");
        }
    }
}
