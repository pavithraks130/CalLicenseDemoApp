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
        public Dashboard()
        {
            InitializeComponent();
            var viewModel = new DashboardViewModel();
            viewModel.NavigateNextPage += OnPageNavigated;
            DataContext = viewModel;
        }

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

        private void BtnSubscription_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SubscriptonScreen());
        }
    }
}
