using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    class ChangePassword : BaseEntity
    {
        private string _oldPasswod;
        private string _newPasswrd;


        public string OldPassword { get { return _oldPasswod; } set { _oldPasswod = value; OnPropertyChanged("OldPassword"); } }

        public string NewPassword { get { return _newPasswrd; } set { _newPasswrd = value; OnPropertyChanged("NewPassword"); } }

        public ICommand ChangePasswordCommand { get; set; }

        public ChangePassword()
        {
            ChangePasswordCommand = new RelayCommand(ChangeOldPassword);
        }

        public void ChangeOldPassword(object param)
        {
            
        }

    }
}
