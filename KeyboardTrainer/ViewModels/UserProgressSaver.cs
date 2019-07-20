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
            Config.SelectLessonWindow.ApplySizeForWindow(win);
        }
        public static void SaveSizeForSelectLessonWindow(Window win)
        {
            Config.SelectLessonWindow = new WindowSize(win);
        }
        public static void ApplySizeForTrainWindow(Window win)
        {
            Config.TrainWindow.ApplySizeForWindow(win);
        }
        public static void SaveSizeForTrainWindow(Window win)
        {
            Config.TrainWindow = new WindowSize(win);
        }
        public static void ApplySizeForManual(Window win)
        {
            Config.ManualSize.ApplySizeForWindow(win);
        }
        public static void SaveSizeForManualSize(Window win)
        {
            Config.ManualSize = new WindowSize(win);
        }
    }
}
