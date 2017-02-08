using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using CalLicenseDemo.Logic;
using CalLicense.Core.Model;
using CalLicenseDemo.ViewModel;
using System.ComponentModel;
using System;

namespace CalLicenseDemo.Common
{
    internal class RegisterUserViewModel : BaseEntity, IDataErrorInfo
    {
        private readonly RegistrationModel user;
        public string FName
        {
            get { return user.FName; }
            set
            {
                user.FName = value;
                OnPropertyChanged("FName");
            }
        }

        public string LName
        {
            get { return user.LName; }
            set
            {
                user.LName = value;
                OnPropertyChanged("LName");
            }
        }

        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Organization
        {
            get { return user.OrganizationName; }
            set
            {
                user.OrganizationName = value;
                OnPropertyChanged("Organization");
            }
        }

        public ICommand RegisterCommand { get; set; }

        public NavigationService Service { get; set; }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                if ("Email" == columnName)
                {
                    return EmailValidation();
                }
                if ("Password" == columnName)
                {
                    return PasswordValidation();
                }
                if ("FName" == columnName)
                {
                    return FirstNameValidation();
                }
                if ("LName" == columnName)
                {
                    return LastNameValidation();
                }
                if ("Organization" == columnName)
                {
                    return OrganizationValidation();
                }
                return string.Empty;
            }
        }

        private string LastNameValidation()
        {
            if (string.IsNullOrEmpty(LName))
            {
                return "Last name field is empty";
            }
            return string.Empty;
        }

        private string FirstNameValidation()
        {
            if (string.IsNullOrEmpty(FName))
            {
                return "First name field is empty";
            }
            return string.Empty;
        }

        private string OrganizationValidation()
        {
            if (string.IsNullOrEmpty(Organization))
            {
                return "Organization field is empty";
            }
            return string.Empty;
        }

        private string EmailValidation()
        {
            if (string.IsNullOrEmpty(Email))
            {
                return "Email address field is empty";
            }
            else if (!DataValidations.IsValidEmailId(Email))
            {
                return "Please enter valid email address";
            }
            return string.Empty;

        }

        private string PasswordValidation()
        {
            if (string.IsNullOrEmpty(Password))
            {
                return "Password field is empty";
            }
            return string.Empty;

        }
        public RegisterUserViewModel(NavigationService service)
        {
            user = new RegistrationModel();
            Service = service;
            RegisterCommand = new RelayCommand(RegisterNewUser);
        }
        private void RegisterNewUser(object param)
        {
            if (!string.IsNullOrEmpty(LName) && !string.IsNullOrEmpty(FName) && !string.IsNullOrEmpty(Organization) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                var userLogic = new LoginLogic();
                //Validate Email
                var status = userLogic.ValidateEmail(user.Email);

                if (status)
                {
                    userLogic.CreateUserInfo(user);
                    string licenseType = param.ToString();
                    if (licenseType == "Trial")
                    {
                        var logic = new LicenseLogic();
                        SingletonLicense.Instance.SelectedSubscription = logic.GetTrialLicense();
                        logic.ActivateSubscription();
                    }
                    var dict = new Dictionary<string, string>();
                    dict.Add("licenseType", licenseType);
                    if (NavigateNextPage != null)
                        NavigateNextPage(null, dict);
                }
                else
                {
                    MessageBox.Show("Email Address already Exist");
                }
            }
        }
    }
}