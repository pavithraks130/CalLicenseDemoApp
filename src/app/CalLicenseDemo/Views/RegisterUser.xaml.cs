using System.Windows.Controls;
using CalLicenseDemo.ViewModel;

namespace CalLicenseDemo.Views
{
    /// <summary>
    ///     Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : UserControl
    {
        public RegisterUser()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }
    }
}