using KeyboardTrainer.Models;
using System;
using System.Windows;
using System.Windows.Forms;

namespace KeyboardTrainer.Views
{
    public partial class Settings : Form
    {
        public event Action ThemeChanged;
        public Settings()
        {
            InitializeComponent();

            AddTranslates();

            LoadShowProgress();

            lbl_title.Text = Loc.Translate("Settings");
            this.Text = Loc.Translate("Settings");
            gb_themes.Text = Loc.Translate("Settings");
            checkbx_Sound.Text = Loc.Translate("Sounds");
            btn_wipeData.Text = Loc.Translate("Wipe all data");
            btn_done.Text = Loc.Translate("Done");

            rb_Dark.Text = Loc.Translate("Dark");
            rb_Light.Text = Loc.Translate("Light");
            rb_Red.Text = Loc.Translate("Red");
            rb_Green.Text = Loc.Translate("Green");

            rb_Dark.Click += (s, e) => { UserProgressSaver.ChangeTheme(MTheme.DARK); ThemeChanged?.Invoke(); };
            rb_Light.Click += (s, e) =>{ UserProgressSaver.ChangeTheme(MTheme.LIGHT); ThemeChanged?.Invoke(); };
            rb_Red.Click += (s, e) => { UserProgressSaver.ChangeTheme(MTheme.RED); ThemeChanged?.Invoke(); };
            rb_Green.Click += (s, e) => { UserProgressSaver.ChangeTheme(MTheme.GREEN); ThemeChanged?.Invoke(); };

            btn_done.Click += (s, e) => this.Close();
        }

        private static void AddTranslates()
        {
            Loc.AddTranslate("Sounds", "Звуки");
            Loc.AddTranslate("Wipe all data", "Отчистить данные");
            Loc.AddTranslate("Themes", "Темы");
            Loc.AddTranslate("Light", "Светлая");
            Loc.AddTranslate("Dark", "Тёмная");
            Loc.AddTranslate("Red", "Красная");
            Loc.AddTranslate("Green", "Зелёная");
            Loc.AddTranslate("Done", "Готово");
        }

        void LoadShowProgress()
        {
            checkbx_Sound.Checked = UserProgressSaver.SoundOn;

            switch (UserProgressSaver.GetTheme)
            {
                case MTheme.DARK:
                    rb_Dark.Checked = true;
                    break;
                case MTheme.LIGHT:
                    rb_Light.Checked = true;
                    break;
                case MTheme.RED:
                    rb_Red.Checked = true;
                    break;
                case MTheme.GREEN:
                    rb_Green.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void Btn_wipeData_Click(object sender, System.EventArgs e)
        {
            UserProgressSaver.DeleteProgress();
            this.Close();
        }

        private void Checkbx_Sound_CheckedChanged(object sender, System.EventArgs e)
        {
            UserProgressSaver.Sounds(checkbx_Sound.Checked);
        }
    }
}