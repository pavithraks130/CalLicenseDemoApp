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
        
        /// <summary>
        /// Constructor initialaization
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.NavigationService.Navigated += NavigationService_Navigated;
        }
        /// <summary>
        /// Page navigation action.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>

        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
           this.RemoveBackEntry();
        }
    }
}