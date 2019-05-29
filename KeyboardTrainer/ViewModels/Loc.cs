using System.Collections.Generic;
using System.Linq;
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
        public Loc(MLanguage language)
        {
            this.Curr_Language = language;
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
                foreach (string currValue in eng_rus.Values)
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
                foreach (Button btn in Buttons)
                {
                    if (eng_rus.TryGetValue(btn.Content.ToString(), out string value))
                    {
                        btn.Content = value;
                    }
                }
            }
            if (Curr_Language == MLanguage.ENGLISH)//translate to rus find key by value
            {
                foreach (Button btn in Buttons)
                {
                    foreach (string currValue in eng_rus.Values)
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
