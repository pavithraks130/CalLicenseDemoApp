using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using CalLicenseDemo.Logic;
using CalLicenseDemo.Model;
using CalLicenseDemo.ViewModel;

namespace CalLicenseDemo.Common
{
    internal class RegisterUserViewModel : BaseEntity
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


        public RegisterUserViewModel(NavigationService service)
        {
            user = new RegistrationModel();
            Service = service;
            RegisterCommand = new RelayCommand(RegisterNewUser);
        }

        private void RegisterNewUser(object param)
        {
            //if (Email == null || Email == "" || !DataValidations.IsValidEmailId(Email))
            //{
            //    MessageBox.Show("Please enter valid email address", "Warning");
            //    return;
            //}
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