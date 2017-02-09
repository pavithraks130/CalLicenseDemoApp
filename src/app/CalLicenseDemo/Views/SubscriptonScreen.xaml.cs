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
        /// <summary>
        /// </summary>
        public SubscriptonScreen()
        {
            InitializeComponent();
            //Navigation Service is an inbuilt prperty of page
            var viewmodel = new SubscriptionViewModel();
            viewmodel.NavigateNextPage += (string screenName, Dictionary<string,string> additionalInfo) => { this.NavigationService.Navigate(new CreditAndDebitCardDetails()); };
            DataContext = viewmodel;
        }

        /// <summary>
        /// page navigation action
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void buttonPayment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // paymentOption.IsOpen = true;
        }
    }
}