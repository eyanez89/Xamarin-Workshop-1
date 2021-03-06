﻿using System.ComponentModel;
using Xamarin.Forms;

namespace Agenda.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool _isBusy;
        INavigation _navigation;

        public bool IsBusy
        {
            set { if (_isBusy != value) { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }
            get { return _isBusy; }
        }

        public INavigation Navigation
        {
            set { if (_navigation != value) { _navigation = value; OnPropertyChanged(nameof(Navigation)); } }
            get { return _navigation; }
        }
    }
}
