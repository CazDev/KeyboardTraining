using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeyboardTrainer.ViewModels
{
    /// <summary>
    /// Localization
    /// </summary>
    public class Loc
    {
        Dictionary<string, string> eng_rus = new Dictionary<string, string>();
        List<Button> Buttons = new List<Button>();
        public MLanguage Curr_Language;
        bool inited = false;
        public Loc(MLanguage language)
        {
            this.Curr_Language = language;
            if (!inited)
            {
                init();
            }
        }

        void init()
        {
            eng_rus.Add("Training", "Тренировка");
            eng_rus.Add("My results", "Мои результаты");
            eng_rus.Add("Manual", "Руководство");
            eng_rus.Add("Your speed", "Ваша скорость");
            eng_rus.Add("keys per minute", "символов в минуту");
            eng_rus.Add("You make most mistakes in", "Больше всего ошибок в");
            eng_rus.Add("Statistics", "Статистика");
            inited = true;
        }

        public void AddButton(params Button[] buttons)
        {
            Buttons.AddRange(buttons.ToList());
        }

        public void AddString(string eng, string rus)
        {
            if (eng_rus.TryGetValue(eng, out string v))
            {
                return;
            }
            eng_rus.Add(eng, rus);
        }
        public string Translate(string engOrRus)
        {
            if (Curr_Language == MLanguage.RUSSIAN)//translate to rus
            {
                if (eng_rus.TryGetValue(engOrRus, out string value))
                {
                    return value;
                }
            }
            if (Curr_Language == MLanguage.ENGLISH)//translate to rus find key by value
            {
                foreach (var currValue in eng_rus.Values)
                {
                    if (currValue == engOrRus)
                    {
                        return KeyByValue(eng_rus, currValue);
                    }
                }
            }
            return engOrRus;
        }
        /// <summary>
        /// Translate
        /// </summary>
        /// <returns></returns>
        public void TranslateButtons()
        {
            if (Curr_Language == MLanguage.RUSSIAN)//translate to rus
            {
                foreach (var btn in Buttons)
                {
                    if (eng_rus.TryGetValue(btn.Content.ToString(), out string value))
                    {
                        btn.Content = value;
                    }
                }
            }
            if (Curr_Language == MLanguage.ENGLISH)//translate to rus find key by value
            {
                foreach (var btn in Buttons)
                {
                    foreach (var currValue in eng_rus.Values)
                    {
                        if (currValue == btn.Content.ToString())
                        {
                            btn.Content = KeyByValue(eng_rus, currValue);
                            break;
                        }
                    }
                }
            }
        }
        string KeyByValue(Dictionary<string, string> dict, string val)
        {
            string key = null;
            foreach (KeyValuePair<string, string> pair in dict)
            {
                if (pair.Value == val)
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }
    }
}
