using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    public class DashboardViewModel : BaseEntity
    {
        public string LoggedInUser
        {
            get
            {
               return (Common.SingletonLicense.Instance.User.FName + " " + Common.SingletonLicense.Instance.User.LName);
            }
        }

        public ICommand AccoutSettingsCommand { get; set; }
        public ICommand ProfileDetailsCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public DashboardViewModel()
        {

        }

        private void OnAccoutSettingsExecuted(object parameter)
        {

        }

        private void OnProfileDetailsExecuted(object parameter)
        {

        }

        private void OnLogoutExecuted(object parameter)
        {

        }
    }
}
