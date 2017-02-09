using CalLicenseDemo.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CalLicenseDemo.Views
{
    /// <summary>
    /// Interaction logic for UserAccountSettings.xaml
    /// </summary>
    public partial class UserAccountSettings : Page
    {
        /// <summary>
        /// UserAccountSettings data initialization
        /// </summary>
        public UserAccountSettings()
        {
            InitializeComponent();
            var viewModel = new UserAccountSettingsViewModel();
            DataContext = viewModel;
            viewModel.NavigateNextPage = OnNextPageNavigated;
        }

        /// <summary>
        /// Page nivaigation
        /// </summary>
        /// <param name="screenName">screenName</param>
        /// <param name="additionalInfo">additionalInfo</param>
        private void OnNextPageNavigated(string screenName, Dictionary<string,string> additionalInfo)
        {
            this.NavigationService.Navigate(new Dashboard());
        }
    }
}
