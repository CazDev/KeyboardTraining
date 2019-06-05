namespace KeyboardTrainer.ViewModels
{
    class UserProgressSaver
    {
        public static ConfigStorage Config;

        public static void SaveProgress() => ConfigStorage.Save(Config);
        public static void LoadProgress() => Config = ConfigStorage.Load();
    }
}
