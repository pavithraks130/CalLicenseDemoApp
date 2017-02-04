using CalLicenseDemo.ViewModel;
using System.Windows.Controls;

namespace CalLicenseDemo.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            var viewModel = new DashboardViewModel();
            DataContext = viewModel;
        }
    }
}
