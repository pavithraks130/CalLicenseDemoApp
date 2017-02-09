using CalLicenseDemo.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CalLicenseDemo.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        /// <summary>
        /// Constructor data initialization
        /// </summary>
        public Dashboard()
        {
            InitializeComponent();
            var viewModel = new DashboardViewModel();
            viewModel.NavigateNextPage += OnPageNavigated;
            DataContext = viewModel;
        }

        /// <summary>
        /// Page navigation action
        /// </summary>
        /// <param name="screenToNavigate">screento navigate info</param>
        /// <param name="additionalInfo">additional info</param>
        private void OnPageNavigated(string screenToNavigate, Dictionary<string,string> additionalInfo)
        {
          switch(screenToNavigate)
            {
                case "Login":
                this.NavigationService.Navigate(new LoginUser());
                    break;
                case "AccountDetails":
                    this.NavigationService.Navigate(new UserAccountSettings());
                    break;
                case "Profile":
                    this.NavigationService.Navigate(new UserAccountDetails());
                    break;
            }
        }

        /// <summary>
        /// subscription page navigation info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubscription_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SubscriptonScreen());
        }
    }
}
