using CalLicenseDemo.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CalLicenseDemo.Views
{
    /// <summary>
    /// Interaction logic for LoginUserPage.xaml
    /// </summary>
    public partial class LoginUser : Page
    {
        public LoginUser()
        {
            InitializeComponent();
            var viewModel = new LoginUserViewModel();
            viewModel.NavigateNextPage  += NavigateNextPage; 
            DataContext = viewModel;
        }

        private void NavigateNextPage(string screenName, Dictionary<string, string> additionalInfo)
        {
            if (additionalInfo.Count > 0)
                this.NavigationService.Navigate(new Dashboard());
            else
                this.NavigationService.Navigate(new SubscriptonScreen());
        }

        private void ButtonNewUser_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterUser());
        }
    }
}
