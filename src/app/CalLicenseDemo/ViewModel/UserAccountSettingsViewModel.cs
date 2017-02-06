using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    class UserAccountSettingsViewModel : BaseEntity
    {
       public ICommand HomeCommand { get; set; }

        public UserAccountSettingsViewModel()
        {
            HomeCommand = new RelayCommand(HomeCommandExecuted);
        }

        private void HomeCommandExecuted(object parameter)
        {
            NavigateNextPage("Home", null);
        }
    }
}
