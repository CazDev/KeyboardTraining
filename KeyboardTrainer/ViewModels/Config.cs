using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KeyboardTrainer.ViewModels
{
    [Serializable]
    public class Config
    {
        public List<int> LevelsPassed { get; set; } = new List<int>();
        static string pathToDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\KeyboardTrainer\\";
        static string fileName = "data.bin";

        public static void Save(Config config)
        {
            if (!Directory.Exists(pathToDir))
            {
                Directory.CreateDirectory(pathToDir);
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(pathToDir + fileName, FileMode.OpenOrCreate);
            bf.Serialize(fs, config);
            fs.Flush();
            fs.Close();
        }

        public static Config Load()
        {
            try
            {

                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(pathToDir + fileName, FileMode.OpenOrCreate);
                Config config = bf.Deserialize(fs) as Config;
                fs.Flush();
                fs.Close();
                return config;
            }
            catch
            {
                return new Config();
            }
        }
    }
}
