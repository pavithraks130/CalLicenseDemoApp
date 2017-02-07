using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    /// <summary>
    /// This class is used to modify existing user password
    /// </summary>
    internal class ChangePassword : BaseEntity
    {
        private string _newPasswrd;
        private string _oldPasswod;

        /// <summary>
        /// constructor to initialise data
        /// </summary>
        public ChangePassword()
        {
            ChangePasswordCommand = new RelayCommand(ChangeOldPassword);
        }

        /// <summary>
        /// Old password property
        /// </summary>
        public string OldPassword
        {
            get { return _oldPasswod; }
            set
            {
                _oldPasswod = value;
                OnPropertyChanged("OldPassword");
            }
        }

        /// <summary>
        /// New password property
        /// </summary>
        public string NewPassword
        {
            get { return _newPasswrd; }
            set
            {
                _newPasswrd = value;
                OnPropertyChanged("NewPassword");
            }
        }

        /// <summary>
        /// Change password command
        /// </summary>
        public ICommand ChangePasswordCommand { get; set; }

        /// <summary>
        ///This method is used to change old to new password for existing user.
        /// </summary>
        /// <param name="param">param</param>
        public void ChangeOldPassword(object param)
        {
        }
    }
}