using System.Windows;
using System.Windows.Input;
using CalLicenseDemo.Common;
using CalLicenseDemo.Logic;

namespace CalLicenseDemo.ViewModel
{
    internal class LoginViewModel : BaseEntity
    {
        private string _email;

        public string _password;

        public LoginViewModel()
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

        public void LoginUser(object param)
        {
            var logic = new LoginLogic();
            var status = logic.ValidateUser(Email, Password);
            if (status)
            {
                logic.GetFeatureList();
                if (SingletonLicense.Instance.FeatureList.Count == 0)
                    MessageBox.Show("Please Subscribe for License , all the current licenses are expired!");
            }
        }
    }
}