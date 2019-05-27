using KeyboardTrainer.Views.Training_.Models;
using System;
using System.Threading.Tasks;

namespace KeyboardTrainer.Views.Training_.ViewModels
{
    class ViewModel
    {
        Model Model;

        Random rnd = new Random();
        public MLanguage Language { get; private set; }
        public int FirstLength { get; private set; }
        public event Action Mistaked;
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
            Model.Mistaked += () => this.Mistaked?.Invoke();
            //TODO: Task sendsat
        }

        void SendStatistics()
        {

        }

        /// <summary>
        /// retunrs true if it is right chat
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public bool? SendChar(string chr)
        {
            if (Language == MLanguage.RUSSIAN)
            {
                chr = ToRussianChar(chr.ToLower());
            }

            bool? res = Model.SendChar(chr);

            Statistics statistics = new Statistics(Model.ChrsLeft, Model.Mistakes, Speed, DateTime.Now - Begin);
            StatisticChanged?.Invoke(statistics);

            return res;
        }
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
