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
            DataContext = new SubscriptionViewModel(this.NavigationService);
        }
    }
}