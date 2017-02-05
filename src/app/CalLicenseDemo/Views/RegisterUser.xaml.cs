using System;
using System.Windows.Controls;
using CalLicenseDemo.ViewModel;
using System.Collections.Generic;

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
            var viewmodel = new RegistrationViewModel(NavigationService);
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
            {
                
            }
        }
    }
}