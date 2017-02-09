using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    /// <summary>
    /// Payment gateway operation
    /// </summary>
    public class RedirectToAmountPaymentPageViewModel : BaseEntity
    {
        /// <summary>
        /// BackToLogin action
        /// </summary>
        public ICommand BackToLoginCommand
        { get; set; }

        /// <summary>
        ///RedirectToAmountPaymentPageViewModel initialisation
        /// </summary>
        public RedirectToAmountPaymentPageViewModel()
        {
            BackToLoginCommand = new RelayCommand(BackToLoginPageCommandExecuted);
        }

        /// <summary>
        /// redirect to loginPage 
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void BackToLoginPageCommandExecuted(object parameter)
        {
            NavigateNextPage?.Invoke(null, null);
        }
    }
}
