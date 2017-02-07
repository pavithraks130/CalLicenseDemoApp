using CalLicenseDemo.Model;
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

        public List<Feature> CurrentFeatureList
        {
            get
            {
                return Common.SingletonLicense.Instance.FeatureList;
            }
        }

        public ICommand AccoutSettingsCommand { get; set; }
        public ICommand ProfileDetailsCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public DashboardViewModel()
        {
            AccoutSettingsCommand = new RelayCommand(OnAccoutSettingsExecuted);
            ProfileDetailsCommand = new RelayCommand(OnProfileDetailsExecuted);
            LogoutCommand = new RelayCommand(OnLogoutExecuted);
        }

        private void OnAccoutSettingsExecuted(object parameter)
        {
            NavigateNextPage("AccountDetails", null);
        }

        private void OnProfileDetailsExecuted(object parameter)
        {
            NavigateNextPage("Profile", null);
        }

        private void OnLogoutExecuted(object parameter)
        {
            Common.SingletonLicense.Instance.User = null;
            NavigateNextPage("Login", null);
        }
    }
}
