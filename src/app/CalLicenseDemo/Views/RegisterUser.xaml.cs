using System;
using System.Windows.Controls;
using System.Collections.Generic;
using CalLicenseDemo.Common;

namespace CalLicenseDemo.Views
{
    /// <summary>
    ///     Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Page
    {
        public RegisterUser()
        {
            InitializeComponent();
            var viewmodel = new RegisterUserViewModel(NavigationService);
            viewmodel.NavigateNextPage += NavigateNextPage;
            DataContext = viewmodel;
        }

        private void NavigateNextPage(string screenName, Dictionary<string, string> additionalInfo)
        {
            string licenseType = String.Empty;
            additionalInfo.TryGetValue("licenseType", out licenseType);
            if (licenseType == "Paid")
                this.NavigationService.Navigate(new SubscriptonScreen());
            else
                this.NavigationService.Navigate(new LoginUser());
        }

        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreditAndDebitCardDetails());
        }
    }
}