using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.Models;
using System;
using System.Runtime.InteropServices;

namespace KeyboardTrainer.Views.Training_.ViewModels
{
    public static class TextType
    {
        static TypeLogic Model;
        static Random rnd = new Random();
        /// <summary>
        /// Length of string before sending chars
        /// </summary>
        private static int FirstLength { get; set; }
        /// <summary>
        /// Speed of user's typing
        /// </summary>
        private static double Speed => FirstLength / ((DateTime.Now - Begin).TotalMilliseconds / 60000);


        public delegate void Mistake(string letter);
        /// <summary>
        /// Invokes on user makes mistake when send wrong char
        /// </summary>
        public static event Mistake Mistaked;
        /// <summary>
        /// string left to type
        /// </summary>
        public static string CharsLeft => Model.ChrsLeft;
        public static DateTime Begin { get; set; }


        public delegate void StatisticChanges(Statistics statistics);
        public static event StatisticChanges StatisticChanged;

        static TextType()
        {
            Model = new TypeLogic();

            Model.Mistaked += (l) => Mistaked?.Invoke(l);
        }


        /// <summary>
        /// returns true if it is right char.
        /// Use: KeyConverter kc = new KeyConverter(); ConvertToString(e.Key);
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static bool? SendChar(string chr)
        {
            bool? res = Model.SendChar(chr);

            Statistics statistics = new Statistics(Model.ChrsLeft, Model.Mistakes, Speed, DateTime.Now - Begin);
            StatisticChanged?.Invoke(statistics);

            return res;
        }
        /// <summary>
        /// New string
        /// </summary>
        /// <param name="input">Custom string</param>
        /// <param name="updateTime">update Begin datetime</param>
        public static void NewRound(string input, bool updateTime = true)
        {
            if (updateTime)
            {
                Begin = DateTime.Now;
            }

            Model.NewRound(input);
            FirstLength = input.Length;

            Statistics statistics = new Statistics(Model.ChrsLeft, Model.Mistakes);
            StatisticChanged?.Invoke(statistics);
        }

        /// <summary>
        /// Gets random word
        /// </summary>
        /// <param name="mLanguage">Language</param>
        /// <returns></returns>
        private static string GetWordFromDataBase(MLanguage mLanguage)//depends on this.Language
        {
            if (mLanguage == MLanguage.ENGLISH)
            {
                return Database.english[rnd.Next(0, Database.english.Length)];
            }
            else if (mLanguage == MLanguage.RUSSIAN)
            {
                return Database.russian[rnd.Next(0, Database.russian.Length)];
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Based on GetWord
        /// </summary>
        /// <returns></returns>
        public static string GetString(MLanguage mLanguage, int length)
        {
            string result = "";

            string sperator = "";
            string word = "";
            do
            {
                string previousSperator = sperator;
                sperator = GetRandomSperator();
                word = GetWordFromDataBase(mLanguage);

                if (previousSperator == ", " || previousSperator == ". " ||
                    previousSperator == "! " || previousSperator == "? " 
                    || previousSperator == "" /* if first word*/)
                {
                    word = char.ToUpper(word[0]) + word.Substring(1); //first letter to uppercase
                }

                result += word + sperator;
            } while (result.Length < length);

            result = result.Remove(result.Length - 1);//remove last space
            return result;
        }

        [DllImport("user32.dll", SetLastError = true)]//used to get current layout
        static extern int GetWindowThreadProcessId([In] IntPtr hWnd, [Out, Optional] IntPtr lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow(); //used to get current layout

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout([In] int idThread); //get current keyboard layout

        /// <summary>
        /// returns Id of keyboard layout.
        /// 1033 - eng
        /// 1049 - rus
        /// </summary>
        public static ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }
        private static string GetRandomSperator()
        {
            string[] sperators =
            {
                ", ",
                " ",
                ". ",
                "! ",
                "? "
            };
            return sperators[rnd.Next(0, sperators.Length)];
        }
    }
}
