using KeyboardTrainer.Models;
using KeyboardTrainer.ViewModels;
using KeyboardTrainer.Views.Training_.Models;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer.Views.Training_.ViewModels
{
    public class ViewModel
    {
        Model Model;
        Loc loc;
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
            loc = new Loc(language);
            Model.Mistaked += (l) => this.Mistaked?.Invoke(l);

            InitTranslates();
        }

        private void InitTranslates()
        {
            //TODO: you can add new translated for string here
            AddTranslate("Lessons", "Уроки");
            AddTranslate("Please change keyboard layout", "Пожалуйста смените раскладку");
            AddTranslate("Mistakes", "Ошибки");
            AddTranslate("Total work", "Всего");
            AddTranslate("Time", "Время");
            AddTranslate("Retry", "Заново");
            AddTranslate("sec", "сек");
            AddTranslate("Type text", "Вводите текст");
            AddTranslate("Chars left", "Символов осталось");
            AddTranslate("MainWindow", "Главное окно");
            AddTranslate("Training", "Тренировка");
            AddTranslate("My results", "Мои результаты");
            AddTranslate("Manual", "Руководство");
            AddTranslate("Your speed", "Ваша скорость");
            AddTranslate("keys per minute", "символов в минуту");
            AddTranslate("You make most mistakes in", "Больше всего ошибок в");
            AddTranslate("Statistics", "Статистика");
            AddTranslate("New update found! Do you want to update now?", "Найдено новое обновление! Хотите обновиться сейчас?");
            AddTranslate("Update error", "Ошибка во время обновления");
            AddTranslate("Lesson", "Урок");
            AddTranslate("You have passed the lesson", "Вы прошли урок");
            AddTranslate("Select lesson", "Выберите урок");
        }

        public void LocalizeButtons(params Button[] buttons)
        {
            loc.AddButton(buttons);
        }

        public void AddTranslate(string eng, string rus)
        {
            loc.AddString(eng, rus);
        }

        public string Translate(string engOrRus)
        {
            return loc.Translate(engOrRus);
        }

        public void ChangeLanguageTo(MLanguage language)
        {
            Language = language;
            loc.Curr_Language = language;
            loc.TranslateButtons();
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
                bool sayAboutFail = false;
                try
                {
                    if (updater.NeedUpdate())
                    {
                        MessageBoxResult res = MessageBox.Show(Translate("New update found! Do you want to update now?"), "KeyboardTrainer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (res == MessageBoxResult.Yes)
                        {
                            sayAboutFail = true;
                            updater.Update();
                        }
                    }
                }
                catch
                {
                    if (sayAboutFail)
                    {
                        MessageBox.Show(Translate("Update error"), "Updater", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
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
                //chr = ToRussianChar(chr.ToLower());
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
                result += GetWord(mLanguage) + GetRandomSperator();
            } while (result.Length < length);
            result = result.Remove(result.Length - 1);//remove last space
            return result;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(
   [In] IntPtr hWnd,
   [Out, Optional] IntPtr lpdwProcessId
   );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout(//get current keyboard layout
            [In] int idThread
            );

        /// <summary>
        /// Вернёт Id раскладки.
        /// 1033 - eng
        /// 1049 - rus
        /// </summary>
        public ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }
        private string GetRandomSperator()
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
