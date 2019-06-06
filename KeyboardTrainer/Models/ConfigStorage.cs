using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KeyboardTrainer.ViewModels
{
    [Serializable]
    public class ConfigStorage
    {
        public List<int> LevelsPassed { get; set; } = new List<int>();
        public bool IsFirstProgramLoad = true;
        public bool SayAboutUpdate = true;

        internal static void Save(object config)
        {
            throw new NotImplementedException();
        }

        static string pathToDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\KeyboardTrainer\\";
        static string fileName = "data.bin";
        static string fullPath = pathToDir + fileName;

        public static void Save(ConfigStorage config)
        {
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
