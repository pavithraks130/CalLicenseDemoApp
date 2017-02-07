using CalLicenseDemo.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CalLicenseDemo.Common;
using CalLicenseDemo.Logic;

namespace CalLicenseDemo.ViewModel
{
    /// <summary>
    /// DashboardViewModel
    /// </summary>
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

        public  string TrialaNotificationMessage { get; set; }

        public  Visibility PanelVisiblity { get; set; }

        public ICommand AccoutSettingsCommand { get; set; }
        public ICommand ProfileDetailsCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public DashboardViewModel()
        {
            AccoutSettingsCommand = new RelayCommand(OnAccoutSettingsExecuted);
            ProfileDetailsCommand = new RelayCommand(OnProfileDetailsExecuted);
            LogoutCommand = new RelayCommand(OnLogoutExecuted);
            LoginLogic logic = new LoginLogic();
            logic.GetFeatureList();
            if (SingletonLicense.Instance.FeatureList.Count == 0)
            {
                PanelVisiblity = Visibility.Visible;
                TrialaNotificationMessage = "License are Expired. Please click subscription for new Subscription";
            }
            else
            {
                PanelVisiblity = Visibility.Collapsed;
                TrialaNotificationMessage = string.Empty;
            }
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
