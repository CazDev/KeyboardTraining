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
        public MLanguage language { get; set; }
        public Manual(MLanguage language)
        {
            InitializeComponent();
            this.language = language;
            this.Title = Loc.Translate("Manual");
            tab2_image.Source = ImageSourceForBitmap(Properties.Resources.keyboard);
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
    }
}
