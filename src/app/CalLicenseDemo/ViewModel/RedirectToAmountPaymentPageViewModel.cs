using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    public class RedirectToAmountPaymentPageViewModel : BaseEntity
    {
        public ICommand BackToLoginCommand
        { get; set; }


        public RedirectToAmountPaymentPageViewModel()
        {
            BackToLoginCommand = new RelayCommand(BackToLoginPageCommandExecuted);
        }

        private void BackToLoginPageCommandExecuted(object parameter)
        {
            NavigateNextPage?.Invoke(null, null);
        }
    }
}
