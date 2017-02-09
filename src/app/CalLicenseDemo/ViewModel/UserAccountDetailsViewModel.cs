using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    /// <summary>
    /// User Account Details ViewModel class to hold user details.
    /// </summary>
    class UserAccountDetailsViewModel : BaseEntity
    {
        /// <summary>
        /// User account:First name property
        /// </summary>
        public string FirstName
        {
            get
            {
                return Common.SingletonLicense.Instance.User.FName;
            }
        }

        /// <summary>
        /// User account:Last Name property
        /// </summary>
        public string LastName
        {
            get
            {
                return Common.SingletonLicense.Instance.User.LName;
            }
        }
        /// <summary>
        /// User account:Email property
        /// </summary>
        public string Email
        {
            get
            {
                return Common.SingletonLicense.Instance.User.Email;
            }
        }
        /// <summary>
        /// User account:Organisation property
        /// </summary>
        public string Organization
        {
            get
            {
                return Common.SingletonLicense.Instance.User.Organization.Name;
            }
        }
        /// <summary>
        /// Redirect to home screen
        /// </summary>
        public ICommand HomeCommand { get; set; }

        /// <summary>
        /// Constructor initialisation.
        /// </summary>
        public UserAccountDetailsViewModel()
        {
            HomeCommand = new RelayCommand(HomeCommandExecuted);
        }
        /// <summary>
        /// Redirect to home screen
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void HomeCommandExecuted(object parameter)
        {
            NavigateNextPage("Home", null);
        }
    }
}
