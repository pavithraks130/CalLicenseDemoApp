using CalLicenseDemo.ViewModel;
using CalLicenseDemo.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace CalLicenseDemo
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow mainWindow;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegisterAndPay_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new PaymentContainerWindow();
            newWindow.Height = 700;
            newWindow.Width = 600;
            newWindow.Show();
        }
    }
}
