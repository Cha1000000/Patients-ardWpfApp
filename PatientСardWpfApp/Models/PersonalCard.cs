﻿
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PatientСardWpfApp.Models
{
    public class PersonalCard : BindableBase
    {
        int _id;
        string _name;
        string _surname;
        string _patronymic;
        string _sex;
        DateTime _birthday;
        string _adress;
        string _phone;

        #region Properties
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        [Display(Name = "Имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 3 символов")]
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        [Display(Name = "Отчество")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина отчества не менее 5 символов")]
        public string Patronymic
        {
            get { return _patronymic; }
            set { SetProperty(ref _patronymic, value); }
        }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не верный формат. Пример: \"Муж.\", \"Жен.\".")]
        [StringLength(4)]
        public string Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.DateTime)]
        /*[StringLength(10)]
        public string Birthday
        {
            get { return _birthday.ToString("dd.MM.yyyy"); }
            set { SetProperty(ref _birthday, DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture)); }
        }*/
        public DateTime Birthday
        {
            get { return _birthday; }
            set { SetProperty(ref _birthday, value); }
        }

        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина адреса не менее 15 символов")]
        public string Adress
        {
            get { return _adress; }
            set { SetProperty(ref _adress, value); }
        }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [Required(ErrorMessage = "Длин номера не менее 10 символов")]
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        #endregion

        public PersonalCard() {  }
        public PersonalCard(int id, string surname, string name, string patronymic, string sex, DateTime birthday, string phone, string adress)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Sex = sex;
            Birthday = birthday;
            Adress = adress;
            Phone = phone;
        }
    }
}
