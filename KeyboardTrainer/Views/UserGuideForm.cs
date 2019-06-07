using KeyboardTrainer.ViewModels;
using System.Windows.Forms;

namespace KeyboardTrainer.Views
{
    public partial class UserGuideForm : Form
    {
        public UserGuideForm()
        {
            InitializeComponent();

            Loc.AddTranslate("User guide", "Пользовательское руководство");
            Loc.AddTranslate("Do you want to know the features of the program?", "Хотите узнать основные возможности программы?");
            Loc.AddTranslate("Welcome", "Добро пожаловать");
            Loc.AddTranslate("Next >>", "Далее >>");
            Loc.AddTranslate("Exit", "Выход");
            Loc.AddTranslate(tab2Text.Text, "Уроки - здесь вы можете учиться по урокам.\nМои результаты - здесь вы можете тренироваться набирать слова.\nРуководство - здесь вы можете прочитать некоторую информацию.");

            this.Text = Loc.Translate("User guide");

            if (SilenceMessageBox.Show(Loc.Translate("Do you want to know the features of the program?"), "", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.No)
            {
                this.Close();
            }
            Loc.AddTranslate(tab1Text.Text, "С помощью этой программы Вы можете научиться печатать 10 пальцами. В программе есть несколько уроков. Если Вы будете практиковаться каждый день, Вы научитесь быстро набирать 10 пальцами. Подробнее о 10-ти пальцевом методе печати Вы можете прочитать в руководстве.");

            tab1Text.Text = Loc.Translate(tab1Text.Text);
            tab1_Title.Text = Loc.Translate("Welcome");
            tab1_Nextbtn.Text = Loc.Translate("Next >>");

            tab2_Exitbtn.Text = Loc.Translate("Exit");
            tab2Text.Text = Loc.Translate(tab2Text.Text);

            tab1_Nextbtn.Click += (s, e) => tabControl.SelectedIndex = 1;
            tab2_Exitbtn.Click += (s, e) => this.Close();
        }
    }
}