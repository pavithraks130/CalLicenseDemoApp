using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalLicenseDemo.ViewModel
{
    class RedirectToAmountPaymentPageViewModel : BaseEntity
    {
        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }
    }
}
