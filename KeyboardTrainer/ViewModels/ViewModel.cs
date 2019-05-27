using KeyboardTrainer.Models;
using KeyboardTrainer.Views.Training_.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KeyboardTrainer.Views.Training_.ViewModels
{
    public class ViewModel
    {
        Model Model;

        Random rnd = new Random();
        public MLanguage Language { get; private set; }
        /// <summary>
        /// Length of string before sending chars
        /// </summary>
        public int FirstLength { get; private set; }
        public delegate void Mistake(string letter);
        /// <summary>
        /// Invokes on user makes mistake when send wrong char
        /// </summary>
        public event Mistake Mistaked;
        /// <summary>
        /// string left to type
        /// </summary>
        public string CharsLeft => Model.ChrsLeft;
        public double Speed
        {
            get
            {
                return FirstLength / ((DateTime.Now - Begin).TotalMilliseconds / 60000);
            }
        }
        public DateTime Begin { get; set; }


        public delegate void StatisticChanges(Statistics statistics);
        public event StatisticChanges StatisticChanged;

        public ViewModel(MLanguage language)
        {
            this.Model = new Model();
            this.Language = language;
            Model.Mistaked += (l) => this.Mistaked?.Invoke(l);
        }

        /// <summary>
        /// Finds new version, asks user, update, restart app
        /// </summary>
        public void Update()
        {
            Updater updater = new Updater();
            Task checkNewVersion = new Task(() =>
            {
                Thread.Sleep(1000);
                try
                {
                    if (updater.NeedUpdate())
                    {
                        MessageBoxResult res = MessageBox.Show("New update found! Do you want to update it now?", "KeyboardTrainer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (res == MessageBoxResult.Yes)
                        {
                            updater.Update();
                        }
                    }
                }
                catch { }
            });
            checkNewVersion.Start();
        }

        /// <summary>
        /// retunrs true if it is right char.
        /// Use: KeyConverter kc = new KeyConverter(); ConvertToString(e.Key);
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public bool? SendChar(string chr)
        {
            if (Language == MLanguage.RUSSIAN)
            {
                chr = ToRussianChar(chr.ToLower());
            }
            if (chr.ToLower() == "space")
            {
                chr = " ";
            }

            bool? res = Model.SendChar(chr);

            Statistics statistics = new Statistics(Model.ChrsLeft, Model.Mistakes, Speed, DateTime.Now - Begin);
            StatisticChanged?.Invoke(statistics);

            return res;
        }
        /// <summary>
        /// New string (random)
        /// </summary>
        /// <param name="updateTime">update Begin datetime</param>
        public void NewRound(bool updateTime = true)
        {
            if (updateTime)
            {
                Begin = DateTime.Now;
            }

            string rndString = GetRandomString();
            Model.NewRound(rndString);
            FirstLength = rndString.Length;

            Statistics statistics = new Statistics(Model.ChrsLeft, Model.Mistakes);
            StatisticChanged?.Invoke(statistics);
        }
        /// <summary>
        /// New string
        /// </summary>
        /// <param name="input">Custom string</param>
        /// <param name="updateTime">update Begin datetime</param>
        public void NewRound(string input, bool updateTime = true)
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
        public string GetWord(MLanguage mLanguage)//depends on this.Language
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
        public string GetString(MLanguage mLanguage, int length)
        {
            string result = "";
            do
            {
                result += GetWord(mLanguage) + " ";
            } while (result.Length < length);
            result = result.Remove(result.Length - 1);//remove last space
            return result;
        }

        private string ToRussianChar(string engChar)
        {
            if (engChar == "oem3")
            {
                return "ё";
            }
            if (engChar == "q")
            {
                return "й";
            }
            else if (engChar == "w")
            {
                return "ц";
            }
            else if (engChar == "e")
            {
                return "у";
            }
            else if (engChar == "r")
            {
                return "к";
            }
            else if (engChar == "t")
            {
                return "е";
            }
            else if (engChar == "y")
            {
                return "н";
            }
            else if (engChar == "u")
            {
                return "г";
            }
            else if (engChar == "i")
            {
                return "ш";
            }
            else if (engChar == "o")
            {
                return "щ";
            }
            else if (engChar == "p")
            {
                return "з";
            }
            else if (engChar == "oemopenbrackets")
            {
                return "х";
            }
            else if (engChar == "oem6")
            {
                return "ъ";
            }
            else if (engChar == "a")
            {
                return "ф";
            }
            else if (engChar == "s")
            {
                return "ы";
            }
            else if (engChar == "d")
            {
                return "в";
            }
            else if (engChar == "f")
            {
                return "а";
            }
            else if (engChar == "g")
            {
                return "п";
            }
            else if (engChar == "h")
            {
                return "р";
            }
            else if (engChar == "j")
            {
                return "о";
            }
            else if (engChar == "k")
            {
                return "л";
            }
            else if (engChar == "l")
            {
                return "д";
            }
            else if (engChar == "oem1")
            {
                return "ж";
            }
            else if (engChar == "oemquotes")
            {
                return "э";
            }
            else if (engChar == "z")
            {
                return "я";
            }
            else if (engChar == "x")
            {
                return "ч";
            }
            else if (engChar == "c")
            {
                return "с";
            }
            else if (engChar == "v")
            {
                return "м";
            }
            else if (engChar == "b")
            {
                return "и";
            }
            else if (engChar == "n")
            {
                return "т";
            }
            else if (engChar == "m")
            {
                return "ь";
            }
            else if (engChar == "oemcomma")
            {
                return "б";
            }
            else if (engChar == "oemperiod")
            {
                return "ю";
            }
            return engChar;
        }
        private string GetRandomString()
        {
            char[] chrs = new char[2];
            if (Language == MLanguage.ENGLISH)
            {
                chrs[0] = 'a';
                chrs[1] = 'z';
            }
            else if (Language == MLanguage.RUSSIAN)
            {
                chrs[0] = 'а';
                chrs[1] = 'я';
            }

            string result = "";
            FirstLength = 100;
            for (int i = 0; i < FirstLength; i++)
            {
                result += (char)rnd.Next((int)chrs[0], (int)chrs[1]);
            }
            return result;
        }
    }
}
