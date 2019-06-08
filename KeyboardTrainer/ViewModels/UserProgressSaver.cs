namespace KeyboardTrainer.ViewModels
{
    class UserProgressSaver
    {
        public static ConfigStorage Config;

        public static void SaveProgress() => ConfigStorage.Save(Config);
        public static void LoadProgress() => Config = ConfigStorage.Load();
        public static void DeleteProgress() => Config.DeleteProgess();
        public static void Sounds(bool state) => Config.Sounds = state;
        public static bool SoundOn => Config.Sounds;
    }
}
