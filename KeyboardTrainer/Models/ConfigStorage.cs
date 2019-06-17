using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KeyboardTrainer.ViewModels
{
    [Serializable]
    public class ConfigStorage
    {
        public List<int> LevelsPassed { get; set; } = new List<int>(); // for old serialization
        public List<int> LevelsPassed_Rus { get; set; } = new List<int>();
        public List<int> LevelsPassed_Eng { get; set; } = new List<int>();

        public bool IsFirstProgramLoad = true;
        public bool SayAboutUpdate = true;
        public bool Sounds = false;
        static bool CanSave = true;//cant save when data is wiped

        public MTheme Theme = MTheme.DARK;

        static string pathToDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\KeyboardTrainer\\";
        static string fileName = "data.bin";
        static string fullPath = pathToDir + fileName;

        public static void Save(ConfigStorage config)
        {
            if (!CanSave)
            {
                return;
            }
            if (!Directory.Exists(pathToDir))
            {
                Directory.CreateDirectory(pathToDir);
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                bf.Serialize(file, config);
            }
        }

        public static ConfigStorage Load()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream file = new FileStream(fullPath, FileMode.Open))
                {
                    ConfigStorage config = bf.Deserialize(file) as ConfigStorage;
                    if (config.LevelsPassed_Eng == null || config.LevelsPassed_Rus == null)
                    {
                        file.Close();
                        config = OldLoad();
                    }
                    
                    return config;
                }
            }
            catch
            {
                return new ConfigStorage();
            }
        }

        public void DeleteProgess()
        {
            CanSave = false;
            this.LevelsPassed = this.LevelsPassed_Eng = this.LevelsPassed_Rus = new List<int>();
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            try
            {
                Directory.Delete(pathToDir);
            }
            catch { }
            Environment.Exit(0);
        }

        private static ConfigStorage OldLoad()//old type
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream file = new FileStream(fullPath, FileMode.Open))
                {
                    ConfigStorage config = bf.Deserialize(file) as ConfigStorage;
                    config.LevelsPassed_Eng = new List<int>();

                    config.LevelsPassed_Rus = new List<int>();
                    config.LevelsPassed_Rus.AddRange(config.LevelsPassed);

                    config.Sounds = false;
                    config.Theme = MTheme.DARK;

                    return config;
                }
            }
            catch
            {
                return new ConfigStorage();
            }
        }
    }
}
