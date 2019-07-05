using System.Collections.Generic;

namespace KeyboardTrainer.Models
{
    /// <summary>
    /// Localization, translator
    /// </summary>
    public static class Loc
    {
        static Dictionary<string, string> eng_rus = new Dictionary<string, string>();
        static public MLanguage Curr_Language;

        static Loc()
        {
            Curr_Language = MLanguage.ENGLISH; //default language
            InitTranslates();
        }
        private static void InitTranslates()
        {
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
            AddTranslate("Updates not found", "Обновления не найдены");
            AddTranslate("Check for updates", "Проверьте наличие обновлений");
            AddTranslate("Visit github.com", "Посетить github.com");
            AddTranslate("Show information", "Показать информацию");
            AddTranslate("Product version", "Версия продукта");
            AddTranslate("Developed by tavvi", "Разработано tavvi");
            AddTranslate("Information", "Информация");
            AddTranslate("Updater", "Проверка обновлений");
            AddTranslate("Next >>", "Далее >>");
            AddTranslate("Exit", "Выйти");
            AddTranslate("Settings", "Настройки");
        }

        public static void AddTranslate(string eng, string rus)
        {
            if (eng_rus.TryGetValue(eng, out string v))
            {
                return;
            }
            eng_rus.Add(eng, rus);
        }
        public static string Translate(string engOrRus)
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
        /// Get key by value
        /// </summary>
        /// <returns></returns>
        static string KeyByValue(Dictionary<string, string> dict, string val)
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
