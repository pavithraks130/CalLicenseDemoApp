using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalLicenseDemo.ViewModel
{
    class TabControlBaseViewModel:BaseEntity
    {
        ObservableCollection<object> _tabViewModels;
        public TabControlBaseViewModel()
        {

            _tabViewModels = new ObservableCollection<object>();
            _tabViewModels.Add(new LoginViewModel());
            _tabViewModels.Add(new ChangePasswordViewModel());
            _tabViewModels.Add(new RegistrationViewModel());

        }

        public ObservableCollection<object> TabViewModels
        {
            get
            {
                return _tabViewModels;
            }
        }
    }
}
