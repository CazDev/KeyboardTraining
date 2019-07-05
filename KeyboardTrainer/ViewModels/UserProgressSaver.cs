using System.Windows;

namespace KeyboardTrainer.Models
{
    class UserProgressSaver
    {
        public static ConfigStorage Config;

        public static void SaveProgress()
        {
            ConfigStorage.Save(Config);
        }

        public static void LoadProgress()
        {
            Config = ConfigStorage.Load();
        }

        public static void DeleteProgress()
        {
            Config.DeleteProgess();
        }

        public static void Sounds(bool state)
        {
            Config.Sounds = state;
        }
        public static MLanguage SelectedLanguage => Config.SelectedLanguage;
        public static void SetLanguage(MLanguage language) => Config.SelectedLanguage = language;
        public static bool SoundOn => Config.Sounds;
        public static void ChangeTheme(MTheme theme)
        {
            Config.Theme = theme;
        }

        public static MTheme GetTheme => Config.Theme;
        public static void ApplySizeForSelectLessonWindow(Window win)
        {
            win.Width = Config.SelectLessonWindow.Width;
            win.Height = Config.SelectLessonWindow.Height;
        }
        public static void SaveSizeForSelectLessonWindow(Window win)
        {
            Config.SelectLessonWindow.Width = (int)win.ActualWidth;
            Config.SelectLessonWindow.Height = (int)win.ActualHeight;
        }
        public static void ApplySizeForTrainWindow(Window win)
        {
            win.Width = Config.TrainWindow.Width;
            win.Height = Config.TrainWindow.Height;
        }
        public static void SaveSizeForTrainWindow(Window win)
        {
            Config.TrainWindow.Width = (int)win.ActualWidth;
            Config.TrainWindow.Height = (int)win.ActualHeight;
        }
        public static void ApplySizeForManual(Window win)
        {
            win.Width = Config.ManualSize.Width;
            win.Height = Config.ManualSize.Height;
        }
        public static void SaveSizeForManualSize(Window win)
        {
            Config.ManualSize.Width = (int)win.ActualWidth;
            Config.ManualSize.Height = (int)win.ActualHeight;
        }
    }
}
