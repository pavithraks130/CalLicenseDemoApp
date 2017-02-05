using CalLicenseDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
