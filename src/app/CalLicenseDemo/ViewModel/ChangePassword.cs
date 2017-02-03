using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    internal class ChangePassword : BaseEntity
    {
        private string _newPasswrd;
        private string _oldPasswod;

        public ChangePassword()
        {
            ChangePasswordCommand = new RelayCommand(ChangeOldPassword);
        }


        public string OldPassword
        {
            get { return _oldPasswod; }
            set
            {
                _oldPasswod = value;
                OnPropertyChanged("OldPassword");
            }
        }

        public string NewPassword
        {
            get { return _newPasswrd; }
            set
            {
                _newPasswrd = value;
                OnPropertyChanged("NewPassword");
            }
        }

        public ICommand ChangePasswordCommand { get; set; }

        public void ChangeOldPassword(object param)
        {
        }
    }
}