using System.Windows;
using System.Windows.Navigation;

namespace CalLicenseDemo
{

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow mainWindow;
        
        public MainWindow()
        {
            InitializeComponent();
            this.NavigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
           this.RemoveBackEntry();
        }
    }
}