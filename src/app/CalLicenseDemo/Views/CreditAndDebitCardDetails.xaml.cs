using System.Windows;
using System.Windows.Controls;
using CalLicenseDemo.Logic;

namespace CalLicenseDemo
{
    /// <summary>
    ///     Interaction logic for CreditAndDebitCardDetails.xaml
    /// </summary>
    public partial class CreditAndDebitCardDetails : UserControl
    {
        public CreditAndDebitCardDetails()
        {
            InitializeComponent();
            for (var year = 2017; year < 2050; year++)
                listOfYears.Items.Add(year);
            ListofMonths.Items.Add("Select Month");
            for (var month = 1; month <= 12; month++)
                ListofMonths.Items.Add(+month);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (DataValidations.IsValidCardDetails(textBox, ListofMonths, txtCVV, listOfYears))
                PPRedirectToAmountPage.IsOpen = true;
            else
                MessageBox.Show("Please enter valid detailes");
        }
    }
}