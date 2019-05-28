﻿using KeyboardTrainer.Models;
using KeyboardTrainer.ViewModels;
using KeyboardTrainer.Views;
using KeyboardTrainer.Views.MainMenu.Learning_;
using KeyboardTrainer.Views.Manual_;
using KeyboardTrainer.Views.Training_.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    public partial class MainWindow : Window
    {
        ViewModel viewModel;
        public MainWindow()
        {
            viewModel = new ViewModel(MLanguage.ENGLISH);

            this.Icon = Properties.Resources.MainWindowIcon.ToImageSource();

            viewModel.Update();//check updates
            InitializeComponent();
            viewModel.LocalizeButtons(btn_learning, btn_manual, btn_training);
            cb_language.SelectedIndex = 0;            
        }

        private void Btn_myResults_Click(object sender, RoutedEventArgs e)
        {
            MLanguage language = GetSelectedLanguage();
            MyResults results = new MyResults(language);
            this.Hide();
            if (results.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private MLanguage GetSelectedLanguage()
        {
            TextBlock item = (TextBlock)cb_language.SelectedItem;
            MLanguage language = MLanguage.ENGLISH;
            if (item?.Text == "Russian")
            {
                language = MLanguage.RUSSIAN;
            }
            else if (item?.Text == "English")
            {
                language = MLanguage.ENGLISH;
            }

            return language;
        }

        private void Btn_manual_Click(object sender, RoutedEventArgs e)
        {
            Manual manual = new Manual();
            this.Hide();
            if (manual.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void Btn_learning_Click(object sender, RoutedEventArgs e)
        {
            Training learning = new Training(GetSelectedLanguage());
            this.Hide();
            if (learning.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void cb_SelectedLangugeChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.ChangeLanguageTo(GetSelectedLanguage());
            this.Title = viewModel.Translate("MainWindow");
        }
    }
}
