using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using CalLicenseDemo.Common;

namespace CalLicenseDemo.Views
{
    /// <summary>
    ///     Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Page
    {
        /// <summary>
        /// Data initialization
        /// </summary>
        public RegisterUser()
        {
            InitializeComponent();
            var viewmodel = new RegisterUserViewModel(NavigationService);
            viewmodel.NavigateNextPage += NavigateNextPage;
            DataContext = viewmodel;
        }

        /// <summary>
        /// Page navigation
        /// </summary>
        /// <param name="screenName">screenName</param>
        /// <param name="additionalInfo">additionalInfo</param>
        private void NavigateNextPage(string screenName, Dictionary<string, string> additionalInfo)
        {
            string licenseType = String.Empty;
            additionalInfo.TryGetValue("licenseType", out licenseType);
            if (licenseType == "Paid")
                this.NavigationService.Navigate(new SubscriptonScreen());
            else
            {
                MessageBox.Show("Trial License is Activated from Now");
                this.NavigationService.Navigate(new LoginUser());
            }
        }

        /// <summary>
        /// page navigation action
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreditAndDebitCardDetails());
        }
    }
}