using System.Windows;
using System.Windows.Controls;

namespace CalLicenseDemo.Common
{
    /// <summary>
    /// Creating attached property for password box
    /// </summary>
    public class PasswordHelper
    {
        #region private fields
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password",
                                                                     typeof(string), typeof(PasswordHelper),
                                                                     new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach",
                                                                   typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty = DependencyProperty.RegisterAttached("IsUpdating",
                                                                            typeof(bool),typeof(PasswordHelper));
        #endregion private fields

        /// <summary>
        /// Set the values to password property
        /// </summary>
        /// <param name="dp">DependencyObject</param>
        /// <param name="value">value</param>
        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        /// <summary>
        /// Returns the value
        /// </summary>
        /// <param name="dp">dependency object</param>
        /// <returns></returns>
        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        /// <summary>
        /// To get the password property
        /// </summary>
        /// <param name="dp">DependencyObject</param>
        /// <returns>password data</returns>
        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        /// <summary>
        /// Set the password details
        /// </summary>
        /// <param name="dp">DependencyObject</param>
        /// <param name="value">value</param>
        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        /// <summary>
        /// updating the password details
        /// </summary>
        /// <param name="dp">DependencyObject</param>
        /// <returns>returns true or false</returns>
        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        /// <summary>
        /// Set the updations status 
        /// </summary>
        /// <param name="dp">DependencyObject</param>
        /// <param name="value">returns true or false</param>
        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        /// <summary>
        /// OnPasswordPropertyChanged action
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        /// <summary>
        /// subscription and unsubscription method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        /// <summary>
        /// password changed method
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
    }
}
