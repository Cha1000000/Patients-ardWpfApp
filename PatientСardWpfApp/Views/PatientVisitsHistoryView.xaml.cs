﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PatientСardWpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для PatientVisitsHistoryView.xaml
    /// </summary>
    public partial class PatientVisitsHistoryView : Window
    {
        public PatientVisitsHistoryView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void DataGridRow_LostFocus(object sender, RoutedEventArgs e)
        {
            dgHistory.UnselectAll();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
