using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CalLicenseDemo.Common;
using CalLicenseDemo.Logic;
using CalLicenseDemo.Views;

namespace CalLicenseDemo.ViewModel
{
    class LoginUserViewModel : BaseEntity
    {
        private string _userName;
        private Visibility _userControlVisibility;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }
        }

        public string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand SignUpNewUser { get; set; }

        public Visibility UserControlVisibility
        {
            get
            {
                return _userControlVisibility;
            }

            set
            {
                _userControlVisibility = value;
            }
        }

        public LoginUserViewModel()
        {
            LoginCommand = new RelayCommand(LoginUser);
            SignUpNewUser = new RelayCommand(SignUpNewUsers);
        }

        private void SignUpNewUsers(object newUserDetails)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.DataContext = new LoginUser();
            mainwindow.ShowDialog();


        }

        public void LoginUser(object param)
        {
            LoginLogic logic = new LoginLogic();
            bool status = logic.ValidateUser(UserName, Password);
            if (status)
            {
                logic.GetFeatureList();
                if (SingletonLicense.Instance.FeatureList.Count == 0)
                    MessageBox.Show("Please Subscribe for License , all the current licenses are expired!");
            }
            else
            {

            }
        }
        }
    }
