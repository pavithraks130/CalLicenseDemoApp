using System.Windows.Controls;

namespace CalLicenseDemo.Logic
{
    internal static class DataValidations
    {
        private const int CARD_NUMBER_LENGTH = 16;
        private const int CARD_CVV_LENGTH = 3;

        public static bool IsValidCardDetails(TextBox cardNumber, ComboBox slectedMonth, TextBox txtCVV,
            ComboBox selectedYear)
        {
            if (cardNumber.Text.Length == CARD_NUMBER_LENGTH && slectedMonth.SelectedItem is int &&
                txtCVV.Text.Length == CARD_CVV_LENGTH && txtCVV.Text != string.Empty
                && selectedYear.SelectedItem != null)
                return true;
            return false;
        }
    }
}