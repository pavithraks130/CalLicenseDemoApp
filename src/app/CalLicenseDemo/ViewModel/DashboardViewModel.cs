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
    /// This calss is used to perform home screen operations.
    /// </summary>
    public class DashboardViewModel : BaseEntity
    {
        /// <summary>
        /// LoggedInUser property
        /// </summary>
        public string LoggedInUser
        {
            get
            {
               return (Common.SingletonLicense.Instance.User.FName + " " + Common.SingletonLicense.Instance.User.LName);
            }
        }

        /// <summary>
        /// LoggedInUser collection property
        /// </summary>
        public List<Feature> c
        {
            get
            {
                return Common.SingletonLicense.Instance.FeatureList;
            }
        }

        /// <summary>
        /// TrialaNotificationMessage property
        /// </summary>
        public string TrialaNotificationMessage { get; set; }

        /// <summary>
        /// PanelVisiblity property
        /// </summary>
        public Visibility PanelVisiblity { get; set; }

        /// <summary>
        /// AccoutSettingsCommand property
        /// </summary>
        public ICommand AccoutSettingsCommand { get; set; }

        /// <summary>
        /// ProfileDetailsCommand property
        /// </summary>
        public ICommand ProfileDetailsCommand { get; set; }


        /// <summary>
        /// LogoutCommand property
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// data initialisation on constructor
        /// </summary>
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

        /// <summary>
        /// To perform account details info
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void OnAccoutSettingsExecuted(object parameter)
        {
            NavigateNextPage("AccountDetails", null);
        }

        /// <summary>
        ///  To perform OnProfileDetails action 
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void OnProfileDetailsExecuted(object parameter)
        {
            NavigateNextPage("Profile", null);
        }

        /// <summary>
        /// To perform logout action.
        /// </summary>
        /// <param name="parameter"></param>
        private void OnLogoutExecuted(object parameter)
        {
            Common.SingletonLicense.Instance.User = null;
            NavigateNextPage("Login", null);
        }
    }
}
