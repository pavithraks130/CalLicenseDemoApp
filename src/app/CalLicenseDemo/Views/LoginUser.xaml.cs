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
        /// <summary>
        /// Constructor data initialization
        /// </summary>
        public LoginUser()
        {
            InitializeComponent();
            var viewModel = new LoginUserViewModel();
            viewModel.NavigateNextPage  += NavigateNextPage; 
            DataContext = viewModel;
        }

        /// <summary>
        /// Page navigation
        /// </summary>
        /// <param name="screenName">screenName</param>
        /// <param name="additionalInfo">additionalInfo</param>
        private void NavigateNextPage(string screenName, Dictionary<string, string> additionalInfo)
        {
          
                this.NavigationService.Navigate(new Dashboard());
          
        }

        /// <summary>
        /// Button new user page navigation 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ButtonNewUser_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterUser());
        }
    }
}
