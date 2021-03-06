﻿using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using PatientСardWpfApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp.ViewModels
{
    class ShellViewModel : BindableBase
    {
        private PersonalCard card;
        private PersonalCard _selectedPatient;
        private string _stateInfo;

        #region property DisplayName
        /// <summary>
        /// Represent DisplayName property
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value); }
        }

        /// <summary>
        /// Backing field for property DisplayName
        /// </summary>
        private string _displayName = "Hospitalis Scrinium";

        #endregion        

        #region Public Properties
        public PersonalCard Card
        {
            get { return card; }
            set { SetProperty(ref card, value); }
        }

        public PersonalCard SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                SetProperty(ref _selectedPatient, value);
                BtVisibility = (_selectedPatient != null) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public string StateInfo
        {
            get { return _stateInfo; }
            set { SetProperty(ref _stateInfo, value); }
        }

        private Visibility _btVisible = Visibility.Hidden;
        public Visibility BtVisibility
        {
            get { return _btVisible; }
            set { SetProperty(ref _btVisible, value); }
        }

        public static BindingList<string> SexTypes { get; private set; } = new BindingList<string>() { "Муж.", "Жен." };
        public static BindingList<PersonalCard> Patients { get; set; }

        public ICommand NewPatientProfile { get; private set; }
        public ICommand ProfileRemove { get; private set; }
        public ICommand OpenProfile { get; private set; }
        public ICommand VisitsHistoryShow { get; private set; }

        #endregion

        IDBLoader DBLoader;
        IPatientRemover Remover;
        IValidator Validator;
        IProfileAdder ProfileAdder;
        IVisitRemover VRemover;

        public ShellViewModel(IDBLoader loader, IPatientRemover remover, IValidator validator, IProfileAdder profileAdder, IVisitRemover vRemover)
        {
            DBLoader = loader;
            Remover = remover;
            Validator = validator;
            ProfileAdder = profileAdder;
            VRemover = vRemover;

            VisitsHistoryShow = new DelegateCommand(ShowVisitsHistoryView);
            NewPatientProfile = new DelegateCommand(NewProfile);
            ProfileRemove = new DelegateCommand(RemoveProfile);
            OpenProfile = new DelegateCommand(EditProfile);

            Patients = new BindingList<PersonalCard>();
            Patients = (BindingList<PersonalCard>)DBLoader.UpdateFromDB();
        }

        private void NewProfile()
        {
            var vm = new ProfileViewModel(Validator, ProfileAdder, null);
            var ProfileWin = new ProfileView
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => ProfileWin.Close();
            ProfileWin.ShowDialog();
        }

        private void EditProfile()
        {
            if (_selectedPatient != null)
            {
                var vm = new ProfileViewModel(Validator, ProfileAdder, SelectedPatient, true);
                var ProfileWin = new ProfileView
                {
                    DataContext = vm
                };
                vm.OnRequestClose += (s, e) => ProfileWin.Close();
                ProfileWin.ShowDialog();
            }
        }

        private void RemoveProfile()
        {
            if (MessageBox.Show("Удалить запись выбранного пациента?",
                                "Подтвердите действие",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
                Remover.DeleteProfile(SelectedPatient);
        }

        private void ShowVisitsHistoryView()
        {
            var VisitsWindow = new VisitsHistoryView();
            VisitsWindow.DataContext = new VisitsHistoryVM(SelectedPatient, VRemover);
            VisitsWindow.ShowDialog();
        }

    }
}
