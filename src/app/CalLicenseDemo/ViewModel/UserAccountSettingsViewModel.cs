using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    /// <summary>
    /// UserAccount Settings ViewModel class.
    /// </summary>
    class UserAccountSettingsViewModel : BaseEntity
    {

        /// <summary>
        ///Licence activation date property
        /// </summary>
        public string ActivationDate
        {
            get
            {
                return Common.SingletonLicense.Instance.LicenseData.LicenseList[0].ActivationDate.ToShortDateString();
            }
        }

        /// <summary>
        /// License expiry date property
        /// </summary>
        public string ExpiryDate
        {
            get
            {
                return Common.SingletonLicense.Instance.LicenseData.LicenseList[0].ExpireDate.ToShortDateString();
            }
        }

        /// <summary>
        /// License expiry total number of days left.
        /// </summary>
        public string DaysLeft
        {
            get
            {
                return (Common.SingletonLicense.Instance.LicenseData.LicenseList[0].ExpireDate.Date - DateTime.Today).TotalDays.ToString();
            }
        }
        /// <summary>
        /// Loggedin user details property
        /// </summary>
        public string LoggedInUser
        {
            get
            {
                return "This Product is licensed to " + (Common.SingletonLicense.Instance.User.FName + " " + Common.SingletonLicense.Instance.User.LName);
            }
        }

        /// <summary>
        /// Home screen redirect command
        /// </summary>
        public ICommand HomeCommand { get; set; }

        public UserAccountSettingsViewModel()
        {
            HomeCommand = new RelayCommand(HomeCommandExecuted);
        }

        /// <summary>
        /// Redirect to Home screen action
        /// </summary>
        /// <param name="parameter">page information</param>
        private void HomeCommandExecuted(object parameter)
        {
            NavigateNextPage("Home", null);
        }
    }
}
