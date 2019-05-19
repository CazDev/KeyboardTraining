using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KeyboardTrainer.Views.Learning_
{
    /// <summary>
    /// Логика взаимодействия для Learning.xaml
    /// </summary>
    public partial class Learning : Window
    {
        public MLanguage language { get; set; }

        public Learning(MLanguage language)
        {
            InitializeComponent();
            this.language = language;
        }

        private void Btn_fastLearn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}