﻿using PatientСardWpfApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp.Views
{
    public partial class MainWindow : Window
    {                
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();            
        }


    }
}
