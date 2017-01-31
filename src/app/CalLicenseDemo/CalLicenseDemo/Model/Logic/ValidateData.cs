using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CalLicenseDemo.Logic
{
   static class ValidateData
    {
        public static bool IsValidCardDetails(TextBox cardNumber, ComboBox slectedMonth, TextBox txtCVV, ComboBox selectedYear)
        {

            if (cardNumber.Text.Length == 16 && slectedMonth.SelectedItem is int && txtCVV.Text.Length == 3 && txtCVV.Text != string.Empty
                && selectedYear.SelectedItem != null)
                return true;
            else
                return false;
        }
    }
}
