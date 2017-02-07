using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    class UserAccountDetailsViewModel:BaseEntity
    {

        public string FirstName
        {
            get
            {
                return Common.SingletonLicense.Instance.User.FName;
            }
        }

        public string LastName
        {
            get
            {
                return Common.SingletonLicense.Instance.User.LName;
            }
        }

        public string Email
        {
            get
            {
                return Common.SingletonLicense.Instance.User.Email;
            }
        }

        public string Organization
        {
            get
            {
                return Common.SingletonLicense.Instance.User.Organization.Name;
            }
        }
        public ICommand HomeCommand { get; set; }

        public UserAccountDetailsViewModel()
        {
            HomeCommand = new RelayCommand(HomeCommandExecuted);
        }

        private void HomeCommandExecuted(object parameter)
        {
            NavigateNextPage("Home", null);
        }
    }
}
