using System;
using System.Windows.Input;
using System.Windows.Navigation;
using CalLicenseDemo.Logic;
using CalLicenseDemo.Model;
using CalLicenseDemo.Views;

namespace CalLicenseDemo.ViewModel
{
    internal class RegistrationViewModel : BaseEntity
    {
        private readonly User user;
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
            get { return user.Organization.Name; }
            set
            {
                user.Organization.Name = value;
                OnPropertyChanged("Organization");
            }
        }


        public ICommand RegisterCommand { get; set; }

        public NavigationService Service { get; set; }


        public RegistrationViewModel(NavigationService service)
        {
            user = new User();
            Service = service;
            RegisterCommand = new RelayCommand(RegisterNewUser);
        }

        private void RegisterNewUser(object param)
        {
            var logic = new LicenseLogic { User = user };
            var status = logic.CreateUserInfo();
            if (NavigateNextPage != null)
                NavigateNextPage();
            //Service.Navigate(new SubscriptonScreen());
        }
    }
}