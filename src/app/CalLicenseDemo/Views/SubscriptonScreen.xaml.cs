using System.Windows.Controls;
using CalLicenseDemo.ViewModel;
using System.Collections.Generic;

namespace CalLicenseDemo.Views
{
    /// <summary>
    ///     Interaction logic for SubscriptonScreen.xaml
    /// </summary>
    public partial class SubscriptonScreen : Page
    {
        public SubscriptonScreen()
        {
            InitializeComponent();
            //Navigation Service is an inbuilt prperty of page
            var viewmodel = new SubscriptionViewModel();
            viewmodel.NavigateNextPage += (string screenName, Dictionary<string,string> additionalInfo) => { this.NavigationService.Navigate(new CreditAndDebitCardDetails()); };
            DataContext = viewmodel;
        }
    }
}