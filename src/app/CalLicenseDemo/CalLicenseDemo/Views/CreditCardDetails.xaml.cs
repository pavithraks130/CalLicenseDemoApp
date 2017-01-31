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
    /// Interaction logic for CreditCardDetails.xaml
    /// </summary>
    public partial class CreditCardDetails : UserControl
    {
        public CreditCardDetails()
        {
            InitializeComponent();
            for(int i=2017;i<2050;i++)
            listOfYears.Items.Add(i);
            ListofMonths.Items.Add("Select Month");
            for (int i = 1; i <= 12; i++)
            {
                ListofMonths.Items.Add(+i);
            }     

        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri("Fluke.png", UriKind.Relative);
            b.EndInit();

            // ... Get Image reference from sender.
            var image = sender as Image;
            // ... Assign Source.
            image.Source = b;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidCard())
                PPRedirectToAmountPage.IsOpen = true;
            else
                MessageBox.Show("Please enter valid detailes");
        }

        private bool IsValidCard()
        {
            if (textBox.Text.Length == 16 && ListofMonths.SelectedItem is int && txtCVV.Text.Length ==3 && txtCVV.Text !=string.Empty 
                && listOfYears.SelectedItem != null)
                return true;
            else
                return false;

        }
        /*   //private void textBox1_MouseEnter(object sender, MouseEventArgs e)
//{
//    if (textBox1.Text == "Month")
//        textBox1.Text = "";
//}

//private void textBox1_MouseLeave(object sender, MouseEventArgs e)
//{
//    if (textBox1.Text == string.Empty)
//        textBox1.Text = "Month";
//}
*/
    }
}
