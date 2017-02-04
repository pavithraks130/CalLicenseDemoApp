using System;
using System.Windows;
using System.Windows.Input;
using CalLicenseDemo.Common;
using CalLicenseDemo.Logic;
using CalLicenseDemo.Views;
using System.Text.RegularExpressions;

namespace CalLicenseDemo.ViewModel
{
    internal class LoginUserViewModel : BaseEntity
    {
        private string _email;

        private string _password;

        private bool _isEnableLogin = true;
        public LoginUserViewModel()
        {
            LoginCommand = new RelayCommand(LoginUser);
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand SignUpNewUser { get; set; }

        public bool IsEnableLogin
        {
            get
            {
                return _isEnableLogin;
            }

            set
            {
                _isEnableLogin = value;
                OnPropertyChanged("IsEnableLogin");
            }
        }

        public void LoginUser(object param)
        {
            if (Email == null || Email == "" || !IsVlaiEmail())
            {
                MessageBox.Show("Please enter valid email address", "Warning");
                return;
            }
            if (Password == null || Password == "")
            {
                MessageBox.Show("Please enter valid password", "Warning");
                return;
            }
            var logic = new LoginLogic();
            IsEnableLogin = false;
            var status = logic.ValidateUser(Email, Password);

            if (status)
            {
                if (NavigateNextPage != null)
                    NavigateNextPage(null,null);
                //logic.GetFeatureList();
                //if (SingletonLicense.Instance.FeatureList.Count == 0)
                //    MessageBox.Show("Please Subscribe for License , all the current licenses are expired!");
            }
            else
            {
                MessageBox.Show(logic.ErrorMessage);
                logic.ErrorMessage = String.Empty;
            }
            IsEnableLogin = true;
        }

        private bool IsVlaiEmail()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}