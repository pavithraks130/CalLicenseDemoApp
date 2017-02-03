using System.Windows.Controls;
using CalLicenseDemo.ViewModel;

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
            viewmodel.NavigateNextPage += () => { this.NavigationService.Navigate(new PaymentOption()); };
            DataContext = viewmodel;
        }
    }
}