using KeyboardTrainer.Views.Training_.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            ViewModel.Current_Language = language;
            this.Title = ViewModel.Translate("Manual");
            tab2_image.Source = ImageSourceForBitmap(Properties.Resources.keyboard);
        }

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public ImageSource ImageSourceForBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
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
