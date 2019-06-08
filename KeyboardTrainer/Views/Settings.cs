using KeyboardTrainer.ViewModels;
using System.Windows.Forms;

namespace KeyboardTrainer.Views
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            Loc.AddTranslate("Sounds", "Звуки");
            Loc.AddTranslate("Wipe all data", "Отчистить данные");
            Loc.AddTranslate("Themes", "Темы");
            Loc.AddTranslate("Light", "Светлая");
            Loc.AddTranslate("Dark", "Тёмная");
            Loc.AddTranslate("Red", "Красная");
            Loc.AddTranslate("Green", "Зелёная");

            LoadShowProgress();

            lbl_title.Text = Loc.Translate("Settings");
            groupBox.Text = Loc.Translate("Settings");
            checkbx_Sound.Text = Loc.Translate("Sounds");
            btn_wipeData.Text = Loc.Translate("Wipe all data");
            groupBox2.Text = Loc.Translate("Themes");
            btn_darkTheme.Text = Loc.Translate("Dark");
            btn_lightTheme.Text = Loc.Translate("Light");
            btn_redTheme.Text = Loc.Translate("Red");
            btn_greenTheme.Text = Loc.Translate("Green");

            btn_darkTheme.Click += (s, e) => UserProgressSaver.ChangeTheme(MTheme.DARK);
            btn_lightTheme.Click += (s, e) => UserProgressSaver.ChangeTheme(MTheme.LIGHT);
            btn_redTheme.Click += (s, e) => UserProgressSaver.ChangeTheme(MTheme.RED);
            btn_greenTheme.Click += (s, e) => UserProgressSaver.ChangeTheme(MTheme.GREEN);
        }

        void LoadShowProgress()
        {
            checkbx_Sound.Checked = UserProgressSaver.SoundOn;
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