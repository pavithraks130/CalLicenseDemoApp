using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    class UserAccountSettingsViewModel : BaseEntity
    {
        public string ActivationDate
        {
            get
            {
                return Common.SingletonLicense.Instance.LicenseData.LicenseList[0].ActivationDate.ToShortDateString();
            }
        }

        public string ExpiryDate
        {
            get
            {
                return Common.SingletonLicense.Instance.LicenseData.LicenseList[0].ExpireDate.ToShortDateString();
            }
        }

        public string DaysLeft
        {
            get
            {
                return (Common.SingletonLicense.Instance.LicenseData.LicenseList[0].ExpireDate.Date - DateTime.Today).TotalDays.ToString();
            }
        }

        public string LoggedInUser
        {
            get
            {
                return "This Product is licensed to" + (Common.SingletonLicense.Instance.User.FName + " " + Common.SingletonLicense.Instance.User.LName);
            }
        }

        public ICommand HomeCommand { get; set; }

        public UserAccountSettingsViewModel()
        {
            HomeCommand = new RelayCommand(HomeCommandExecuted);
        }

        private void HomeCommandExecuted(object parameter)
        {
            NavigateNextPage("Home", null);
        }
    }
}
