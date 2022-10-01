using CommunityToolkit.Mvvm.ComponentModel;

namespace TopStoreApp.ViewModels;

public partial class BasePageViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isConnected;
}
