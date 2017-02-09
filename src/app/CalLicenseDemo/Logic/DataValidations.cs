using System.Text.RegularExpressions;

namespace CalLicenseDemo.Logic
{
    /// <summary>
    /// User input data validation model class
    /// </summary>
    internal static class DataValidations
    {
        //public static bool IsValidCardDetails(TextBox cardNumber, ComboBox slectedMonth, TextBox txtCVV,
        //    ComboBox selectedYear)
        //{
        //    if (cardNumber.Text.Length == Constants.CARD_NUMBER_LENGTH && slectedMonth.SelectedItem is int &&
        //        txtCVV.Text.Length == Constants.CARD_CVV_LENGTH && txtCVV.Text != string.Empty
        //        && selectedYear.SelectedItem != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Method is used to verifies email id details
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>true:Email id pattern matched
        /// false:Email id pattern not matched</returns>
        public static  bool IsValidEmailId(string emailID)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailID);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}