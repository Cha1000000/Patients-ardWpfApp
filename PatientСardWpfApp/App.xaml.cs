﻿using System.Windows;

namespace PatientСardWpfApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        [System.Obsolete]
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstapper = new Bootstrapper();
            bootstapper.Run();
        }


    }
}
