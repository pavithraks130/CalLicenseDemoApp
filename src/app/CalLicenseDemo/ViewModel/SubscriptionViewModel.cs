using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using CalLicenseDemo.Common;
using CalLicenseDemo.Logic;
using CalLicense.Core.Model;

namespace CalLicenseDemo.ViewModel
{
    class SubscriptionViewModel : BaseEntity
    {
        public ICommand BuyCommand { get; set; }
        public List<LicenseType> SubscriptionList { get; set; }

        public NavigationService Service { get; set; }

        public SubscriptionViewModel()
        {
            BuyCommand = new RelayCommand(RedirectToPayment);
            LoadSubscriptionList();
        }

        private void LoadSubscriptionList()
        {
            LicenseLogic logic = new LicenseLogic();
            SubscriptionList = logic.GetSubscriptionDetails();
        }

        private void RedirectToPayment(object param)
        {
            int id = Convert.ToInt32(param);
            LicenseType typeObj = SubscriptionList.FirstOrDefault(l => l.TypeId == id);
            //LicenseLogic logic = new LicenseLogic();
            SingletonLicense.Instance.SelectedSubscription = typeObj;
            //logic.ActivateSubscription();
            if (NavigateNextPage != null)
                NavigateNextPage(null, null);
        }
    }
}
