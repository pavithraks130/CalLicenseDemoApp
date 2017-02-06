using CalLicenseDemo.Common;
using CalLicenseDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CalLicenseDemo.ViewModel
{
    internal class CreditAndDebitCardDetailsViewModel : BaseEntity
    {
       
        private readonly CardDetails cardDetails;
        private ObservableCollection<short> _cardValidityYear = new ObservableCollection<short>();
        private ObservableCollection<string> _cardValidityMonth = new ObservableCollection<string>();
        private string currentDate;
        private string expDate;
        private string totalCost;

        public string TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }

        }

        public string CardName
        {
            get
            {
                return cardDetails.Name;
            }
            set
            {
                cardDetails.Name = value;
                OnPropertyChanged("CardName");
            }
        }

        public string CardNumber
        {
            get
            {
                return cardDetails.Number;
            }
            set
            {
                cardDetails.Number = value;
                OnPropertyChanged("CardNumber");
            }
        }

        public ObservableCollection<string> CardValidityMonth
        {
            get
            {
                return _cardValidityMonth;
            }
            set
            {
                _cardValidityMonth = value;
                OnPropertyChanged("CardValidityMonth");
            }
        }
        public string SelectedMonth
        {
            get
            {
                return cardDetails.Month;
            }
            set
            {
                cardDetails.Month = value;
                OnPropertyChanged("SelectedMonth");
            }
        }
        
        public ObservableCollection<short> CardValidityYear
        {
            get
            {
                return _cardValidityYear;
            }
            set
            {
                _cardValidityYear = value;
            }

        }

        public short SelectedYear
        {
            get
            {
                return cardDetails.Years;
            }
            set
            {
                cardDetails.Years = value;
                OnPropertyChanged("SelectedYear");
            }
        }

        public RelayCommand PurchaseCommand { get; private set; }
        
        public string CurrentDate
        {
            get
            {
                return currentDate;
            }

            set
            {
                currentDate = value;
            }
        }

        public string ExpDate
        {
            get
            {
                return expDate;
            }

            set
            {
                expDate = value;
            }
        }

        private string tax;

        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }


        public CreditAndDebitCardDetailsViewModel()
        {
            cardDetails = new CardDetails();
            currentDate = "License Issued Date - " +DateTime.Now.ToString("M/d/yyyy");
            DateTime theDate = DateTime.Now;
            DateTime yearInTheFuture = theDate.AddYears(1);
            expDate = "License Expiry Date - " + yearInTheFuture;
            totalCost = "Total cost - " + SingletonLicense.Instance.SelectedSubscription.Price +"~/";
            tax = "Tax - " + SingletonLicense.Instance.SelectedSubscription.Price * .05 + "~/";
            LoadListOfYears();
            LoadListOfMonths();
            PurchaseCommand = new RelayCommand(OnPurchase);

        }

        private void LoadListOfMonths()
        {
            _cardValidityMonth.Add("Select Month");
            for (short month = Constants.START_MONTH; month <= Constants.END_MONTH; month++)
            {
                _cardValidityMonth.Add(month.ToString());
            }
        }

        private void LoadListOfYears()
        {
            _cardValidityYear = new ObservableCollection<short>();
            for (short year = Constants.START_YEAR; year < Constants.END_YEAR; year++)
            {
                _cardValidityYear.Add(year);
            }
        }

        private void OnPurchase(object parm)
        {
            //validate card details
            //redirect to payment page
            var kvp = new Dictionary<string, string>();
            kvp.Add("Amount", "750");
            NavigateNextPage("PurchasePage", kvp);
        }
    }

}
