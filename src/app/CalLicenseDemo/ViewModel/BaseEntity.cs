using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace CalLicenseDemo.ViewModel
{
    public delegate void NavigateNextPage(string screenName, Dictionary<string, string> additionalInfo);
    public class BaseEntity : INotifyPropertyChanged
    {
        public NavigateNextPage NavigateNextPage;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _action;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}