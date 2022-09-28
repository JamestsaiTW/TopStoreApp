using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopStoreApp.ViewModels
{
    public partial class BasePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isConnected;

        //public bool IsConnected
        //{
        //    get { return _isConnected; }
        //    set { OnPropertyChanged<bool>(ref _isConnected, value); }
        //}

    }
}
