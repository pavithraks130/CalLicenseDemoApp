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
            var viewmodel = new RegistrationViewModel(NavigationService);
            viewmodel.NavigateNextPage += delegate(string screenName,Dictionary<string,string> additionalInfo){ this.NavigationService.Navigate(new SubscriptonScreen()); };
            DataContext = viewmodel;
        }

    }
}