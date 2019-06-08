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

            LoadProgress();

            lbl_title.Text = Loc.Translate("Settings");
            groupBox.Text = Loc.Translate("Settings");
            checkbx_Sound.Text = Loc.Translate("Sounds");
            btn_wipeData.Text = Loc.Translate("Wipe all data");
        }

        void LoadProgress()
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
