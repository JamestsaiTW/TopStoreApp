using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TopStoreApp.ViewModels;

public partial class GoodsPageViewModel: BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.Product> _goods;
}
