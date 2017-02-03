using System.Windows.Controls;
using CalLicenseDemo.ViewModel;

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
            DataContext = new RegistrationViewModel();
        }
    }
}