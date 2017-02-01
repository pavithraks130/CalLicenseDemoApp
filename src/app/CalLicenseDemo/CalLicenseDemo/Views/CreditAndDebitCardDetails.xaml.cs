using CalLicenseDemo.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalLicenseDemo
{
    /// <summary>
    /// Interaction logic for CreditAndDebitCardDetails.xaml
    /// </summary>
    public partial class CreditAndDebitCardDetails : UserControl
    {
        public CreditAndDebitCardDetails()
        {
            InitializeComponent();
            for(int year=2017;year<2050;year++)
            listOfYears.Items.Add(year);
            ListofMonths.Items.Add("Select Month");
            for (int month = 1; month <= 12; month++)
            {
                ListofMonths.Items.Add(+month);
            }     

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
