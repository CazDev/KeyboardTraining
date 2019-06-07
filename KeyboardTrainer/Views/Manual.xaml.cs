using KeyboardTrainer.ViewModels;
using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KeyboardTrainer.Views.Manual_
{
    /// <summary>
    /// Logic for Manual.xaml
    /// </summary>
    public partial class Manual : Window
    {
        public Manual()
        {
            InitializeComponent();

            Loc.AddTranslate("Seat", txtbx0.Text);
            Loc.AddTranslate("Sit up straight and keep your back straight.", txtbx1.Text);
            Loc.AddTranslate("Keep your elbows bent at a right angle.", txtbx2.Text);
            Loc.AddTranslate("The distance from the eyes to the screen should be 45-70 cm.", txtbx3.Text);
            Loc.AddTranslate("Additional Information", txtbx4.Text);
            Loc.AddTranslate("Don't try to learn typing right away. Begin to accelerate only when all 10 fingers get used to pressing the correct keys.", txtbx5.Text);
            Loc.AddTranslate("Take your time when typing to avoid mistakes. The speed will increase gradually.", txtbx6.Text);
            Loc.AddTranslate("View text one or two words ahead.", txtbx7.Text);
            Loc.AddTranslate("Practice makes perfect!", txtbx8.Text);
            Loc.AddTranslate("Scheme", txtbx9.Text);

            txtbx0.Text = Loc.Translate(txtbx0.Text);
            txtbx1.Text = Loc.Translate(txtbx1.Text);
            txtbx2.Text = Loc.Translate(txtbx2.Text);
            txtbx3.Text = Loc.Translate(txtbx3.Text);
            txtbx4.Text = Loc.Translate(txtbx4.Text);
            txtbx5.Text = Loc.Translate(txtbx5.Text);
            txtbx6.Text = Loc.Translate(txtbx6.Text);
            txtbx7.Text = Loc.Translate(txtbx7.Text);
            txtbx8.Text = Loc.Translate(txtbx8.Text);
            txtbx9.Text = Loc.Translate(txtbx9.Text);
            btn_tab1.Content = btn_tab2.Content = Loc.Translate("Next >>");
            btn_tab3.Content = Loc.Translate("Exit");

            if (UserProgressSaver.Config.IsFirstProgramLoad)
            {
                UserProgressSaver.Config.IsFirstProgramLoad = false;
                UserGuideForm userGuideForm = new UserGuideForm();
                try
                {
                    userGuideForm.ShowDialog();
                }
                catch { }
            }

            this.Title = Loc.Translate("Manual");


            tab2_image.Source = ImageSourceForBitmap(Properties.Resources.keyboard);
        }



        private void Btn_tab1_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 1));
        }

        private void Btn_tab2_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => tabControl.SelectedIndex = 2));
        }

        private void Btn_tab3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public ImageSource ImageSourceForBitmap(Bitmap bmp)
        {
            IntPtr handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
    }
}
