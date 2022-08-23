using System;
using System.Collections.Generic;
using System.Text;

namespace TopStoreApp.ViewModels
{
    public class BasePageViewModel : Xam.Plugin.BaseBindingLibrary.BaseNotifyProperty
    {
        private bool _isConnected;

        public bool IsConnected
        {
            get { return _isConnected; }
            set { OnPropertyChanged<bool>(ref _isConnected, value); }
        }
    }
}
