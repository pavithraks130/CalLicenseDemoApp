using System.Windows;
using System.Windows.Input;
using CalLicenseDemo.Common;
using CalLicenseDemo.Logic;
using CalLicenseDemo.Views;

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
            if (Email == null || Email == "") 
            {
                MessageBox.Show("Please enter valid email address","Warning");
                return;
            }
            if (Password == null || Password == "")
            {
                MessageBox.Show("Please enter valid password","Warning");
                return;
            }
                var logic = new LoginLogic();
            IsEnableLogin = false;
            var status = logic.ValidateUser(Email, Password);
            if (status)
            {
                logic.GetFeatureList();
                if (SingletonLicense.Instance.FeatureList.Count == 0)
                    MessageBox.Show("Please Subscribe for License , all the current licenses are expired!");
            }
            IsEnableLogin = true;
        }
    }
}